using BlazorShop.Models.DTOs;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{
    public class ProdutoService : IProdutoService
    {
        public ProdutoService(HttpClient httpClient, ILogger<ProdutoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
 
       
        public HttpClient _httpClient;
        public ILogger<ProdutoService> _logger;


        public async Task<IEnumerable<ProdutoDTO>> GetItens()
        {
            try
            {
                var produtoDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDTO>>("api/produtos");
                return produtoDto;

            }
            catch (Exception)
            {

                _logger.LogError("Erro ao acessar produtos : api/produtos");
            }
        }
    }
}
