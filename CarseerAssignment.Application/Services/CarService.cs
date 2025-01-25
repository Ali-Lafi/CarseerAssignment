using CarseerAssignment.Application.DTOs;
using CarseerAssignment.Application.Interfaces;

namespace CarseerAssignment.Application.Services;

public class CarService : ICarService
{
    private readonly IVehicleApiService _vehicleApiService;

    public CarService(IVehicleApiService vehicleApiService)
    {
        _vehicleApiService = vehicleApiService;
    }

    public async Task<List<CarMakeDTO>> GetAllMakesAsync()
    {
        return await _vehicleApiService.GetAllMakesAsync();
    }

    public async Task<List<VehicleModelDTO>> GetModelsForMakeYearAsync(int makeId, int year)
    {
        return await _vehicleApiService.GetModelsForMakeYearAsync(makeId, year);
    }

    public async Task<List<VehicleTypeDTO>> GetVehicleTypesForMakeIdAsync(int makeId)
    {
        return await _vehicleApiService.GetVehicleTypesForMakeIdAsync(makeId);
    }
}
