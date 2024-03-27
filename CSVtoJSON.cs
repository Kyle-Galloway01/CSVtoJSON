using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // Path to the CSV file
        string csvFilePath = @"C:\Data\input.csv";

        // Create a folder to store output JSON files
        string outputFolderPath = @"C:\Data\OutputJSON";
        Directory.CreateDirectory(outputFolderPath);

        // Read data from CSV file
        List<Dictionary<string, string>> records = ReadCSVFile(csvFilePath);

        // Preprocess and clean the data
        List<Dictionary<string, string>> cleanedRecords = PreprocessAndCleanData(records);

        // Convert cleaned data to JSON format and store each record in a separate file
        StoreJSONFiles(cleanedRecords, outputFolderPath);

        Console.WriteLine("Conversion completed. JSON files are stored in the output folder.");
    }

    // Read data from CSV file
static List<Dictionary<string, string>> ReadCSVFile(string filePath)
{
    using (var reader = new StreamReader(filePath))
    using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
    {
        csv.Configuration.HasHeaderRecord = true;
        var records = csv.GetRecords<dynamic>();
        List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>>();
        foreach (var record in records)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (var field in record)
            {
                // Check for null values before converting to string
                string value = field.Value != null ? field.Value.ToString() : null;
                data.Add(field.Key, value);
            }
            dataList.Add(data);
        }
        return dataList;
    }
}


    // Preprocess and clean the data
    static List<Dictionary<string, string>> PreprocessAndCleanData(List<Dictionary<string, string>> records)
    {
        // Your preprocessing and cleaning logic goes here
        // For example, removing empty or invalid records, correcting data formats, etc.
        return records;
    }

    // Convert cleaned data to JSON format and store each record in a separate file
    static void StoreJSONFiles(List<Dictionary<string, string>> records, string outputFolderPath)
    {
        for (int i = 0; i < records.Count; i++)
        {
            string json = JsonConvert.SerializeObject(records[i], Formatting.Indented);
            string outputFilePath = Path.Combine(outputFolderPath, $"output_{i}.json");
            File.WriteAllText(outputFilePath, json);
        }
    }
}
