using System.Text;
using CsvFileReaderApp.Interfaces;

namespace CsvFileReaderApp.Services;

public class CsvFileReader : ICsvFileReader
{
    public async Task<ICsvFile> ReadFileAsync(string fileName)
    {
        var csvFile = new CsvFile
        {
            CsvRows = new List<CsvRow>()
        };
        var lines = await File.ReadAllLinesAsync(fileName);
        var headers = lines[0].Split(",");
        var contentRows = lines.Skip(1);

        csvFile.RowsCount = contentRows.Count();

        var rowIndex = 0;
        foreach (var contentRow in contentRows)
        {
            var csvRow = new CsvRow();
            var cells = new List<(string column, string value)>();
            var columnIndex = 0;

            var splitRow = contentRow.Split(",").ToList();
            foreach (var cell in splitRow)
            {
                cells.Add(new ValueTuple<string, string>(headers[columnIndex], cell));
                columnIndex++;
            }

            csvRow.Cells = cells;
            csvRow.RowIndex = rowIndex;
            csvFile.CsvRows.Add(csvRow);
            rowIndex++;
        }

        var columnsList = new List<string>();
        for (var i = 0; i < headers.Count(); i++)
        {
            var columnString = new StringBuilder();

            foreach (CsvRow csvRow in csvFile) columnString.Append(csvRow[headers[i]] + ",");
            columnsList.Add(columnString.ToString());
        }

        csvFile.Columns = columnsList;

        return csvFile;
    }
}