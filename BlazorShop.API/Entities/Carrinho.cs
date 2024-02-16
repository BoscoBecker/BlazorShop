namespace BlazorShop.API.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public ICollection<CarrinhoItem> carrinhoItems { get; set; } = new List<CarrinhoItem>(); 
    }

}
