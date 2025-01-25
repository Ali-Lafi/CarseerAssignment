using CarseerAssignment.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarseerAssignment.Web.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<IActionResult> Index()
    {     
        return View();
    }

    [HttpGet]
    public async Task<JsonResult> GetCarMakes()
    {
        var allMakes = await _carService.GetAllMakesAsync();
        return Json(allMakes);
    }

    [HttpGet]
    public async Task<JsonResult> GetVehicleTypes(int makeId)
    {
        var vehicleTypes = await _carService.GetVehicleTypesForMakeIdAsync(makeId);
        return Json(vehicleTypes);
    }

    [HttpGet]
    public async Task<JsonResult> GetModels(int makeId, int year)
    {
        var models = await _carService.GetModelsForMakeYearAsync(makeId, year);
        return Json(models);
    }
}
