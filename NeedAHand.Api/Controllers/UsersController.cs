using NeedAHand.Domain;
using NeedAHand.Domain.Infra;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedAHand.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            var userDb = _context.Users.Where(x => x.Cpf == user.Cpf);
            if (userDb == default)
                return BadRequest("CPF já cadastrado!");
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User dto)
        {
            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();

            user.Nome = dto.Nome;
            user.Profile = dto.Profile;
            user.Telefone = dto.Telefone;
            user.Cpf = dto.Cpf;
            user.DataNascimento = dto.DataNascimento;
            user.Email = dto.Email;
            user.Senha = dto.Senha;

            _context.Update(user);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(user);
            _context.SaveChanges();
        }

        [HttpPost("Login")]
        public ActionResult<User> Login(string cpf, string senha)
        {
            var user = _context.Users.Where(x => x.Cpf == cpf).FirstOrDefault();

            if (user == default)
                return Unauthorized("Usuário não encontrado!");

            if (user.Senha != senha)
                return Unauthorized("Senha incorreta!");

            return Ok(user);
        }
    }
}
