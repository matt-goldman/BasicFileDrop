namespace BasicFileDrop.Services;

public class UploadService
{
    private readonly IWebHostEnvironment _environment;

    public UploadService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> Upload(string fileName, Stream fileData)
    {
        if (fileName == null || fileData.Length == 0)
            return "No file uploaded.";

        var uploadPath = Path.Combine(_environment.ContentRootPath, "UploadedFiles");
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        var filePath = Path.Combine(uploadPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await fileData.CopyToAsync(stream);
        }

        return filePath;
    }
}
