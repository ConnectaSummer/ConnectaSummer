using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.Accounts
{
    public class Account
    {
        public Guid AccountId { get; protected set; }

        public Account(string agency, string numberAccount, decimal balance, bool createCustomer = false, bool updateCustomer = false, bool deleteCustomer = false)
        {
            Agency = agency;
            NumberAccount = numberAccount;
            Balance = balance;
            CreateCustomer = createCustomer;
            UpdateCustomer = updateCustomer;
            DeleteCustomer = deleteCustomer;
        }

        public string Agency { get; protected set; }

        public string NumberAccount { get; protected set; }

        public decimal Balance { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public bool CreateCustomer { get; protected set; }

        public bool UpdateCustomer { get; protected set; }

        public bool DeleteCustomer { get; protected set; }


        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }

        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void SetAgency(string agency, string numberAccount)
        {
            Agency = agency;
            NumberAccount = numberAccount;
        }

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new BrokenRoles(property, description, TypeValidator.ERROR);
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
