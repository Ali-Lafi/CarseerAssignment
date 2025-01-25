using CarseerAssignment.Application.DTOs;

namespace CarseerAssignment.Application.Interfaces;

public interface ICarService
{
    Task<List<CarMakeDTO>> GetAllMakesAsync();
    Task<List<VehicleTypeDTO>> GetVehicleTypesForMakeIdAsync(int makeId);
    Task<List<VehicleModelDTO>> GetModelsForMakeYearAsync(int makeId, int year);
}
