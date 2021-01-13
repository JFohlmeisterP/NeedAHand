using System;
using System.Linq;

namespace NeedAHand.Domain
{
    public class User : Person
    {
        public Profile Profile { get; set; }
        public string Senha { get; set; }

        public User(Profile profile, string nome, string cpf, DateTime dataNascimento, string email, string telefone, string senha) :
            base(nome, cpf, dataNascimento, email, telefone)
        {
            Profile = profile;
            Senha = senha;
        }
    }
}

