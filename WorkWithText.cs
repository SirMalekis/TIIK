using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CoursWork
{
    internal class WorkWithText
    {
        public string nameOfArtisticText = "ArtisticText.txt";
        public string nameOfScientisticText = "ScientisticText.txt";

        public string ReadFromText(string nameOfText)
        {
            using (StreamReader reader = new StreamReader(nameOfText)){
                string varOfReadText = reader.ReadToEnd();
                return varOfReadText;
            }
        }

        private string ConvertTextToLowLetter(string nameOfText)
        {
            string varOfReadText = ReadFromText(nameOfText);
            string varOfReadTextLowLetters = varOfReadText.ToLowerInvariant();
            return varOfReadTextLowLetters;
        }

        public void WriteToFileConvertedTexts(string nameOfText)
        {
            string varOfReadTextLowLetters = ConvertTextToLowLetter(nameOfText);
            string nameOfArtisticTextWithLowLetters = "LowArtisticText.txt";
            string nameOfScientisticTextWithLowLetters = "LowScientisticText.txt";

            if (nameOfText == nameOfArtisticText)
                File.WriteAllText(nameOfArtisticTextWithLowLetters, varOfReadTextLowLetters);

            else if(nameOfText == nameOfScientisticText)
                File.WriteAllText(nameOfScientisticTextWithLowLetters, varOfReadTextLowLetters);

            else
            {
                Console.WriteLine("Некорректный входной файл, проверьте правильность названия файла!");
            }
        }
    }
}

