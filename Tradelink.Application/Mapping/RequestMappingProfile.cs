using Tradelink.Domain.AggregateModels.RequestAggregate;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;
using Tradelink.Application.ViewModels;
using AutoMapper;

namespace Tradelink.Application.Mapping
{
  public class RequestMappingProfile : Profile
  {
    public RequestMappingProfile()
    {
      CreateMap<RequestViewModel, Request>()
        .ReverseMap();
      CreateMap<ContactViewModel, Contact>()
        .ReverseMap();
      CreateMap<ProviderViewModel, Provider>()
        .ReverseMap();
      CreateMap<TransactionViewModel, Transaction>()
        .ReverseMap();
    }
  }
}