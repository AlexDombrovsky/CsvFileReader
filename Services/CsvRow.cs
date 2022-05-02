using System.Collections;
using CsvFileReaderApp.Interfaces;

namespace CsvFileReaderApp.Services;

public class CsvRow : ICsvRow
{
    public IEnumerable<(string column, string value)> Cells;

    public int RowIndex { get; set; }


    #region Get value by column name

    public string this[string columnName]
    {
        get { return Cells.FirstOrDefault(_ => _.column == columnName).value; }
    }

    #endregion

    #region Enumerate values (as column-value tuples)

    public IEnumerator<(string column, string value)> GetEnumerator()
    {
        return Cells.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}