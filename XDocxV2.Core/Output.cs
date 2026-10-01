namespace XDocxV2.Core;

public sealed class OutputPath
{
    public string Path { get; }
    public string Name { get; }

    public string FullPath => System.IO.Path.Combine(Path, Name);

    private OutputPath(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public static OutputPath Init(string path, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        return new OutputPath(path, name);
    }
}
