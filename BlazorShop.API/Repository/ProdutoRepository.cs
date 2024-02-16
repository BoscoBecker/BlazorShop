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

        public async Task<Produto> GetItem(int Id)
        {
            var produto = await _context.Produtos
                                        .Include(c => c.Categoria)
                                        .SingleOrDefaultAsync(c => c.Id == Id);
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetItens()
        {
            var produto = await _context.Produtos.ToListAsync();
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetItensPorCategoria(int id) { 

            var produto = await 
                        _context.Produtos.SingleOrDefaultAsync(c => c.Id == id);
            return (IEnumerable<Produto>)produto;
            
                                        
        }
    }
}
