using FarmApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmApi.Controllers;
[Route("api/sheep")]
[ApiController]
public class SheepController: ControllerBase
{
    private readonly ILogger<SheepController> _logger;

    public SheepController(ILogger<SheepController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Sheep> Get()
    {
        return Sheep.ToArray();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var sheep = Sheep.First(e => e.Id==id);
        if (sheep==default) return NotFound();
        else return Ok(sheep);
    }
    
    [HttpGet("farm/{farmName}")]
    public IActionResult GetByFarm(string farmName)
    {
        var sheep = Sheep.Where(e => e.Farm.Name.Equals(farmName));
        if (sheep==default) return NotFound();
        else return Ok(sheep);
    }
    
    public static List<Sheep> Sheep = new List<Sheep> { 
        new Sheep() {Id = 1, Breed = "Curly", Price = 21000, Farm = FarmController.Farms.First(e => e.Name.Equals("HappyFarm"))}, 
        new Sheep() {Id = 2, Breed = "Longhair", Price = 20000, Farm = FarmController.Farms.First(e => e.Name.Equals("LuxFarm"))},
        new Sheep() {Id = 3, Breed = "Shorthair", Price = 1500, Farm = FarmController.Farms.First(e => e.Name.Equals("HappyFarm"))},
        new Sheep() {Id = 4, Breed = "BlackSheep", Price = 17000, Farm = FarmController.Farms.First(e => e.Name.Equals("LuxFarm"))},
        new Sheep() {Id = 5, Breed = "MeetSheep", Price = 25000, Farm = FarmController.Farms.First(e => e.Name.Equals("LuxFarm"))},
        new Sheep() {Id = 6, Breed = "Curly", Price = 21000, Farm = FarmController.Farms.First(e => e.Name.Equals("ChillyFarm"))}, 
        new Sheep() {Id = 7, Breed = "Longhair", Price = 20000, Farm = FarmController.Farms.First(e => e.Name.Equals("CoolFarm"))},
        new Sheep() {Id = 8, Breed = "Shorthair", Price = 1500, Farm = FarmController.Farms.First(e => e.Name.Equals("LuxFarm"))},
        new Sheep() {Id = 9, Breed = "BlackSheep", Price = 17000, Farm = FarmController.Farms.First(e => e.Name.Equals("LuxFarm"))},
        new Sheep() {Id = 10, Breed = "MeetSheep", Price = 25000, Farm = FarmController.Farms.First(e => e.Name.Equals("LuxFarm"))},
        new Sheep() {Id = 11, Breed = "Curly", Price = 21000, Farm = FarmController.Farms.First(e => e.Name.Equals("ChillyFarm"))}, 
        new Sheep() {Id = 12, Breed = "Longhair", Price = 20000, Farm = FarmController.Farms.First(e => e.Name.Equals("HappyFarm"))},
        new Sheep() {Id = 13, Breed = "Shorthair", Price = 1500, Farm = FarmController.Farms.First(e => e.Name.Equals("CoolFarm"))},
        new Sheep() {Id = 14, Breed = "BlackSheep", Price = 17000, Farm = FarmController.Farms.First(e => e.Name.Equals("HappyFarm"))},
        new Sheep() {Id = 15, Breed = "MeetSheep", Price = 25000, Farm = FarmController.Farms.First(e => e.Name.Equals("CoolFarm"))},
    };

}