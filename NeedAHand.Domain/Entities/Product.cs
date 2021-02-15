using NeedAHand.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedAHand.Domain
{
    public class Product : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Pais { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public User Fornecedor { get; set; }
        public Guid FornecedorId { get; set; }
        public List<ProductImage> Imagens { get; set; }
        public ProductImage ImagemCapa { get; set; }
        public Category CategoriaGeral { get; set; }
        public AulasCategorias? AulasCategoria { get; set; }
        public ConsertosManutencoesCategorias? ConsertosManutencoesCategoria { get; set; }
        public TransportesCategorias? TransportesCategoria { get; set; }
        public ServicosGeraisCategorias? ServicosGeraisCategoria { get; set; }
        public CuidadosPessoaisCategorias? CuidadosPessoaisCategoria { get; set; }
        public EventosCategorias? EventosCategoria { get; set; }
        public Product(ProductDto productdto)
        {
            Nome = productdto.Nome;
            Descricao = productdto.Descricao;
            Pais = productdto.Pais;
            Uf = productdto.Uf;
            Cidade = productdto.Cidade;
            FornecedorId = productdto.FornecedorId;
            CategoriaGeral = productdto.CategoriaGeral;
            AulasCategoria = productdto.AulasCategoria;
            ConsertosManutencoesCategoria = productdto.ConsertosManutencoesCategoria;
            TransportesCategoria = productdto.TransportesCategoria;
            ServicosGeraisCategoria = productdto.ServicosGeraisCategoria;
            CuidadosPessoaisCategoria = productdto.CuidadosPessoaisCategoria;
            EventosCategoria = productdto.EventosCategoria;
        }

        public Product()
        {

        }

    }
}




