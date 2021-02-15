using NeedAHand.Domain;
using NeedAHand.Domain.Infra;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using NeedAHand.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

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
            produto.Pais = dto.Pais;
            produto.Uf = dto.Uf;
            produto.Cidade = dto.Cidade;
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
        public IEnumerable<Product> Get(Category categoriaGeral) =>
            _context.Products.Where(x => x.CategoriaGeral == categoriaGeral);

        [HttpGet("Aulas/{aulasCategoria}")]
        public IEnumerable<Product> Get(AulasCategorias aulasCategoria) =>
            _context.Products.Where(x => x.AulasCategoria == aulasCategoria);

        [HttpGet("Consertos-Manutencoes/{consertosManutencoesCategoria}")]
        public IEnumerable<Product> Get(ConsertosManutencoesCategorias consertosManutencoesCategoria) =>
            _context.Products.Where(x => x.ConsertosManutencoesCategoria == consertosManutencoesCategoria);

        [HttpGet("Transportes/{transportesCategoria}")]
        public IEnumerable<Product> Get(TransportesCategorias transportesCategoria) =>
            _context.Products.Where(x => x.TransportesCategoria == transportesCategoria);

        [HttpGet("Servicos-Gerais/{servicosGeraisCategoria}")]
        public IEnumerable<Product> Get(ServicosGeraisCategorias servicosGeraisCategoria) =>
            _context.Products.Where(x => x.ServicosGeraisCategoria == servicosGeraisCategoria);

        [HttpGet("Cuidados-Pessoais/{cuidadosPessoaisCategoria}")]
        public IEnumerable<Product> Get(CuidadosPessoaisCategorias cuidadosPessoaisCategoria) =>
            _context.Products.Where(x => x.CuidadosPessoaisCategoria == cuidadosPessoaisCategoria);

        [HttpGet("Eventos/{eventosCategoria}")]
        public IEnumerable<Product> Get(EventosCategorias eventosCategoria) =>
            _context.Products.Where(x => x.EventosCategoria == eventosCategoria);

    }
}
