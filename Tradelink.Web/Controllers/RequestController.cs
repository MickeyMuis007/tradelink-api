using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tradelink.Persistence.Context;
using Tradelink.Application.Logic;
using Tradelink.Application.ViewModels;

namespace Tradelink.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RequestController : ControllerBase
  {
    private IRequestLogic _requestLogic;
    private readonly TradelinkContext _db;

    public RequestController(TradelinkContext db, IRequestLogic requestLogic)
    {
      _db = db;
      _requestLogic = requestLogic;
    }

    [HttpGet]
    public async Task<IEnumerable<RequestViewModel>> Get()
    {
      // var requests = _db.Users.ToList();
      var results = await _requestLogic.Get();
      return results;
    }

    [HttpGet("{id}")]
    public async Task<RequestViewModel> GetById(Guid id)
    {
      var result = await _requestLogic.GetById(id);
      return result;
    }

    [HttpPost]
    public async Task<RequestViewModel> Insert([FromBody] RequestViewModel requestViewModel)
    {
      var results = await _requestLogic.Insert(requestViewModel);
      return results;
    }
  }
}