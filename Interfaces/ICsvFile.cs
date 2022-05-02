namespace CsvFileReaderApp.Interfaces;

public interface ICsvFile : IEnumerable<ICsvRow>
{
    int RowsCount { get; }
    IEnumerable<string> Columns { get; }
    ICsvRow this[int rowIndex] { get; }
}