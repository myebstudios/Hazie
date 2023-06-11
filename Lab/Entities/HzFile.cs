namespace Lab.Entities;

public class HzFile
{
  public string Path { get; set; }
  public string Name { get; }
  public HzExtension Extension { get; }

  public HzFile(string path)
  {
    Path = path;
    Name = GetFileName();
    Extension = GetFileExtension();
  }
  
  // Done: Get file name from "C:/Users/esoebfildine/Downloads/image1.png" 
  private string GetFileName()
  {
    var newName = Path.Split('/').Last().Split('.').First();
    return newName;
  }
  
  // Done: Get file extension
  private HzExtension GetFileExtension()
  {
    var ext = Path.Split('/').Last().Split('.').Last().ToLower();
    return new HzExtension($".{ext}");
  }
  
}