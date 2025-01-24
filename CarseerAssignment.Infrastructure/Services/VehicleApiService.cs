    using CarseerAssignment.Application.DTOs;
using CarseerAssignment.Application.Interfaces;
using CarseerAssignment.Infrastructure.Helpers;
using Newtonsoft.Json;

namespace CarseerAssignment.Infrastructure.Services;

public class VehicleApiService : IVehicleApiService
{
    private readonly HttpClient _httpClient;

    public VehicleApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CarMakeDTO>> GetAllMakesAsync()
    {
        var response = await _httpClient.GetStringAsync("getallmakes?format=json");
        var result = JsonConvert.DeserializeObject<ApiResponse<CarMakeDTO>>(response);
        return result.Results;
    }

    public async Task<List<VehicleModelDTO>> GetModelsForMakeYearAsync(int makeId, int year, string vehicleType)
    {
        var response = await _httpClient.GetStringAsync($"GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json");
        var result = JsonConvert.DeserializeObject<ApiResponse<VehicleModelDTO>>(response);
        return result.Results;
    }

    public async Task<List<VehicleTypeDTO>> GetVehicleTypesForMakeIdAsync(int makeId)
    {
        var response = await _httpClient.GetStringAsync($"GetVehicleTypesForMakeId/{makeId}?format=json");
        var result = JsonConvert.DeserializeObject<ApiResponse<VehicleTypeDTO>>(response);
        return result.Results;
    }
}
