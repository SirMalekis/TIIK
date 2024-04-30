using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork
{
    public class Programm
    {
        static void Main(string[] args)
        {
            WorkWithText texts = new WorkWithText();
            TextAnalysis letters = new TextAnalysis(texts);
            WorkWithCodesOfLetters codes = new WorkWithCodesOfLetters();
            QuantitativeCharacteristicsOfTheCode characteristics = new QuantitativeCharacteristicsOfTheCode(codes);

            string nameOfText = "NULL";
            string nameOfArtisticText = "ArtisticText.txt";
            string nameOfScientisticText = "ScientisticText.txt";
            int i = 0;

            Console.WriteLine("С каким текстом хотите работать?" +
                "\n1) Художественный текст - Мастер и Маргарита глава 1 --- ВВЕДИТЕ 1" +
                "\n2) Научный текст - Флотация и ее применение для очистки сточных вод --- ВВЕДИТЕ 2" +
                "\n3) Чтобы закончить работу введите 3");
            Console.Write("Введие значение: ");
            int typeOfText = int.Parse(Console.ReadLine());
            Console.WriteLine();

            do
            {
                if (typeOfText == 1)
                {
                    nameOfText = nameOfArtisticText;
                    i = typeOfText;
                }

                else if (typeOfText == 2)
                {
                    nameOfText = nameOfScientisticText;
                    i = typeOfText;
                }

                else if (typeOfText == 3)
                    Environment.Exit(0);
                else
                {
                    Console.WriteLine("Введите число из предложенных!");
                    Console.Write("Введите значение: ");
                    typeOfText = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
            } while (i != typeOfText);

            texts.WriteToFileConvertedTexts(nameOfText);

            int countLettersInText = letters.CountLettersInText(nameOfText);
            Console.Write($"Кол-во букв в тексте: {countLettersInText}");

            Console.WriteLine("\n");

            char[] arrayOfLettersItSelf = letters.ArrayOfLettersItSelf(nameOfText);
            int[] numOfEachLetter = letters.NumOfEachLetter(nameOfText);
            double[] frequenciesOfLetters = letters.FrequencyOfEachLetter(nameOfText);

            Console.WriteLine("Кол-во каждой буквы текста:");
            for (i = 0; i < arrayOfLettersItSelf.Length; i++)
            {
                Console.WriteLine($"{arrayOfLettersItSelf[i]} : {numOfEachLetter[i]}");
            }

            Console.WriteLine();

            Console.WriteLine("Частота каждой буквы текста:");
            for (i = 0; i < arrayOfLettersItSelf.Length; i++)
            {
                Console.WriteLine($"{arrayOfLettersItSelf[i]} : {frequenciesOfLetters[i]}");
            }

            Console.WriteLine("\n{0,6} |  {1,6}     | {2,12}  |{3,19}      |{4,17}        |{5,16}", "Буква", "Код", "Длина кода", "Средняя длина", "Энтропия", "Вектор крафта");

            int lenghtOfTheCode = 0;
            double avgLenghtOfCode = 0;
            double avgMinLenghtOfCode = 0;
            double fullEntropy = 0;
            double redundancyOfCode = 0;
            double redundancyOfAlphabet = 0;
            double compressionRatio = 0;
            double singleCraftsVector = 0;
            double craftsVector = 0;
            int alphabetPower = 2;

            if (typeOfText == 1)
            {
                string nameOfTextWithLowLetters = "LowArtisticText.txt";
                int countLettersOfAlphabet = 32;
                double[] avgLenght = new double[countLettersOfAlphabet];
                double[] arrayOfEntropies = new double[countLettersOfAlphabet];
                

                codes.FanoCoding(0, 31, frequenciesOfLetters);

                for (i = 0; i < 32; i++)
                {
                    lenghtOfTheCode = characteristics.LengthOfTheCode(i, countLettersOfAlphabet);
                    avgLenght[i] = characteristics.AvgLenght(i, nameOfTextWithLowLetters, countLettersOfAlphabet, frequenciesOfLetters);
                    arrayOfEntropies[i] = characteristics.ArrayOfEntropy(i, nameOfTextWithLowLetters, countLettersOfAlphabet, frequenciesOfLetters);
                    singleCraftsVector = characteristics.SingleCraftsVector(i, countLettersOfAlphabet);

                    avgLenghtOfCode = avgLenghtOfCode + avgLenght[i];
                    fullEntropy = fullEntropy + arrayOfEntropies[i];
                    avgMinLenghtOfCode = fullEntropy / Math.Log2(alphabetPower);
                    redundancyOfCode = (avgLenghtOfCode - fullEntropy) / avgLenghtOfCode;
                    redundancyOfAlphabet = (Math.Log2(countLettersInText) - fullEntropy) / Math.Log2(countLettersInText);
                    compressionRatio = fullEntropy / avgLenghtOfCode;
                    craftsVector = craftsVector + singleCraftsVector;

                    Console.WriteLine("{0,4}   |{1,10}   |{2,8}       |{3,22}   |{4,22}   |{5,13}", arrayOfLettersItSelf[i], codes.arrayOfLettersCodes[i], lenghtOfTheCode,
                        avgLenght[i], arrayOfEntropies[i], singleCraftsVector);
                }

                Console.WriteLine();
                Console.WriteLine($"Средняя длина кода = {avgLenghtOfCode}");
                Console.WriteLine($"Полная энтропия = {fullEntropy}");
                Console.WriteLine($"Средняя минимальная длина кода = {avgMinLenghtOfCode}");
                Console.WriteLine($"Избыточность кода = {redundancyOfCode}");
                Console.WriteLine($"Избыточность алфавита = {redundancyOfAlphabet}");
                Console.WriteLine($"Коэффициент сжатия = {compressionRatio}");
                Console.WriteLine($"Вектор крафта = {craftsVector}");
            }
            else if (typeOfText == 2)
            {
                string nameOfTextWithLowLetters = "LowScientisticText.txt";
                int countLettersOfAlphabet = 33;
                double[] avgLenght = new double[countLettersOfAlphabet];
                double[] arrayOfEntropies = new double[countLettersOfAlphabet];

                codes.FanoCoding(0, 32, frequenciesOfLetters);

                for (i = 0; i < 33; i++)
                {
                    lenghtOfTheCode = characteristics.LengthOfTheCode(i, countLettersOfAlphabet);
                    avgLenght[i] = characteristics.AvgLenght(i, nameOfTextWithLowLetters, countLettersOfAlphabet, frequenciesOfLetters);
                    arrayOfEntropies[i] = characteristics.ArrayOfEntropy(i, nameOfTextWithLowLetters, countLettersOfAlphabet, frequenciesOfLetters);
                    singleCraftsVector = characteristics.SingleCraftsVector(i, countLettersOfAlphabet);

                    avgLenghtOfCode = avgLenghtOfCode + avgLenght[i];
                    fullEntropy = fullEntropy + arrayOfEntropies[i];
                    avgMinLenghtOfCode = fullEntropy / Math.Log2(alphabetPower);
                    redundancyOfCode = (avgLenghtOfCode - fullEntropy) / avgLenghtOfCode;
                    redundancyOfAlphabet = (Math.Log2(countLettersInText) - fullEntropy) / Math.Log2(countLettersInText);
                    compressionRatio = fullEntropy / avgLenghtOfCode;
                    craftsVector = craftsVector + singleCraftsVector;

                    Console.WriteLine("{0,4}   |{1,10}   |{2,8}       |{3,22}   |{4,22}   |{5,13}", arrayOfLettersItSelf[i], codes.arrayOfLettersCodes[i], lenghtOfTheCode,
                        avgLenght[i], arrayOfEntropies[i], singleCraftsVector);
                }

                Console.WriteLine();
                Console.WriteLine($"Средняя длина кода = {avgLenghtOfCode}");
                Console.WriteLine($"Полная энтропия = {fullEntropy}");
                Console.WriteLine($"Средняя минимальная длина кода = {avgMinLenghtOfCode}");
                Console.WriteLine($"Избыточность кода = {redundancyOfCode}");
                Console.WriteLine($"Избыточность алфавита = {redundancyOfAlphabet}");
                Console.WriteLine($"Коэффициент сжатия = {compressionRatio}");
                Console.WriteLine($"Вектор крафта = {craftsVector}");
            }
        }
    }
}