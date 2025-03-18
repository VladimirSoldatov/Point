using System.Globalization;

DriveInfo [] driveInfo = DriveInfo.GetDrives();

Dictionary<string, int> words = new Dictionary<string, int>();
words.Add("Корова", 0);
words.Add("Трава", 0);

foreach (DriveInfo drive in driveInfo)
{
    if(drive.IsReady)
    Console.WriteLine($"{drive.Name}");
}
string path = "D:\\1";
Console.WriteLine(path);
List<string> file_names = new List<string>();
DirectoryInfo directoryInfo = new DirectoryInfo(path);
foreach(FileInfo item in directoryInfo.EnumerateFiles())
{
    file_names.Add(item.FullName);
}

foreach(string name in file_names)
{
    string text;
    using (StreamReader streamReader = new StreamReader(name))
    {
        text = streamReader.ReadToEndAsync().Result;
    }
    File.Copy(name, $"{name}.old",true);

    text.Replace("", "",true,CultureInfo.CurrentCulture);

    using (StreamWriter streamWriter = new StreamWriter(name))
    {
        streamWriter.WriteLine();
    }
}

