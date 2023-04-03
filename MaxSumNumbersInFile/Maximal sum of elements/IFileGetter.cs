namespace Maximal_sum_of_elements;

public interface IFileGetter
{
    public string[] GetStringsFromFile(string path);
    public bool FileExist(string inputpath);

}
