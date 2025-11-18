
public interface ISeatingPlanService
{
    Task<SeatingPlanDto> GetByTheaterId(int id);
}