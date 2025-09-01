using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using sigur_emulation.Models;

namespace sigur_emulation.Dto;

public class OrganizationDto
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public Dictionary<string,string> Name { get; set; }
    public Dictionary<string, string> ShortName { get; set; }
    [Required]
    public int ExternalId { get; set; }
}