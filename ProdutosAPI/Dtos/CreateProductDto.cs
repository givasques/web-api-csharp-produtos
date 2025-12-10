using System.ComponentModel.DataAnnotations;

namespace ProdutosAPI.Dtos;

public class CreateProductDto
{
    [Required]
    [StringLength(50, ErrorMessage = "The length of the name must not exceed 50 char!")]
    public string Name { get; set; }
    [Required]
    [Range(0.1, 500, ErrorMessage = "The price value should be between 0,10 and 500!")]
    public Double Price { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "The length of the category must not exceed 50 char!")]
    public string Category { get; set; }
}
