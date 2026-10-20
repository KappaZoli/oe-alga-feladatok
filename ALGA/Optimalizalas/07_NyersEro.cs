using System;
using System.Diagnostics;

namespace OE.ALGA.Optimalizalas
{
    // 7. heti labor feladat - Tesztek: 07_NyersEroTesztek.cs

    public class HatizsakProblema
    {

        public readonly int n;
        public readonly int Wmax;
        public readonly int[] w;
        public readonly float[] p;

        public HatizsakProblema(int n, int wmax, int[] w, float[] p)
        {
            this.n = n;
            Wmax = wmax;
            this.w = w;
            this.p = p;
        }

        public int OsszSuly(bool[] logika)
        {
            int eredmeny = 0;
            for (int i = 0; i < n; i++)
            {
                if (logika[i])
                {
                    eredmeny += (int)w[i];
                }
            }
            return eredmeny;
        }

        public int OsszErtek(bool[] logika)
        {
            int eredmeny = 0;
            for (int i = 0; i < n; i++)
            {
                if (logika[i])
                {
                    eredmeny += (int)p[i];
                }
            }
            return eredmeny;
        }

        public bool Ervenyes(bool[] logika)
        {

            if (OsszSuly(logika) <= Wmax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class NyersEro<T>
    {
        public readonly int m;
        public Func<int, T> generator;
        public Func<T, int> josag;
        public int LepesSzam { get; set; }

        public NyersEro(int m, Func<int, T> generator, Func<T, int> josag)
        {
            this.m = m;
            this.generator = generator;
            this.josag = josag;
        }
            
        public T OptimalisMegoldas()
        {
            T o = generator(0);
            for (int i = 1; i < m; i++)
            {
                T x = generator(i);
                if(josag(x) > josag(o))
                {
                    o = x;
                }
            }
            return o;
        }

    }

    public class NyersEroHatizsakPakolas
    {
       HatizsakProblema problema;

        public NyersEroHatizsakPakolas(HatizsakProblema problema)
        {
            this.problema = problema;
        }

        public int LepesSzam { get; set; }


        public bool[] OptimalisMegoldas()
        {
            throw new NotImplementedException();
        }
        
        public int OptimalisErtek()
        {
            throw new NotImplementedException();
        }

        public bool[] Generator(int i)
        {
            throw new NotImplementedException();
        }

        public int Josag(bool[] pakolas)
        {
            throw new NotImplementedException();
        }

    }
}
