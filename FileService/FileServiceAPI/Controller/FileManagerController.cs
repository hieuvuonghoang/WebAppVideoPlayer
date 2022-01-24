using FileServiceAPI.AuthenticationCustomize;
using FileServiceAPI.Models;
using FileServiceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileServiceAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly AppSettings _appSettings;
        private readonly IMimeService _mimeService;

        public FileManagerController(IFileService fileService, IOptions<AppSettings> appSettings, IMimeService mimeService)
        {
            _fileService = fileService;
            _appSettings = appSettings.Value;
            _mimeService = mimeService;
        }

        #region "Phim ảnh"

        [HttpGet("download")]
        public ActionResult Download(string pathFile)
        {
            var path = Path.Combine(_appSettings.PhimAnhStoredFilesPath, pathFile);
            var fileName = Path.GetFileName(path);
            var mimeType = _mimeService.GetMimeType(Path.GetExtension(path));
            return PhysicalFile(path, mimeType, fileName, true);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPhimAnhAsync(IFormFile file)
        {
            var nguoiDung = (HT_NGUOIDUNG)HttpContext.Items[_appSettings.KeyNameNguoiDung];
            var pathDir = Path.Combine(_appSettings.PhimAnhStoredFilesPath, nguoiDung.MADONVI, nguoiDung.TENTK);
            if (!Directory.Exists(pathDir))
            {
                Directory.CreateDirectory(pathDir);
            }
            var pathFile = Path.Combine(pathDir, file.FileName);
            using (var fileStream = new FileStream(pathFile, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Close();
            }
            return Ok(new { fileName = file.FileName });
        }

        [HttpPost("merge")]
        public IActionResult MergeFile(MergeFileModel mergeFileModel)
        {
            var nguoiDung = (HT_NGUOIDUNG)HttpContext.Items[_appSettings.KeyNameNguoiDung];
            var pathFile = Path.Combine(_appSettings.PhimAnhStoredFilesPath, nguoiDung.MADONVI, nguoiDung.TENTK, mergeFileModel.FileName);
            var tMergeFile = _fileService.MergeFile(pathFile);
            var fileName = Path.GetFileName(tMergeFile.Item2);
            var pathFileDownload = Path.Combine(nguoiDung.MADONVI, nguoiDung.TENTK, fileName);
            var linkFile = _appSettings.LinkFileService + $"/filemanager/download-phim-anh?pathFile={pathFileDownload}";
            return Ok(new
            {
                mergeFileSuccess = tMergeFile.Item1,
                linkFile = linkFile,
            });
        }

        [HttpGet("get-all-file")]
        public ActionResult GetAllFile()
        {
            var dir = new DirectoryInfo(_appSettings.PhimAnhStoredFilesPath);
            var files = dir.GetFiles("*.mkv");
            var fileNames = new List<string>();
            foreach (var file in files)
            {
                fileNames.Add(file.Name);
            }
            return Ok(fileNames);
        }

        #endregion

        

    }
}
