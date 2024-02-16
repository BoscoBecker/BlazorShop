using BlazorShop.API.Interfaces;
using BlazorShop.API.Mappings;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutosController(IProdutoRepository produtoRepository) => _produtoRepository = produtoRepository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetItems()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();
                if (produtos is null)
                    return NotFound();
                else
                    return Ok(produtos.ConvertProdutoToDTO());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Lista de produtos.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>>GetItem(int Id )
        {
            try
            {
                var produtos = await _produtoRepository.GetItem(Id);
                if (produtos is null)
                    return BadRequest("[]");
                else
                    return Ok(produtos.ConvertProdutoToDTO());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Lista de produtos pelo id."); ;
            }

           
        }



    }
}
