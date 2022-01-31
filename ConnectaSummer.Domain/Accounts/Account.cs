using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectaSummer.Domain.Accounts
{
    public class Account
    {
        public Guid AccountId { get; protected set; }

        public Account(string agency, string numberAccount)
        {
            Agency = agency;
            NumberAccount = numberAccount;
        }

        public string Agency { get; protected set; }

        public string NumberAccount { get; protected set; }

        public decimal Balance { get; protected set; }

        public DateTime StartDate { get; protected set; }



        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }

        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void Deposit(decimal value)
        {
            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            Balance -= value;
        }

        
        public void SetAgency(string agency, string numberAccount)
        {
            Agency = agency;
            NumberAccount = numberAccount;
        }

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new (property, description, TypeValidator.ERROR);
            Errors.Add(erro);
        }
        public void ReleaseSave()
        {
            StartDate = DateTime.Today;

            if (string.IsNullOrEmpty(Agency))
                AddError(nameof(Agency), "Agency can not null");

            if (Agency.Length < 3)
                AddError(nameof(Agency), "put at least 3 characters");

        }
        public void ReleaseUpdate()
        {
            if (string.IsNullOrEmpty(Agency))
                AddError(nameof(Agency), "Agency can not null");

            if (Agency.Length < 3)
                AddError(nameof(Agency), "put at least 3 characters");
        }
        public void ReleaseRemove()
        {
            if (string.IsNullOrEmpty(Agency))
                AddError(nameof(Agency), "Agency can not null");

            if (Agency.Length < 3)
                AddError(nameof(Agency), "put at least 3 characters");
        }
    }
}