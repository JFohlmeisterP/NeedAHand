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

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var produto = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(produto);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Product dto)
        {
            var produto = _context.Products.Where(x => x.Id == id).FirstOrDefault();

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.FornecedorId = dto.FornecedorId;
            produto.CategoriaGeral = dto.CategoriaGeral;
            produto.AulasCategoria = dto.AulasCategoria;
            produto.ConsertosManutencoesCategoria = dto.ConsertosManutencoesCategoria;
            produto.TransportesCategoria = dto.TransportesCategoria;
            produto.ServicosGeraisCategoria = dto.ServicosGeraisCategoria;
            produto.CuidadosPessoaisCategoria = dto.CuidadosPessoaisCategoria;
            produto.EventosCategoria = dto.EventosCategoria;

            _context.Update(produto);
            _context.SaveChanges();
        }

        [HttpGet("{categoriaGeral}")]
        public Product Get(Category categoriaGeral)
        {
            return _context.Products.Where(x => x.CategoriaGeral == categoriaGeral).FirstOrDefault();
        }

        [HttpGet("Aulas/{aulasCategoria}")]
        public Product Get(AulasCategorias aulasCategoria)
        {
            return _context.Products.Where(x => x.AulasCategoria == aulasCategoria).FirstOrDefault();
        }

        [HttpGet("Consertos-Manutencoes/{consertosManutencoesCategoria}")]
        public Product Get(ConsertosManutencoesCategorias consertosManutencoesCategoria)
        {
            return _context.Products.Where(x => x.ConsertosManutencoesCategoria == consertosManutencoesCategoria).FirstOrDefault();
        }

        [HttpGet("Transportes/{transportesCategoria}")]
        public Product Get(TransportesCategorias transportesCategoria)
        {
            return _context.Products.Where(x => x.TransportesCategoria == transportesCategoria).FirstOrDefault();
        }

        [HttpGet("Servicos-Gerais/{servicosGeraisCategoria}")]
        public Product Get(ServicosGeraisCategorias servicosGeraisCategoria)
        {
            return _context.Products.Where(x => x.ServicosGeraisCategoria == servicosGeraisCategoria).FirstOrDefault();
        }

        [HttpGet("Cuidados-Pessoais/{cuidadosPessoaisCategoria}")]
        public Product Get(CuidadosPessoaisCategorias cuidadosPessoaisCategoria)
        {
            return _context.Products.Where(x => x.CuidadosPessoaisCategoria == cuidadosPessoaisCategoria).FirstOrDefault();
        }

        [HttpGet("Eventos/{eventosCategoria}")]
        public Product Get(EventosCategorias eventosCategoria)
        {
            return _context.Products.Where(x => x.EventosCategoria == eventosCategoria).FirstOrDefault();
        }

    }
}
