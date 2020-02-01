using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Tradelink.Web.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RequestController : ControllerBase
  {
    [HttpGet]
    public IEnumerable<object> Get() {
      return Enumerable.Range(1, 5).Select(index => new {
        Name = "name",
        Date = new DateTime(),
        Active = true
      });
    }
  }
}