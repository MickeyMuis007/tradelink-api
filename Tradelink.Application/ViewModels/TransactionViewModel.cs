using Tradelink.Application.SeedWork;
using System;

namespace Tradelink.Application.ViewModels
{
  public class TransactionViewModel : ViewModel<Guid>, IViewModel
  {
    public string Type { get; set; }
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public Guid RequestId { get; set; }
    public RequestViewModel Request { get; set; }
  }
}