using System.Xml;

namespace XDocxV2.Core.XmlWorker;

public interface IXmlWorker
{
    void Read(string xml);
    (string, int) Write();
}

public class XmlWorkerService
{
    public Dictionary<string, XmlNode> Read(string xml)
    {
        if (string.IsNullOrWhiteSpace(xml))
            throw new ArgumentException("XML is empty", nameof(xml));

        var xdict = new Dictionary<string, XmlNode>();
        var xdoc = new XmlDocument();
        xdoc.LoadXml(xml);

        var nsm = new XmlNamespaceManager(xdoc.NameTable);
        nsm.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");

        XmlNodeList? sdts = xdoc.SelectNodes("//w:sdt", nsm);
        if (sdts is null)
            throw new InvalidOperationException("Something is wrong with the XML structure");

        foreach (XmlNode sdt in sdts)
        {
            XmlNode? tagNode = sdt.SelectSingleNode("w:sdtPr/w:tag", nsm);
            string? tag = tagNode?.Attributes?["w:val"]?.Value;

            if (!string.IsNullOrEmpty(tag))
                xdict[tag] = sdt;
        }
        return xdict;
    }


}
