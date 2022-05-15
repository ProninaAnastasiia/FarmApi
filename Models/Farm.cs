using System.Text.Json.Serialization;

namespace FarmApi.Models;

public class Farm
{
    public string Name { get; set; }
    public decimal Worth { get; set; }
    public int ClientsCount { get; set; }
    [JsonIgnore]
    public virtual ICollection<Sheep> Sheeps { get; set; }
   
}