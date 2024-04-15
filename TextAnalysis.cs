using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoursWork
{
    internal class TextAnalysis
    {
        private readonly WorkWithText _texts;
        public TextAnalysis(WorkWithText texts)
        {
            _texts = texts;
        }

        public int CountLettersInText(string nameOfText)
        {
            var text = _texts.ReadFromText(nameOfText);
            int countLetersInText = text.Length;

            if (nameOfText == "ArtisticText.txt")
                return countLetersInText;
            else if (nameOfText == "ScientisticText.txt")
                return countLetersInText;
            else
            {
                Console.WriteLine("Некорректный входной файл, проверьте правильность названия файла!");
                return 0;
            }
        }
        public char[] ArrayOfLettersItSelf(string nameOfTextWithLowLetters)
        {
            int countLetersInText = CountLettersInText(nameOfTextWithLowLetters);
            if (nameOfTextWithLowLetters == _texts.nameOfArtisticText)
                nameOfTextWithLowLetters = "LowArtisticText.txt";
            else if (nameOfTextWithLowLetters == _texts.nameOfScientisticText)
                nameOfTextWithLowLetters = "LowScientisticText.txt";
            else
            {
                Console.WriteLine("Некорректный входной файл, проверьте правильность названия файла!");
            }

            string text = _texts.ReadFromText(nameOfTextWithLowLetters);
            int totalNumberOfLettersInText = text.Length;
            var countOfLetter = text.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var sortedCountOfLetter = countOfLetter.OrderByDescending(x => x.Value).ToList();

            char[] letters = new char[sortedCountOfLetter.Count];

            int i = 0;
            foreach (var letterPair in sortedCountOfLetter)
            {
                char letter = letterPair.Key;

                letters[i] = letter;

                i++;
            }

            return letters;
        }

            public int[] NumOfEachLetter(string nameOfTextWithLowLetters)
        {
            int countLetersInText = CountLettersInText(nameOfTextWithLowLetters);
            if (nameOfTextWithLowLetters == _texts.nameOfArtisticText)
                nameOfTextWithLowLetters = "LowArtisticText.txt";
            else if (nameOfTextWithLowLetters == _texts.nameOfScientisticText)
                nameOfTextWithLowLetters = "LowScientisticText.txt";
            else
            {
                Console.WriteLine("Некорректный входной файл, проверьте правильность названия файла!");
            }

            string text = _texts.ReadFromText(nameOfTextWithLowLetters);
            int totalNumberOfLettersInText = text.Length;
            var countOfLetter = text.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var sortedCountOfLetter = countOfLetter.OrderByDescending(x => x.Value).ToList();

            int[] lettersCounts = new int[sortedCountOfLetter.Count];

            int i = 0;
            foreach (var letterPair in sortedCountOfLetter)
            {
                int count = letterPair.Value;

                lettersCounts[i] = count;

                i++;
            }

            return lettersCounts;


            //Console.WriteLine("\nКол-во каждой буквы:");

            //for (i = 0; i < sortedCountOfLetter.Count; i++)
            //{
            //    Console.WriteLine($"{letters[i]} : {lettersCounts[i]}");
            //}

            //Console.WriteLine();

            //foreach (var entry in sortedCountOfLetter)
            //{
            //    Console.WriteLine($"{entry.Key}: {entry.Value}");
            //}

        }

        public double[] FrequencyOfEachLetter(string nameOfTextWithLowLetters)
        {
            int countLetersInText = CountLettersInText(nameOfTextWithLowLetters);
            if (nameOfTextWithLowLetters == _texts.nameOfArtisticText)
                nameOfTextWithLowLetters = "LowArtisticText.txt";
            else if (nameOfTextWithLowLetters == _texts.nameOfScientisticText)
                nameOfTextWithLowLetters = "LowScientisticText.txt";
            else
            {
                Console.WriteLine("Некорректный входной файл, проверьте правильность названия файла!");
            }

            string text = _texts.ReadFromText(nameOfTextWithLowLetters);
            int totalNumberOfLettersInText = text.Length;
            var countOfLetter = text.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var sortedCountOfLetter = countOfLetter.OrderByDescending(x => x.Value).ToList();

            var sortedFreqOfLetters = sortedCountOfLetter.Select(x => new KeyValuePair<char, double>(x.Key, (double)x.Value / totalNumberOfLettersInText)).ToList();
            double[] lettersFreqs = new double[sortedFreqOfLetters.Count];

            int i = 0;

            foreach (var letterPair in sortedFreqOfLetters)
            {
                double count = letterPair.Value;

                lettersFreqs[i] = count;

                i++;
            }

            return lettersFreqs;

            //for (i = 0; i < sortedFreqOfLetters.Count; i++)
            //{
            //    Console.WriteLine($"{letters[i]} : {lettersFreqs[i]}");
            //}

            //Console.WriteLine();

            //foreach (var entry in sortedFreqOfLetters)
            //{
            //    Console.WriteLine($"{entry.Key} : {entry.Value}");
            //}
        }
    }
}

