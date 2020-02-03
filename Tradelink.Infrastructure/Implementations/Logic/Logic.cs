using Tradelink.Application.SeedWork;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tradelink.Domain.SeedWork;
using System;
using AutoMapper;

namespace Tradelink.Implementations.Logic
{
  public abstract class Logic<TViewModel> : ILogic<TViewModel, Guid> where TViewModel : class, IViewModel
  {

    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    
    public Logic(IUnitOfWork unitOfWork, IMapper mapper) 
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<IEnumerable<TViewModel>> Get()
    {
      var list = await _unitOfWork.RequestRepository.GetAll();
      var viewModels = _mapper.Map<IEnumerable<TViewModel>>(list);
      return viewModels;
    }

    public async Task<TViewModel> GetById(Guid id)
    {
      var entity = await _unitOfWork.RequestRepository.GetById(id);
      TViewModel viewModel = _mapper.Map<TViewModel>(entity);
      return viewModel;
    }

    public Task<TViewModel> Insert(TViewModel model)
    {
      return null;
    }

    public void Update(Guid id, TViewModel model)
    {

    }

    public void Delete(Guid id) 
    {

    }
  }
}