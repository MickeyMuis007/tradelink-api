using Tradelink.Application.SeedWork;
using System;
using System.Collections.Generic;

namespace Tradelink.Application.ViewModels
{
  public class ContactViewModel : ViewModel<Guid>, IViewModel
  {
    public string Name { get; set; }
    public string TelephoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public IEnumerable<ProviderViewModel> Providers { get; set; }
  }
}