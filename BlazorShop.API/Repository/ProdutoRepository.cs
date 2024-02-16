using BlazorShop.API.Context;
using BlazorShop.API.Entities;
using BlazorShop.API.Interfaces;
using BlazorShop.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.API.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetItem(int Id) => await 
                                    _context.Produtos
                                   .Include(c => c.Categoria)
                                   .SingleOrDefaultAsync(c => c.Id == Id);
        

        public async Task<IEnumerable<Produto>> GetItens() => await 
                                                 _context.Produtos
                                                .Include(c => c.Categoria)
                                                .ToListAsync();


        public async Task<IEnumerable<Produto>> GetItensPorCategoria(int id) => await
                                                _context.Produtos
                                                .Include(c => c.Categoria)
                                                .Where(p => p.CategoriaId == id)
                                                .ToListAsync();
    }
}
