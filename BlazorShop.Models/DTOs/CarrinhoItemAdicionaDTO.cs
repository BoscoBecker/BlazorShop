using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Models.DTOs
{
  public class CarrinhoItemAdicionaDTO
  {
    [Required]
    public int CarrinhroId { get; set; }

    [Required]
    public int ProdutoId { get; set; }

    [Required]
    public int Quantidade { get; set; }

  }
}
