using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectaSummer.Domain.AccountHolders
{
    public class AccountHolder
    {
        public Guid AccountHolderId { get; protected set; }

        public AccountHolder(string name, string taxnumber)
        {
            Name = name;            
            TaxNumber = taxnumber;
        }

        public string Name { get; protected set; }

        public string TaxNumber { get; protected set; }

        public DateTime StartDate { get; protected set; }



        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }

        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void SetAccountHolder(string name, string taxnumber)
        {
            Name = name;
            TaxNumber = taxnumber;
        }

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new(property, description, TypeValidator.ERROR);
            Errors.Add(erro);
        }
        public void ReleaseSave()
        {
            StartDate = DateTime.Today;

            if (string.IsNullOrEmpty(Name))
                AddError(nameof(Name), "Name can not null");

            if (Name.Length < 8)
                AddError(nameof(Name), "put at least 8 characters");

        }
        public void ReleaseUpdate()
        {
            if (string.IsNullOrEmpty(Name))
                AddError(nameof(Name), "Agency can not null");

            if (Name.Length < 8)
                AddError(nameof(Name), "put at least 8 characters");
        }
        public void ReleaseRemove()
        {
            if (string.IsNullOrEmpty(Name))
                AddError(nameof(Name), "Agency can not null");

            if (Name.Length < 8)
                AddError(nameof(Name), "put at least 8 characters");
        }
    }
}