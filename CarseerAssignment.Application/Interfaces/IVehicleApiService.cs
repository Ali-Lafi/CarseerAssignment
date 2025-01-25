using CarseerAssignment.Application.DTOs;

namespace CarseerAssignment.Application.Interfaces;

public interface IVehicleApiService
{
    Task<List<CarMakeDTO>> GetAllMakesAsync();
   
    Task<List<VehicleTypeDTO>> GetVehicleTypesForMakeIdAsync(int makeId);
    
    Task<List<VehicleModelDTO>> GetModelsForMakeYearAsync(int makeId, int year);
}
