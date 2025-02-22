using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzerProject
{
    internal class TxtFileAnalyzer : FileAnalyzer ,IFileAnalysis
    {
        public void AnalyzeFile(FileInfo fileInfo)
        {
            string FileString = File.ReadAllText(fileInfo.FullName);
            AnalysisResults results = new AnalysisResults();
            results.CharacterCount = FileString.Length;
            var words = FileString.Split(new char[] { ' ', '\n', '\r' });
            results.WordCount = words.Length;
            var lines = FileString.Split(new char[] { '\n' });
            results.LineCount = lines.Length;
            SetResults(results);
        }
    }
}
