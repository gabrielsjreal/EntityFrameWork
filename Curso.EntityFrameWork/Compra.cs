using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Curso.EntityFrameWork
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public double Preco { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + ", Quantidade: " + Quantidade + 
                ", Preço: " + Preco + "\n Produto: " + Produto;
        }

    }
}
