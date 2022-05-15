using System.Linq;
using FarmApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmApi.Controllers;
[Route("api/farms")]
[ApiController]
public class FarmController: ControllerBase
{
    public static List<Farm> Farms = new List<Farm> { 
        new Farm() {Name = "HappyFarm", Worth = 150000, ClientsCount = 6}, 
        new Farm() {Name = "LuxFarm", Worth = 250000, ClientsCount = 10},
        new Farm() {Name = "ChillyFarm", Worth = 130000, ClientsCount = 4},
        new Farm() {Name = "CoolFarm", Worth = 200000, ClientsCount = 7}
    };
    
    private readonly ILogger<FarmController> _logger;

    public FarmController(ILogger<FarmController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Farm> Get()
    {
        return Farms.ToArray();
    }

    [HttpGet("{farmName}")]
    public IActionResult Get(string farmName)
    {
        var farm = Farms.Where(e => e.Name.Equals(farmName));
        if (farm==default) return NotFound();
        else return Ok(farm);
    }
    
    [HttpGet("sort/{worth}")]
    public IActionResult GetByWorth(decimal worth)
    {
        var farms = Farms.Where(e => e.Worth>worth);
        if (!farms.Any()) return NotFound();
        else return Ok(farms);
    }
}