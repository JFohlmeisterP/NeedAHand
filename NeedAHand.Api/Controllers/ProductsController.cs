using NeedAHand.Domain;
using NeedAHand.Domain.Infra;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using NeedAHand.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace NeedAHand.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //Include serve para Entity Framework fazer join nas consultas
            return _context.Products.Include(x => x.Fornecedor).ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductDto productdto)
        {
            //Criar produto a partir do productdto
            var produto = new Product(productdto);
            //Adicionar o produto na lista de produtos do _context
            _context.Products.Add(produto);
            //Salvar _context
            _context.SaveChanges();
            return Ok();
        }

    }
}
