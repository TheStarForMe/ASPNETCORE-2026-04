using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers {
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase {

        [HttpGet("{name}")]
        public ActionResult GetFile(string name) {
            var path = Path.Combine("Files", name);

            if (!System.IO.File.Exists(path)) {
                return NotFound();
            }

            var data = System.IO.File.ReadAllBytes(path);

            return File(data, "text/plain", name);
        }
    }
}
