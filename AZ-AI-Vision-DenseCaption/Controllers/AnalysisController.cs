using AZ_AI_Vision_DenseCaption.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AZ_AI_Vision_DenseCaption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController(IVisionService visionService) : ControllerBase
    {
        [HttpPost("DenseCaptions")]
        public async Task<IActionResult> GetDenseCaptions([FromBody] string imageUrl)
        {
            var result = await visionService.GetDenseCaptionsAsync(imageUrl);
            return Content(result, "application/json");
        }
    }
}
