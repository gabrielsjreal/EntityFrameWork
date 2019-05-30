using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.EntityFrameWork
{
    interface IProdutoDAO
    {
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(Produto produto);
        // esse método representa o Select -> para exibir os elementos
        IList<Produto> ExibirProdutos();

    }
}
