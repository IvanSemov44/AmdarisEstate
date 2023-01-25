namespace IvanRealEstate.Application.Queries.MessageQuery
{
    using MediatR;
    using IvanRealEstate.Shared.DataTransferObject.Message;

    public sealed record GetMessageQuery(Guid OwnerId,Guid MessageId,bool TrackChanges):IRequest<MessageDto>;
}
