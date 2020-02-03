using Tradelink.Application.SeedWork;
using System;

namespace Tradelink.Application.ViewModels
{
  public class RequestViewModel : ViewModel<Guid>, IViewModel
  {
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public bool Active { get; set; }
  }
}