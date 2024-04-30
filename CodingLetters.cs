using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWork
{
    internal class CodingLetters
    {

        public string[] Res = new string[32];
        public int Delenie_Posledovatelnosty(int L, int R, double[] frequenciesOfLetters)
        {
            int m;
            double schet1 = 0;

            for (int i = L; i <= R - 1; i++)
            {
                schet1 = schet1 + frequenciesOfLetters[i];
            }

            double schet2 = frequenciesOfLetters[R];
            m = R;
            while (schet1 >= schet2)
            {
                m = m - 1;
                schet1 = schet1 - frequenciesOfLetters[m];
                schet2 = schet2 + frequenciesOfLetters[m];
            }
            return m;
        }

        public void Fano(int L, int R, double[] frequenciesOfLetters)
        {
            int n;

            if (L < R)
            {

                n = Delenie_Posledovatelnosty(L, R, frequenciesOfLetters);
                Console.WriteLine(n);
                for (int i = L; i <= R; i++)
                {
                    if (i <= n) Res[i] += Convert.ToByte(0);
                    else Res[i] += Convert.ToByte(1);
                }

                Fano(L, n, frequenciesOfLetters);
                Fano(n + 1, R, frequenciesOfLetters);

            }
        }

    }
}
