using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzerProject
{
    internal class CsvFileAnalyzer:FileAnalyzer, IFileAnalysis 
    {
        public void AnalyzeFile(FileInfo fileInfo)
        {
            string[] FileString = File.ReadAllLines(fileInfo.FullName);
            AnalysisResults results = new AnalysisResults();
            var RawElements = FileString[0].Split(',');
            results.FieldCount = RawElements.Length;
            SetResults(results);
        }
    }
}
