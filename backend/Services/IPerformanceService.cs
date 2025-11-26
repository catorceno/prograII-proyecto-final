
public interface IPerformanceService
{
    Task<int> Create(PerformanceCreateDto performanceDto);
    Task<List<PerformanceDto>> GetAllByPlayId(int playId);
    Task<PerformanceDto?> GetById(int id);
    Task<PerformanceSeatingPlanDto> GetSeatingPlanByPerformanceId(int performanceId);
}