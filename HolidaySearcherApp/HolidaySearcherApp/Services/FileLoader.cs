namespace HolidaySearcherApp.Services
{
    public static class FileLoader
    {
        public static string PathToFile { get; private set; } = string.Empty;
        public static string Path(string filename)
        {
            var currentDir = Directory.GetCurrentDirectory();

            PathToFile = (currentDir.ToLower().Contains(@"\bin\debug") || currentDir.ToLower().Contains(@"\bin\release")) ?
                 Directory.GetParent(currentDir)!.Parent!.Parent!.FullName + $"\\Data\\{filename}".ToString() :
                 $"{currentDir}\\Data\\{filename}".ToString();

            return File.Exists(PathToFile) ? PathToFile : string.Empty;
        }

        public static string Load(string file) =>
            File.ReadAllText(file);
    }
}