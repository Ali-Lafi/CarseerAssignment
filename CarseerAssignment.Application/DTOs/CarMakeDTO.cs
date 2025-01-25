using Newtonsoft.Json;

namespace CarseerAssignment.Application.DTOs;

public class CarMakeDTO
{
    [JsonProperty("Make_ID")]
    public int MakeId { get; set; }

    [JsonProperty("Make_Name")]
    public string MakeName { get; set; } = null!;
}
