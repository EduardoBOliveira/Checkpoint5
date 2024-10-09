using CrudMongoDB.Models;
using CrudMongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProdutos() =>
            await _produtoService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Produto>> Get(string id)
        {
            var produto = await _produtoService.GetAsync(id);

            if (produto is null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            await _produtoService.CreateAsync(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Produto produto)
        {
            var existingProduto = await _produtoService.GetAsync(id);

            if (existingProduto is null)
            {
                return NotFound();
            }

            produto.Id = existingProduto.Id;
            await _produtoService.UpdateAsync(id, produto);

            return Ok(produto);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var produto = await _produtoService.GetAsync(id);

            if (produto is null)
            {
                return NotFound();
            }

            await _produtoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
