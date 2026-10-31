using System;
using System.Net.NetworkInformation;

namespace OE.ALGA.Optimalizalas
{
    // 8. heti labor feladat - Tesztek: 08_DinamikusProgramozasTesztek.cs

    public class DinamikusHatizsakPakolas
    {
        HatizsakProblema problema;

        public int LepesSzam { get; set; }


        public DinamikusHatizsakPakolas(HatizsakProblema problema)
        {
            this.problema = problema;
            LepesSzam = 0;
        }

        public float[,] TablazatFeltoltes()
        {
            float[,] F = new float[problema.n + 1, problema.Wmax + 1];

            for (int i = 0; i < problema.n + 1; i++)
            {
                F[i, 0] = 0;
                
            }
            for (int j = 0; j < problema.Wmax + 1; j++)
            {
                F[0, j] = 0;
                
            }

            for (int t = 1; t <= problema.n; t++)
            {
                for (int h = 1; h <= problema.Wmax; h++)
                {
                    if (h >= problema.w[t - 1])
                    {
                        
                        F[t, h] = Math.Max(F[t - 1, h], F[t - 1, h - problema.w[t - 1]] + problema.p[t - 1]);
                    }
                    else
                    {
                        F[t, h] = F[t - 1, h];
                    }
                    LepesSzam++;
                }
            }
            return F;
        }

        public float OptimalisErtek()
        {
            float[,] F = TablazatFeltoltes();
            return F[problema.n, problema.Wmax];
        }

        public bool[] OptimalisMegoldas()
        {
            float[,] F = TablazatFeltoltes();
            bool[] eredmeny = new bool[problema.n];

            for (int i = 0; i < problema.n; i++)
            {
                eredmeny[i] = false;
                
            }

            int t = problema.n;
            int h = problema.Wmax;

            while (t > 0 && h > 0)
            {
                if (F[t, h] != F[t - 1, h])
                {
                    eredmeny[t - 1] = true;
                    h = h - problema.w[t - 1];
                }
                t = t - 1;
                
            }
            return eredmeny;
        }




    }
}
