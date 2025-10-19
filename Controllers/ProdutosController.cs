using CadastroProdutos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private ProdutosService produtosService = new ProdutosService();

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(produtosService.ObterTodos());
        }


        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = produtosService.ProdutoID(id);

            if (produto is null)
            {
                return NotFound("Achei nada men");

            }
            else
            {
                return produto;
            }

        }

        [HttpPost]
        public ActionResult Post(Produto NewProduto)
        {
            produtosService.AdicionarProduto(NewProduto);
            return Created();
        }
        

        [HttpPut("id")]
        public ActionResult Put(int id, Produto produtoAtualizado)
        {
            var statusAtualizacao = produtosService.Atualizar(id, produtoAtualizado );

            if (statusAtualizacao)
            {
                return Ok("Produto Atualizado");             
            }

            return NotFound($"Não encontrei o produto com ID:{id}");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete( int id )
        {

            var StatusRemocao = produtosService.Remover(id);

            if (StatusRemocao)
            {
                return Ok("Produto Removido");
            }
            return NoContent();
            
        }
    
    
    }
    
}
