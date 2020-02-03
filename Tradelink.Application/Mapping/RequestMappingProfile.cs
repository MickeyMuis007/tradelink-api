using Tradelink.Domain.AggregateModels.RequestAggregate;
using Tradelink.Application.ViewModels;
using AutoMapper;

namespace Tradelink.Application.Mapping
{
  public class RequestMappingProfile : Profile
  {
    public RequestMappingProfile()
    {
      CreateMap<RequestViewModel, Request>();
      CreateMap<Request, RequestViewModel>();
    }
  }
}