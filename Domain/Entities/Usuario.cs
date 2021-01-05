using System;
using System.Linq;

namespace Domain
{
    public class Usuario : Pessoa
    {
        public Perfil Perfil { get; set; }

        public Usuario(Perfil perfil, string nome, string cpf, DateTime dataNascimento, string email, string telefone) :
            base(nome, cpf, dataNascimento, email, telefone)
        {
            Perfil = perfil;
        }



    }
}

