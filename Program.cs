using CsvFileReaderApp.Interfaces;
using CsvFileReaderApp.Services;

ICsvFileReader reader = new CsvFileReader();
var csvFile = await reader.ReadFileAsync("D:\\addresses.csv");
Console.ReadLine();