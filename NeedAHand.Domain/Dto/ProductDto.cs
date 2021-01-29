using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedAHand.Domain.Dto
{
    public class ProductDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
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

    }
}




