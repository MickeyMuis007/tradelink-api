using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tradelink.Application.SeedWork
{
  public interface ILogic <TViewModel, TId> where TViewModel : class, IViewModel
  {
    Task<IEnumerable<TViewModel>> Get();
    Task<TViewModel> GetById(TId id);
    Task<TViewModel> Insert(TViewModel model);
    void Update(TId id, TViewModel model);
    void Delete(TId id);
  }
}