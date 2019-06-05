using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.EntityFrameWork
{
    public class PromocaoProduto
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }
    }
}
