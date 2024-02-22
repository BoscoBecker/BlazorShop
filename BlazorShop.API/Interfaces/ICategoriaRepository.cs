using BlazorShop.API.Context;
using BlazorShop.API.Entities;

namespace BlazorShop.API.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetItens();
        Task<Categoria> GetItensById(int Id);
    }
}
