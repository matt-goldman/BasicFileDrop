namespace BasicFileDrop.Services;

public class ServerFilesService (IWebHostEnvironment environment)
{
    public List<string> GetFiles()
    {
        var uploadPath = Path.Combine(environment.ContentRootPath, "UploadedFiles");
        
        if (!Directory.Exists(uploadPath))
        {
            return [];
        }

        return [.. Directory.GetFiles(uploadPath).Select(Path.GetFileName)];
    }

    public FileStream? GetFile(string fileName)
    {
        var uploadPath = Path.Combine(environment.ContentRootPath, "UploadedFiles");
        var filePath = Path.Combine(uploadPath, fileName);
        
        if (!File.Exists(filePath))
        {
            return null;
        }

        return new FileStream(filePath, FileMode.Open);
    }
}
