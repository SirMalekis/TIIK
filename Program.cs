using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork
{
    public class Programm
    {
        static void Main(string[] args) 
        {
            var texts = new WorkWithText();
            var letters = new WorkWithLetters(texts);
            string nameOfText = "NULL";
            string nameOfArtisticText = "ArtisticText.txt";
            string nameOfScientisticText = "ScientisticText.txt";
            int i = 0;

            //Можно сделать что-то типо менюшки с выбором текста, для которого будет производится анализ и работа с ним;
            //Console.WriteLine("С каким текстом хотите работать?");
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
                    Console.Write("Введие значение: ");
                    typeOfText = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
            } while(i != typeOfText);

            texts.WriteToFileConvertedTexts(nameOfText);
            letters.OutputCountLettersInText(nameOfText);
            letters.FrequenciesOfLetters(nameOfText);
            
        }

    }
}