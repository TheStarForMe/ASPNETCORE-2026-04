using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Demo1.Controllers {
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase {
        private FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider) {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }

        [HttpGet("{name}")]
        public ActionResult GetFile(string name) {
            var path = Path.Combine("Files", name);

            if (!System.IO.File.Exists(path)) {
                return NotFound();
            }

            var data = System.IO.File.ReadAllBytes(path);

            if (!_fileExtensionContentTypeProvider.TryGetContentType(path, out var mimeType)) {
                mimeType = "application/octet-stream";
            }

            return File(data, mimeType, name);
        }
    }
}
