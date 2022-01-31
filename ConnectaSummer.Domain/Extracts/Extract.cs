using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectaSummer.Domain.Extracts
{
    public class Extract
    {
        public Guid ExtractId { get; protected set; }

        public Extract(long accountId, DateTime releaseDate, decimal value, long nature)
        {
            AccountId = accountId;
            ReleaseDate = releaseDate;
            Value = value;
            Nature = nature;
        }

        public long AccountId { get; protected set; }

        public DateTime ReleaseDate { get; protected set; }

        public decimal Value { get; protected set; }

        public long Nature { get; protected set; }

        public DateTime StartDate { get; protected set; }


        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }

        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void SetExtract(long accountId, DateTime releaseDate, decimal value, long nature)
        {
            AccountId = accountId;
            ReleaseDate = releaseDate;
            Value = value;
            Nature = nature;
        }

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new (property, description, TypeValidator.ERROR);
            Errors.Add(erro);
        }
        public void ReleaseSave()
        {
            StartDate = DateTime.Today;

            ReleaseDate = DateTime.Today;

            if (Value==0)
                AddError(nameof(Value), "Value can not zero");

        }
        public void ReleaseUpdate()
        {
            if (Value == 0)
                AddError(nameof(Value), "Value can not zero");
        }
        public void ReleaseRemove()
        {
            if (Value == 0)
                AddError(nameof(Value), "Value can not zero");
        }
    }
}