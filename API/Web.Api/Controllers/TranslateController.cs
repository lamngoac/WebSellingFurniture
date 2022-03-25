using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class TranslateController : Controller
    {
        /// <summary>
        /// Dịch
        /// </summary>
        /// <param name="language"> language code dịch</param>
        /// <param name="text">đoạn text cần dịch</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> TranslateTextAsync([FromQuery]string language, [FromQuery] string text)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://translate.yandex.net/api/v1.5/tr.json/translate?key=trnsl.1.1.20211006T140319Z.b89d33570fe38b42.8737c9bb5d2c3775ed114221fb5dd83880963ddc&lang=" + language+"&text="+text))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(apiResponse))
                    {
                        return Ok(apiResponse);
                    }
                    return NoContent();
                }
            }
        }
    }
}
