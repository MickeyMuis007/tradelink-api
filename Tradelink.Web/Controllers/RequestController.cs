using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tradelink.Persistence.Context;

namespace Tradelink.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RequestController : ControllerBase
  {
    private readonly TradelinkContext _db;

    public RequestController (TradelinkContext db) {
      _db = db;
    }

    [HttpGet]
    public IEnumerable<object> Get()
    {
      var requests = _db.Users.ToList();
      return requests;
    }
  }
}