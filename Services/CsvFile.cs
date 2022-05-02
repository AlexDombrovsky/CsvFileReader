using System.Collections;
using CsvFileReaderApp.Interfaces;

namespace CsvFileReaderApp.Services;

public class CsvFile : ICsvFile
{
    public List<CsvRow> CsvRows;

    #region Get a count of rows

    public int RowsCount { get; set; }

    #endregion

    #region Get a collection of columns

    public IEnumerable<string> Columns { get; set; }

    #endregion

    #region Get specific row by Index

    public ICsvRow this[int rowIndex]
    {
        get { return CsvRows.FirstOrDefault(_ => _.RowIndex == rowIndex); }
    }

    #endregion

    #region Enumerate rows

    public IEnumerator<ICsvRow> GetEnumerator()
    {
        return CsvRows.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}