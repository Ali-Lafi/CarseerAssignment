using Newtonsoft.Json;

namespace CarseerAssignment.Application.DTOs;

public class VehicleModelDTO
{
    [JsonProperty("Model_ID")]
    public int ModelId { get; set; }

    [JsonProperty("Model_Name")]
    public string ModelName { get; set; } = null!;
}
