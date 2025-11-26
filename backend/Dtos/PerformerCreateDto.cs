
public class PerformerCreateDto : UserDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public PerformerType Type { get; set; }
}