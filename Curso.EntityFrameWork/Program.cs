using System;
using System.Collections.Generic;
using System.Linq;

namespace Curso.EntityFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            GravarUsandoEntity();
            ExibirProdutos();
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Homem de Ferro";
            p.Categoria = "Filmes";
            p.Preco = 35.50;

            var contexto = new LojaContext();
            
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            
        }

        private static void ExibirProdutos()
        {
            using (var banco = new LojaContext())
            {
                IList<Produto> produtos = banco.Produtos.ToList();
                foreach (var item in produtos)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
