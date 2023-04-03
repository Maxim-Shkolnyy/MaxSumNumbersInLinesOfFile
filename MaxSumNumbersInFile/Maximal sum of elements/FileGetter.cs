using System;
using System.IO;
namespace Maximal_sum_of_elements;

public class FileGetter: IFileGetter
{
    public string[] GetStringsFromFile(string path)
    {
        if (String.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }
        string[] stringArray = File.ReadAllLines(path);
        return stringArray;
    }

    public bool FileExist(string inputpath)
    {
        return File.Exists(inputpath);
    }
}