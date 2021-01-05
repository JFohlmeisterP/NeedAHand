using Domain;
using Domain.Infra;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedAHand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("{id}")]
        public Usuario Get(Guid id)
        {
            return _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Usuario dto)
        {
            var user = _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();

            user.Nome = dto.Nome;
            user.Perfil = dto.Perfil;
            user.Telefone = dto.Telefone;
            user.Cpf = dto.Cpf;
            user.DataNascimento = dto.DataNascimento;
            user.Email = dto.Email;

            _context.Update(user);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var user = _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
