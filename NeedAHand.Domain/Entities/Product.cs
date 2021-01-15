using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedAHand.Domain
{
    public class Product : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public User Fornecedor { get; set; }
        public List<ProductImage> Imagens { get; set; }
        public ProductImage ImagemCapa { get; set; }
    }
}




