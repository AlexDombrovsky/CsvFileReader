namespace CsvFileReaderApp.Interfaces;

public interface ICsvRow : IEnumerable<(string column, string value)>
{
    string this[string columnName] { get; }
}