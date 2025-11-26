
public interface IPerformerService
{
    Task<int> Signin(PerformerCreateDto performerDto);
}