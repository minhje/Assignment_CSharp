using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

public class FileService : IFileService
{

    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath = "Data", string fileName = "contact_list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(directoryPath, fileName);
    }

    public string GetContentFromFile()
    {
        if (!File.Exists(_filePath))
        {
            return string.Empty;

        }

        return File.ReadAllText(_filePath);
    }

    public bool SaveContentToFile(string content)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            File.WriteAllText(_filePath, content);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}


