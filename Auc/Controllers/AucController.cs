using Auc.Common.Authrization;
using Auc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auc.Controllers
{
    [ApiController]
    [Route("Auc")]
    public class AucController : ControllerBase
    {
        [HttpGet]
        [Authorize(AuthorizationPolicies.Admin)]
        public ActionResult<IEnumerable<AucDto>> Get()
        {
            var aucList = new List<AucDto>
                {
                    new AucDto(1, "Item 1"),
                    new AucDto(2, "Item 2"),
                    new AucDto(3, "Item 3")
                };

            return Ok(aucList);
        }
    }
}
