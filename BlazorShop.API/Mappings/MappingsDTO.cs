using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;
using System.Collections;

namespace BlazorShop.API.Mappings
{
    public static class MappingsDTO
    {
        public static async Task<IEnumerable<CategoriaDTO>> ConvetCategoriasToDTO(this IEnumerable<Categoria> categorias)
        {
            var categoriasList = await Task.FromResult(categorias.ToList());
            return categoriasList.Select(
              Categoria => new CategoriaDTO
              {
                  Id = Categoria.Id,
                  Nome = Categoria.Nome,
                  IconCss = Categoria.IconCss
              }).ToList();

        }

        public static async Task<IEnumerable<ProdutoDTO>> ConvertProdutoToDTO(this IEnumerable<Produto> produtos)
        {
            var produtoList = await Task.FromResult(produtos.ToList());
            return produtoList.Select(
              Produto => new ProdutoDTO
              {
                  Id = Produto.Id,
                  Nome = Produto.Nome,
                  CategoriaId = Produto.CategoriaId,
                  ImageUrl = Produto.ImageUrl,
                  Preco = Produto.Preco,
                  Descricao = Produto.Descricao,
                  Quantidade = Produto.Quantidade
              }).ToList();
        }

        public static async Task<ProdutoDTO> ConvertProdutoToDTO(this Produto produto)
        {
            return await Task.FromResult(new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                CategoriaId = produto.CategoriaId,
                ImageUrl = produto.ImageUrl,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
            });

        }
        public static async Task<IEnumerable<CarrinhoItemDTO>> ConvertCarrinhoItemDTO(this IEnumerable<CarrinhoItem> carrinhoItens, IEnumerable<Produto> produtos)
        {
            var produtosList = await Task.FromResult(produtos.ToList());

            return (from carrinhoItem in carrinhoItens
                    join produto in produtosList
                    on carrinhoItem.ProdutoId equals produto.Id
                    select new CarrinhoItemDTO
                    {
                        Id = carrinhoItem.Id,
                        ProdutoId = carrinhoItem.ProdutoId,
                        ProdutoNome = produto.Nome,
                        ProdutoDescricao = produto.Descricao,
                        ProdutoImagemURL = produto.ImageUrl,
                        Preco = produto.Preco,
                        CarrinhoId = carrinhoItem.CarrinhoId,
                        Quantidade = carrinhoItem.Quantidade,
                        PrecoTotal = (produto.Preco * carrinhoItem.Quantidade)
                    }).ToList();
        }

        public static async Task<CarrinhoItemDTO> ConvertCarrinhoItemDTO(this CarrinhoItem carrinhoitens, Produto produtos) {
            return await Task.FromResult(
                new CarrinhoItemDTO
                {
                    Id = carrinhoitens.Id,
                    ProdutoId = carrinhoitens.ProdutoId,
                    ProdutoNome = produtos.Nome,
                    ProdutoDescricao = produtos.Descricao,
                    ProdutoImagemURL = produtos.ImageUrl,
                    Preco = produtos.Preco,
                    CarrinhoId = carrinhoitens.CarrinhoId,
                    Quantidade = carrinhoitens.Quantidade,
                    PrecoTotal = (produtos.Preco * carrinhoitens.Quantidade)
                });           
        }
    }
}
