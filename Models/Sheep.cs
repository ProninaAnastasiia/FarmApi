

namespace FarmApi.Models;

public class Sheep
{
    public int Id { get; set; }
    public string Breed { get; set; }
    public decimal Price { get; set; }
    public virtual Farm Farm { get; set; }
}