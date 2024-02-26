using BlazorShop.API.Entities;
using BlazorShop.API.Interfaces;
using BlazorShop.API.Mappings;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetItens()
        {

            try
            {
                var categoria = await _repository.GetItens();
                if (categoria is null)
                    return Ok("[]");
                else
                {
                    return Ok(categoria.ConvertCategoriasToDTO());
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro interno no Servidor,Erro ao obter ConvetCategoriasToDTO() ");
            }

        }

        [HttpGet]
        [Route("{id: int}")]
        public async Task<ActionResult<CategoriaDTO>> GetItensById(int Id)
        {

            try
            {
                var categoria = await _repository.GetItensById(Id);
                var dataAtual = DateTime.Now;
                if (categoria is null)
                    return Ok("[]");
                else
                    return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro interno no Servidor,Erro ao obter ConvetCategoriasToDTOById() ");
            }

        }
    }
}
