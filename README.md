# CSV to JSON Converter

## Overview
This C# script, `CSVtoJSON.cs`, converts CSV data to JSON format, providing data cleaning and preprocessing options. Each record is saved as a separate JSON file in a designated folder.

## Features
- Reads data from a CSV file
- Preprocesses and cleans the data
- Converts cleaned data to JSON format
- Stores each record as a separate JSON file

## Usage
1. Place your CSV file in the `data` folder.
2. Compile and run the C# script `CSVtoJSON.cs`.
3. JSON files will be generated in the `output` folder.

## Requirements
- .NET Core SDK
- Libraries: CsvHelper, Newtonsoft.Json

## Example
```bash
dotnet run CSVtoJSON.cs
```
