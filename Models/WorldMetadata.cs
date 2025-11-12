namespace AiRpgBackend.Models;

public class WorldMetadata
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int TotalRegions { get; set; }
    public string GeographyType { get; set; }
    public string CurrentState { get; set; }
    public string MagicTechBalance { get; set; }
}
