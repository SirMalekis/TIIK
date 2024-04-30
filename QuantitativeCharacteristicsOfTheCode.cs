using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork
{

    internal class QuantitativeCharacteristicsOfTheCode
    {
        private readonly WorkWithCodesOfLetters _codes;
        public QuantitativeCharacteristicsOfTheCode(WorkWithCodesOfLetters codes)
        {
            _codes = codes;
        }

        public int LengthOfTheCode(int i, int countLettersOfAlphabet)
        {
            int [] lengthOfTheCode = new int[countLettersOfAlphabet];
            lengthOfTheCode[i] = _codes.arrayOfLettersCodes[i].Length;
            return lengthOfTheCode[i];
        }

        public double AvgLenght(int i, string nameOfTextWithLowLetters, int countLettersOfAlphabet, double[] frequenciesOfLetters)
        {
            double [] avgLenght = new double [countLettersOfAlphabet];
            //double[] frequenciesOfLetters = _letters.FrequencyOfEachLetter(nameOfTextWithLowLetters);

            avgLenght[i] = LengthOfTheCode(i, countLettersOfAlphabet) * frequenciesOfLetters[i];
            return avgLenght[i];
        }
        public double ArrayOfEntropy(int i, string nameOfTextWithLowLetters, int countLettersOfAlphabet, double[] frequenciesOfLetters)
        {
            double [] arrayOfEntropies = new double[countLettersOfAlphabet];
            //double[] frequenciesOfLetters = _letters.FrequencyOfEachLetter(nameOfTextWithLowLetters);

            arrayOfEntropies[i] = -(Math.Log2(frequenciesOfLetters[i]) * frequenciesOfLetters[i]);
            return arrayOfEntropies[i];
        }
        public double SingleCraftsVector(int i, int countLettersOfAlphabet)
        {
            double[] singleCraftsVector = new double[countLettersOfAlphabet];
            singleCraftsVector[i] = Math.Pow(2, -LengthOfTheCode(i, countLettersOfAlphabet));
            return singleCraftsVector[i];
        }
    }
}
