
using backend.Entities;

public interface ISeatingPlanRepository
{
    Task<List<Row>> GetRowWithSeatByTheaterId(int theaterId);
}