


using XDocxV2.Core;

namespace XDocxV2.CLI;

public class XDocxV2
{
    public static void Main()
    {
        var xdocx = XDocxV2Document.Init("/home/ltx/Dev/temp/tmp.docx", "/home/ltx/Dev/temp", "FromXdocx.docx");

        xdocx.Read();
    }
}
