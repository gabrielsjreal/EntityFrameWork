using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.EntityFrameWork
{
    public class Produto
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string Categoria { get;  set; }
        public double Preco { get;  set; }

        public override string ToString()
        {
            return "Id: " + Id + "\n"+
                    "Nome: " + Nome + "\n" +
                    "Categoria: " + Categoria + "\n" +
                    "Preço: " + Preco  ;
        }
    }
}
