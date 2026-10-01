using System.IO.Compression;

namespace XDocxV2.Core.FileWorker;

public interface IFileWorker
{
    string Extract(string pathToFile);
    string ToFile();
}

public class IFileWorkerService : IFileWorker
{
    public string Extract(string pathToFile)
    {
        try
        {

            if (string.IsNullOrWhiteSpace(pathToFile))
                throw new Exception("path to file is empty");
            var archive = ZipFile.OpenRead(pathToFile);
            var entry = archive.GetEntry("word/document.xml") ??
                throw new Exception($"word file is empty or broken: {pathToFile}");

            var reader = new StreamReader(entry.Open());
            return reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ex: {ex}");
            return ex.ToString();
        }
    }

    public string ToFile()
    {
        return string.Empty;
    }

}
