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
            // ExibirProdutos();
            //ExcluirProdutos();
            //ExibirProdutos();
            //AtualizarProduto();
            //ComprarPaes();
            //Promocao();
            clientes();

        }

        //Método para relacionamento 1 para 1
        private static void clientes()
        {
            var cliente = new Cliente();
            cliente.Nome = "Cliente 1";
            cliente.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Inválidos",
                Complemento = "Sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            var contexto = new LojaContext();
            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();
        }

        // nessa operação usei o relacionamento JOIN usando a classe "PromocaoProduto" - Muitos para Muitos - Relação do banco
        private static void Promocao()
        {
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.0, Unidade = "Litros"};
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };

            var promocaoPascoa = new Promocao();
            promocaoPascoa.Descricao = "Páscoa Feliz";
            promocaoPascoa.DataInicio = DateTime.Now;
            promocaoPascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoPascoa.IncluiProduto(p1);
            promocaoPascoa.IncluiProduto(p2);
            promocaoPascoa.IncluiProduto(p3);

            var contexto = new LojaContext();
            contexto.Promocoes.Add(promocaoPascoa);
            contexto.SaveChanges();

        }

        //Método para realização da compra de Pães 
        private static void ComprarPaes()
        {
            var paoFrances = new Produto();
            paoFrances.Id = 002;
            paoFrances.Nome = "Pão Francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            var contexto = new LojaContext();

            contexto.Compras.Add(compra);
            contexto.SaveChanges();

        }

        // método para inserir um produto no banco de dados
        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Vingadores - Utimato";
            p.Categoria = "Filmes";
            p.PrecoUnitario = 74.90;

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
