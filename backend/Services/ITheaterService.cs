
public interface ITheaterService
{
    Task<bool> RejectRequest(int playId);
    Task<bool> AcceptRequest(int playId);
    Task<bool> CancelPlay(int playId);
    Task<bool> CancelPerformance(int playId);
}