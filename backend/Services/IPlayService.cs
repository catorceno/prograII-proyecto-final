
public interface IPlayService
{
    Task<int> Create(PlayCreateDto playDto);
    Task<List<PlayDto>> GetAllPublished();
    Task<PlayDetailsDto?> GetPublishedById(int id);
}