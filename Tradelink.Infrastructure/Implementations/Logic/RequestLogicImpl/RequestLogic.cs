using Tradelink.Application.Logic;
using Tradelink.Application.ViewModels;
using Tradelink.Domain.SeedWork;
using Tradelink.Domain.AggregateModels.RequestAggregate;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;


namespace Tradelink.Implementations.Logic.RequestLogicImpl
{
  public class RequestLogic : IRequestLogic
  {
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public RequestLogic(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<IEnumerable<RequestViewModel>> Get()
    {
      var list = await _unitOfWork.RequestRepository.GetAllInclude();
      var viewModels = _mapper.Map<IEnumerable<RequestViewModel>>(list);
      return viewModels;
    }

    public async Task<RequestViewModel> GetById(Guid id)
    {
      var entity = await _unitOfWork.RequestRepository.GetById(id);
      RequestViewModel viewModel = _mapper.Map<RequestViewModel>(entity);
      return viewModel;
    }

    public async Task<RequestViewModel> Insert(RequestViewModel model)
    {
      Request request = _mapper.Map<Request>(model);
      request = await _unitOfWork.RequestRepository.Insert(request);
      await _unitOfWork.SaveAsync();
      RequestViewModel viewModel = _mapper.Map<RequestViewModel>(request);
      viewModel.provider = null;
      viewModel.Transactions = new List<TransactionViewModel>();
      return viewModel;
    }

    public void Update(Guid id, RequestViewModel model)
    {
      
    }

    public void Delete(Guid id)
    {

    }
  }
}