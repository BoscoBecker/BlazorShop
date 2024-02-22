using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using BlazorShop.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Repository
{
    public class CategoriaRepository : ICategoriaRepository 
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetItens() => await 
                                                    _context.Categorias
                                                   .ToListAsync();
        

        public async Task<Categoria> GetItensById(int Id) => await 
                                         _context.Categorias
                                     .   SingleOrDefaultAsync(c => c.Id == Id);
        
    }

}
