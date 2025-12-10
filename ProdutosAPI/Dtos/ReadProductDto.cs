using System.ComponentModel.DataAnnotations;

namespace ProdutosAPI.Dtos;

public class ReadProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Double Price { get; set; }
    public string Category { get; set; }
    public DateTime SearchingTime { get; set; } = DateTime.Now;
}
