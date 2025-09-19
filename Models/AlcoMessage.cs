using System.Text.Json.Serialization;

public class AlcoMessage
{
    [JsonPropertyName("employeeId")]
    public int? EmployeeId { get; set; }
    
    [JsonPropertyName("accessPointId")]
    public int? AccessPointId { get; set; }
    
    [JsonPropertyName("type")]
    public int? Type { get; set; }
    
    [JsonPropertyName("ppm")]
    public object? Ppm { get; set; }
    
    [JsonPropertyName("departmentId")]  
    public int? DepartmentExternalId { get; set; }
    
    [JsonPropertyName("tabNumber")]
    public string? TabNumber { get; set; }
    
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; set; }
    
    [JsonPropertyName("direction")]
    public int? Direction { get; set; }
}