using Microsoft.AspNetCore.Mvc;
using Tutorium.Shared.Utils.Controllers;

namespace Tutorium.UserService.Api.Controllers
{
    public class InfoController : BaseController
    {
        /// <summary>
        /// Получение информации
        /// </summary>
        [HttpGet(template: "version")]
        public async Task<ActionResult<string>> GetCounterObjectMeasuringValues()
        {
            return "User Service 1.1";
        }
    }
}
