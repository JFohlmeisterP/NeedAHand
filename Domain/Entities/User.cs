using System;
using System.Linq;

namespace Domain
{
    public class User : Person
    {
        public Profile Profile { get; set; }

        public User(Profile profile, string nome, string cpf, DateTime dataNascimento, string email, string telefone) :
            base(nome, cpf, dataNascimento, email, telefone)
        {
            Profile = profile;
        }



    }
}

