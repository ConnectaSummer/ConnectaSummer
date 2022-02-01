using ConnectaSummer.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectaSummer.Domain.Extracts
{
    public class Extract
    {
        public Guid ExtractId { get; protected set; }

        public Guid AccountId { get; protected set; }

        public DateTime ReleaseDate { get; protected set; }

        public decimal Value { get; protected set; }

        public NatureType Nature { get; protected set; }

        public DateTime StartDate { get; protected set; }


        public virtual Account Account { get; protected set; }

        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }

        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void Withdraw(Account account, decimal value)
        {
            if (value > account.Balance)
            {
                AddError("Withdraw", "insufficient funds");
            }
            AccountId = account.AccountId;
            ReleaseDate = DateTime.Now;
            Value = value;
            Nature = NatureType.Debit;
            Errors = new List<BrokenRoles>();
            account.Withdraw(value);
        }

        public void Deposit(Account account, decimal value)
        {
            AccountId = account.AccountId;
            ReleaseDate = DateTime.Now;
            Value = value;
            Nature = NatureType.Credit;
            Errors = new List<BrokenRoles>();
            account.Deposit(value);
        }

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new (property, description, TypeValidator.ERROR);
            Errors.Add(erro);
        }
    }
}