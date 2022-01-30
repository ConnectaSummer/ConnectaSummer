using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.AccountHolders
{
    public class AccountHolder
    {
        public Guid AccountHolderId { get; protected set; }

        public AccountHolder(string name, string taxnumber, bool createCustomer = false, bool updateCustomer = false, bool deleteCustomer = false)
        {
            Name = name;            
            TaxNumber = taxnumber;
            CreateCustomer = createCustomer;
            UpdateCustomer = updateCustomer;
            DeleteCustomer = deleteCustomer;
        }

        public string Name { get; protected set; }

        public string TaxNumber { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public bool CreateCustomer { get; protected set; }

        public bool UpdateCustomer { get; protected set; }

        public bool DeleteCustomer { get; protected set; }


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
            BrokenRoles erro = new BrokenRoles(property, description, TypeValidator.ERROR);
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
