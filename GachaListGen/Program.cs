var srcDirPath = args.FirstOrDefault();
if (!Directory.Exists(srcDirPath))
{
    Console.WriteLine("not found.");
    Environment.Exit(1);
}

var key = args.ElementAtOrDefault(1);
if (string.IsNullOrWhiteSpace(key))
{
    Console.WriteLine($"invalid key. [{key}]");
    Environment.Exit(1);
}

var baseUrl  = args.ElementAtOrDefault(2);
if (string.IsNullOrWhiteSpace(baseUrl))
{
    Console.WriteLine($"invalid base url. [{baseUrl}]");
    Environment.Exit(1);
}

var savePath = Path.Combine(Environment.CurrentDirectory, "list.csv");
var srcDir = new DirectoryInfo(srcDirPath);
var files = srcDir.GetFiles("*.*", SearchOption.TopDirectoryOnly);
var lines = files.Select(e => string.Join(",",key,Path.GetFileNameWithoutExtension(e.Name).Replace("_"," "),baseUrl + e.Name));
File.WriteAllLines(savePath, lines);
Environment.Exit(0);