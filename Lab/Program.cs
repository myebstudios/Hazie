using System.Collections.ObjectModel;
using Lab.Entities;

// Done: Fix Variable names
string TargetDirectory = "C:/Users/esoebfildine/Downloads";
Collection<FileOption> FileOptions = new Collection<FileOption>();

AddFileOption("Images", ".jpeg, .svg, .png", "C:/Users/esoebfildine/Images");
AddFileOption("Videos", ".avi, .mp4, .mov", "C:/Users/esoebfildine/Videos");
AddFileOption("Audios", ".mp3, .ogg, .wav", "C:/Users/esoebfildine/Audios");

Clean();

// Add file options
void AddFileOption(string name, string extensions, string destDirectory)
{
  FileOptions.Add(new FileOption(name, extensions, destDirectory));
}

// Cleaning method
void Clean()
{
  Collection<HzFile> files = GetFiles(TargetDirectory);

  foreach (var file in files)
  {
    Console.WriteLine($"{file.Name} | {file.Extension.Text}");
    foreach (var fileOption in FileOptions)
    {
      foreach (var extension in fileOption.Extensions)
      {
        if (file.Extension.Text == extension.Text)
        {
          MoveFile(file, fileOption);
        } // Todo: Display files with no destination
      }
    }
  }
}

// Todo: Get files from target directory
Collection<HzFile> GetFiles(string targetDirectory)
{
  return new Collection<HzFile>
  {
    new HzFile($"{TargetDirectory}/image1.PNG"),
    new HzFile($"{TargetDirectory}/image2.jpeg"),
    new HzFile($"{TargetDirectory}/image2.svg"),
    new HzFile($"{TargetDirectory}/video1.avi"),
    new HzFile($"{TargetDirectory}/audio1.mp3"),
  };
}

// Todo: Move file to destination directory
void MoveFile(HzFile file, FileOption fileOption)
{
  Console.WriteLine($"Moved {file.Name} to {fileOption.DestDirectory}");
}