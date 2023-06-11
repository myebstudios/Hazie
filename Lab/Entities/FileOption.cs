using System.Collections.ObjectModel;

namespace Lab.Entities;

public class FileOption
{
  public int Id { get; }
  public string Name { get; set; }
  public Collection<HzExtension> Extensions = new Collection<HzExtension>();
  public string DestDirectory { get; set; }

  public FileOption(string name, string extensions, string destDirectory)
  {
    Id = this.GetHashCode();
    Name = name;
    DestDirectory = destDirectory;
    
    SetExtentions(extensions);
  }

  public void Update(string name, string extensions, string destDirectory)
  {
    Name = name;
    DestDirectory = destDirectory;
    
    SetExtentions(extensions);
  }
  
  private void SetExtentions(string extensions)
  {
    var extensionsText = extensions.Split(",");
    Collection<HzExtension> tempExtensions = new Collection<HzExtension>();

    foreach (var extension in extensionsText)
    {
      tempExtensions.Add(new HzExtension(extension.Trim()));
    }

    Extensions = tempExtensions;
  }
}