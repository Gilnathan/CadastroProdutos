using System;

namespace CadastroProdutos.Services;

public class ProdutosService
{
    private static List<Produto> produtos = new List<Produto>()
        {
            new Produto(){ Id = 1, Nome = "Mouse sem fio", Preco =40.90M, Estoque = 50 },
            new Produto(){ Id = 2, Nome = "Teclado sem fio", Preco =20.90M, Estoque = 20 }
        };

    public List<Produto> ObterTodos()
    {
        return produtos;
    }

    public Produto ProdutoID(int id)
    {
        return produtos.FirstOrDefault((x) => x.Id == id);
    }

    public void AdicionarProduto(Produto produto)
    {
        produtos.Add(produto);
        
    }

    public bool Atualizar(int id, Produto ProdutoAtualizado)
    {
        var produto = produtos.FirstOrDefault((x) => x.Id == id);

        if (produto is null)
        {
            return false;
        }

        produto.Nome = ProdutoAtualizado.Nome;
        produto.Preco = ProdutoAtualizado.Preco;
        produto.Estoque = ProdutoAtualizado.Estoque;

        return true;
    }
    
    public bool Remover(int id)
    {
        var produto = produtos.FirstOrDefault((x) => x.Id == id);

        if (produto is null)
        {
            return false;
        }

        produtos.Remove(produto);
        return true;
    }



}
