﻿using System.Collections.ObjectModel;

namespace BlazorShop.API.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string IconCss { get; set; } = string.Empty;
        public Collection<Produto> Produtos { get; set; } = new Collection<Produto>();

    }
}
