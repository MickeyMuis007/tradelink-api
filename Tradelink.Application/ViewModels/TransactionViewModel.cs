using Tradelink.Application.SeedWork;
using System;
using System.Text.Json.Serialization;

namespace Tradelink.Application.ViewModels
{
  public class TransactionViewModel : ViewModel<Guid>, IViewModel
  {
    public string Type { get; set; }
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public Guid RequestId { get; set; }
    [JsonIgnore]
    public RequestViewModel Request { get; set; }
  }
}