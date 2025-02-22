namespace FileAnalyzerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to file analyzer");
            Console.WriteLine("Please, Enter folder path to analyze");
            string inputFolder = Console.ReadLine();
            DirectoryInfo directoryInfo = new DirectoryInfo(inputFolder);
            if (directoryInfo.Exists == false)
            {
                Console.WriteLine("Folder does not exist");
                return;   //it means-> go out of the program
            }

            var FileNames = directoryInfo.GetFiles();
            IFileAnalysis fileAnalysis = null;
            foreach (var file in FileNames)
            {
                if (file.IsTextFile())
                {
                    fileAnalysis = new TxtFileAnalyzer();


                    fileAnalysis.AnalyzeFile(file);
                    var results = ((FileAnalyzer)fileAnalysis).GetResults();
                    Console.WriteLine($"File name : {file.Name}");
                    Console.WriteLine($"Word count : {results.WordCount}");
                    Console.WriteLine($"Character count : {results.CharacterCount}");
                    Console.WriteLine($"Line count : {results.LineCount}");
                }
                else if (file.IsCsvFile())
                {
                    fileAnalysis = new CsvFileAnalyzer();


                    fileAnalysis.AnalyzeFile(file);
                    var results = ((FileAnalyzer)fileAnalysis).GetResults();
                    Console.WriteLine($"File name : {file.Name}");
                    Console.WriteLine($"Field count : {results.FieldCount}");
                }
            }
        }
        }
    }

