
using AutoMapper;
using backend.Entities;

public class PerformerService: IPerformerService
{
    private readonly TeatroTickets7Context context;
    private readonly IMapper mapper;
    public PerformerService(TeatroTickets7Context context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task CreateRequest(EventCreateDto eventDto)
    {
        var newEvent = mapper.Map<Event>(eventDto);
        context.Events.Add(newEvent);
        if(eventDto.Plays != null)
        {
            newEvent.Plays = new List<Play>();
            foreach (var playDto in eventDto.Plays)
            {
                var newPlay = mapper.Map<PlayPerformance>(playDto);
                if(playDto.Performances != null)
                {
                    
                }
            }
        }
    }
}