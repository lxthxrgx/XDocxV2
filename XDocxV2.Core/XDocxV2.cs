using System.Xml;
using XDocxV2.Core.XmlWorker;
using XDocxV2.Core.FileWorker;

namespace XDocxV2.Core;

public class XDocxV2Document
{
    public string PathToTemplate { get; set; }
    public OutputPath PathToSave { get; set; }

    private XDocxV2Document(string pathToTemplate, string pathToSave, string fileName)
    {
        PathToTemplate = pathToTemplate;
        PathToSave = OutputPath.Init(pathToSave, fileName);
    }

    public static XDocxV2Document Init(string pathToTemplate, string pathToSave, string fileName)
    {
        return new XDocxV2Document(pathToTemplate, pathToSave, fileName);
    }
    public void Read()
    {
        try
        {
            IFileWorkerService fw = new();
            Console.WriteLine("PATH TO TEMPLATE" + PathToTemplate);
            string xml = fw.Extract(PathToTemplate);

            XmlWorkerService xw = new();

            var dict = xw.Read(xml);

            foreach (var DataToPrint in dict)
            {
                Console.WriteLine($"Key: {DataToPrint.Key} \nXmlNode: {DataToPrint.Value.InnerXml}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ex read: " + ex);
        }
    }
}
