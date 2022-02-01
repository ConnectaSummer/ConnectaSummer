using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectaSummer.Domain.Users
{
    public class User
    {
        public Guid UserId { get; protected set; }

        public User(string login, string pass)
        {
            Login = login;
            Pass = pass;
        }

        public string Login { get; protected set; }

        public string Pass { get; protected set; }

        public DateTime StartDate { get; protected set; }

        [NotMapped]
        public List<BrokenRoles> Errors { get; protected set; }

        [NotMapped]
        public Boolean HasErrors => Errors.Count > 0;

        public void SetLogin(string login, string pass)
        {
            Login = login;
            Pass = pass;
        }

        public void AddError(string property, string description)
        {
            BrokenRoles erro = new (property, description, TypeValidator.ERROR);
            Errors.Add(erro);
        }
        public void ReleaseSave()
        {
            StartDate = DateTime.Today;
            Errors = new List<BrokenRoles>();

            if (string.IsNullOrEmpty(Login))
                AddError(nameof(Login), "login can not null");

            if (Login.Length < 3)
                AddError(nameof(Login), "put at least 3 characters");

        }
    }

    public enum NivelAcesso
    {
        ADM,
        MANAGENT
    }
}