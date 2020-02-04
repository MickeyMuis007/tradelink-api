using Tradelink.Application.SeedWork;
using System;
using System.Collections.Generic;

namespace Tradelink.Application.ViewModels
{
  public class RequestViewModel : ViewModel<Guid>, IViewModel
  {
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public bool Active { get; set; }
    public ProviderViewModel provider { get; set; }
    public IEnumerable<TransactionViewModel> Transactions { get; set; }

  }
}