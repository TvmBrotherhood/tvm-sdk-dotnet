namespace TvmSdk.ClientGenerator.Utils;

internal class FileWriter : IDisposable
{
    private readonly FileStream _fileStream;
    public readonly StreamWriter StreamWriter;

    internal FileWriter(string filePath)
    {
        var file = new FileInfo(filePath);
        var directory = file.Directory;
        if (!directory!.Exists) directory.Create();

        _fileStream = file.Exists
            ? file.Open(FileMode.Truncate)
            : file.Create();
        StreamWriter = new StreamWriter(_fileStream);
    }

    public void Dispose()
    {
        StreamWriter.Dispose();
        _fileStream.Dispose();
    }
}