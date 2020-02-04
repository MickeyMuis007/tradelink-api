using Tradelink.Application.SeedWork;
using System;

namespace Tradelink.Application.ViewModels
{
  public class ProviderViewModel : ViewModel<Guid>, IViewModel
  {
    public string Name { get; set; }
    public Guid ContactId { get; set; }
    public ContactViewModel Contact { get; set; }
  }
}