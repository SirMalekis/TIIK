using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork
{
    internal class WorkWithCodesOfLetters
    {
        public string[] arrayOfLettersCodes = new string[33];

        public int SequenceDivision(int leftSide, int rightSide, double[] frequenciesOfLetters)
        {
            int divisionFlag;
            double firstHalfScore = 0;

            for (int i = leftSide; i <= rightSide - 1; i++)
            {
                firstHalfScore = firstHalfScore + frequenciesOfLetters[i];
            }

            double secondHalfScore = frequenciesOfLetters[rightSide];
            divisionFlag = rightSide;

            while (firstHalfScore >= secondHalfScore)
            {
                divisionFlag = divisionFlag - 1;
                firstHalfScore = firstHalfScore - frequenciesOfLetters[divisionFlag];
                secondHalfScore = secondHalfScore + frequenciesOfLetters[divisionFlag];
            }
            return divisionFlag;
        }

        public void FanoCoding(int leftSide, int rightSide, double[] frequenciesOfLetters)
        {
            int numOfLetter;

            if (leftSide < rightSide)
            {
                numOfLetter = SequenceDivision(leftSide, rightSide, frequenciesOfLetters);
                for (int i = leftSide; i <= rightSide; i++)
                {
                    if (i <= numOfLetter) arrayOfLettersCodes[i] += Convert.ToByte(0);
                    else arrayOfLettersCodes[i] += Convert.ToByte(1);
                }

                FanoCoding(leftSide, numOfLetter, frequenciesOfLetters);
                FanoCoding(numOfLetter + 1, rightSide, frequenciesOfLetters);

            }
        }
    }
}
