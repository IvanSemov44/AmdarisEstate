namespace IvanRealEstate.Application.Queries.MessageQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Message;

    public sealed record GetAllMessagesQuery(Guid OwnerId,bool TrackChanges): IRequest<IEnumerable<MessageDto>>;
    
}
