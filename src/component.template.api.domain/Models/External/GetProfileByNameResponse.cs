namespace component.template.api.domain.Models.External;

public class GetProfileByNameResponse
{
    public int ProfileId { get; set; }
    public string ProfileName { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } 
}
