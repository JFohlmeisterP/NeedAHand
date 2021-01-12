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
        public void Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
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
    }
}
