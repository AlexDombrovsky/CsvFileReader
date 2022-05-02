namespace CsvFileReaderApp.Interfaces;

public interface ICsvFileReader
{
    Task<ICsvFile> ReadFileAsync(string fileName);
}