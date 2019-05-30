using System;
using System.Collections.Generic;
using System.Linq;

namespace Curso.EntityFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoEntity();
            ExibirProdutos();
            //ExcluirProdutos();
           // ExibirProdutos();
        }

        // método para inserir um produto no banco de dados
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
        
        //método para exibir os produtos que estão no banco de dados
        private static void ExibirProdutos()
        {
            var banco = new LojaContext();

                IList<Produto> produtos = banco.Produtos.ToList();

            if (produtos.Count != 0)
            {
                Console.WriteLine("Tamnho da Lista: " + produtos.Count);

                foreach (var item in produtos)
                {
                    Console.WriteLine(item);
                }
            } else
            {
                Console.WriteLine("Lista Vazia: " + produtos.Count);
            }
            
        }

        // método para excluir todos os elementos do banco de dados
        private static void ExcluirProdutos()
        {
            var banco = new LojaContext();
            IList<Produto> produtos = banco.Produtos.ToList();
            foreach (var item in produtos)
            {
                banco.Produtos.Remove(item);
            }
            banco.SaveChanges();
        }
    }
}
