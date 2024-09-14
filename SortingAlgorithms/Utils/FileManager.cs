namespace SortingAlgorithms.Utils;

public class FileManager
{
    private readonly string _directoryPath;
    
    public FileManager(string directoryPath)
    {
        _directoryPath = directoryPath;
        ValidateDirectoryPath();
    }
    
    private void ValidateDirectoryPath()
    {
        if (!Directory.Exists(_directoryPath))
        {
            throw new DirectoryNotFoundException($"Directory not found: {_directoryPath}");
        }
    }
    
    public void SaveIntegerArrayToFile(int[] array, string fileName)
    {
        string filePath = Path.Combine(_directoryPath, fileName);
        File.WriteAllLines(filePath, Array.ConvertAll(array, x => x.ToString()));
    }
    
    public int[] LoadIntegerArrayFromFile(string fileName)
    {
        string filePath = Path.Combine(_directoryPath, fileName);
        string[] lines = File.ReadAllLines(filePath);
        return Array.ConvertAll(lines, int.Parse);
    }
}