using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoursWork
{
    internal class WorkWithLetters
    {
        private readonly WorkWithText _texts;
        public WorkWithLetters(WorkWithText texts)
        {
            _texts = texts;
        }

        public void OutputCountLettersInText(string nameOfText)
        {
            var text = _texts.ReadFromText(nameOfText);
            int countLeterInText = text.Length;

            if (nameOfText == "ArtisticText.txt")
                Console.WriteLine($"Кол-во символов в художественном тексте: {countLeterInText}");
            else if (nameOfText == "ScientisticText.txt")
                Console.WriteLine($"Кол-во символов в научном тексте: {countLeterInText}");
            else{
                Console.WriteLine("Некорректный входной файл, проверьте правильность названия файла!");
            }
        }

        public void FrequenciesOfLetters(string nameOfTextWithLowLetters)
        {
            if (nameOfTextWithLowLetters == _texts.nameOfArtisticText)
                nameOfTextWithLowLetters = "LowArtisticText.txt";
            else if (nameOfTextWithLowLetters == _texts.nameOfScientisticText)
                nameOfTextWithLowLetters = "LowScientisticText.txt";
            else{
                Console.WriteLine("Некорректный входной файл, проверьте правильность названия файла!");
            }

            //string text = _texts.ReadFromText(nameOfTextWithLowLetters);
            //var FreqLetters = text.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            //foreach (var entry in FreqLetters)
            //{
            //    Console.WriteLine($"{entry.Key}: {entry.Value}");
            //}
            
            string text = _texts.ReadFromText(nameOfTextWithLowLetters);
            int totalNumberOfLettersInText = text.Length;
            var countOfLetter = text.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var sortedCountOfLetter = countOfLetter.OrderByDescending(x => x.Value).ToList();

            Console.WriteLine("\nКол-во каждой буквы:");
            foreach (var entry in sortedCountOfLetter)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            var sortedFreqLetters = sortedCountOfLetter.Select(x => new KeyValuePair<char, double>(x.Key, (double)x.Value / totalNumberOfLettersInText)).ToList();
            Console.WriteLine("\nЧастоты каждой буквы:");
            foreach (var entry in sortedFreqLetters)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
     
        }
    }
}

