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
            //ExibirProdutos();
            //ExcluirProdutos();
            //ExibirProdutos();
            AtualizarProduto();
        }

        // método para inserir um produto no banco de dados
        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Vingadores - Utimato";
            p.Categoria = "Filmes";
            p.Preco = 74.90;

            var contexto = new ProdutoDAOEntity();
            
                contexto.Adicionar(p);
              
            
        }
        
        //método para exibir os produtos que estão no banco de dados
        private static void ExibirProdutos()
        {
            var banco = new ProdutoDAOEntity();

                IList<Produto> produtos = banco.ExibirProdutos();

            if (produtos.Count != 0)
            {
                Console.WriteLine("Quantidade de Produto no Banco de Dados: " + produtos.Count);

                foreach (var item in produtos)
                {
                    Console.WriteLine(item);
                }
            } else
            {
                Console.WriteLine("Não há produtos cadastrados no banco de dados: " + produtos.Count);
            }
            
        }

        // método para excluir todos os elementos do banco de dados
        private static void ExcluirProdutos()
        {
            var banco = new ProdutoDAOEntity();
            var produtos = banco.ExibirProdutos();
            foreach (var item in produtos)
            {
                banco.Remover(item);
            }
            
        }

        //método para atualizar os elementos do banco de dados
        private static void AtualizarProduto()
        {
            // Incluir um produto
            GravarUsandoEntity();
            ExibirProdutos();


            // Atualizar o produto que já estava salvo

            var banco = new ProdutoDAOEntity();
            

            // usei o comando First() para retornar o 1º produto do banco
            Produto primeiroProduto = banco.ExibirProdutos().First();
            primeiroProduto.Nome = "Capitão Ámerica - Soldado Invernal";
            banco.Atualizar(primeiroProduto);
            ExibirProdutos();
        }
    }
}
