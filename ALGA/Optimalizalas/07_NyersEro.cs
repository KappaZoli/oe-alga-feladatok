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

        public Func<T, float> josag;

        public int LepesSzam { get; set; }


        public NyersEro(int m, Func<int, T> generator, Func<T, float> josag)
        {
            this.m = m;
            this.generator = generator;
            this.josag = josag;
        }

        public T OptimalisMegoldas()
        {
            T o = generator(1);
            for (int i = 2; i <= m; i++)
            {
                T x = generator(i);
                LepesSzam++;
                if (josag(x) > josag(o))
                {
                    o = x;
                }
            }
            return o;
        }
    }

    public class NyersEroHatizsakPakolas
    {
        public HatizsakProblema problema;
        public int LepesSzam { get; private set; }

        public NyersEroHatizsakPakolas(HatizsakProblema problema)
        {
            this.problema = problema;
        }
        public bool[] Generator(int i)
        {
            bool[] pakolas = new bool[problema.n];
            int v = i - 1; 
            for (int j = 0; j < problema.n; j++)
            {
                pakolas[j] = (v & (1 << j)) != 0;
            }
            return pakolas;
        }

        public float Josag(bool[] pakolas)
        {
            if (!problema.Ervenyes(pakolas))
            {
                return -1;
            }
            return problema.OsszErtek(pakolas);
        }

        public bool[] OptimalisMegoldas()
        {
            
            int m = (int)Math.Pow(2, problema.n);
            NyersEro<bool[]> ne = new NyersEro<bool[]>(m, Generator, Josag);

            bool[] optPakolas = ne.OptimalisMegoldas();

            
            this.LepesSzam = ne.LepesSzam;

            return optPakolas;
        }

        public float OptimalisErtek()
        {
            bool[] optPakolas = OptimalisMegoldas();
            return Josag(optPakolas);
        }
    }
}
