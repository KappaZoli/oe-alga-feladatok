using System;
using System.Net.Http.Headers;

namespace OE.ALGA.Optimalizalas
{
    // 9. heti labor feladat - Tesztek: 09VisszalepesesKeresesTesztek.cs


    public class VisszalepesesOptimalizacio<T>
    {
        int n;
        int[] M;
        T[,] R;
        Func<int, T, bool> ft;
        Func<int, T, T[], bool> fk;
        Func<T[], int> josag;
        public int LepesSzam { get; set; }

        public VisszalepesesOptimalizacio(int n, int[] m, T[,] r, Func<int, T, bool> ft, Func<int, T, T[], bool> fk, Func<T[], int> josag, int lepesSzam)
        {
            this.n = n;
            M = m;
            R = r;
            this.ft = ft;
            this.fk = fk;
            this.josag = josag;
            LepesSzam = lepesSzam;
        }

        public void Backtrack(int szint, ref T[] E, ref bool van, ref T[] O)
        {
            int i = -1;

            while(!van  && i < M[szint] - 1)
            {
                i++;
                if(ft(szint, R[szint, i]))
                {
                    if(fk(szint, R[szint, i], E))
                    {
                        E[szint] = R[szint, i];
                        if (szint == n - 1)
                        {
                            if(!van || josag(E) > josag(O))
                            {
                                O = E;
                            }
                            van = true;
                        }
                        else
                        {
                            Backtrack(n + 1,ref E, ref van, ref O);
                        }
                    }
                }
            }
        }

        public T[] OptimalizalasMegoldas()
        {
            T[] eredmeny= new T[M.Length];
            T[] E = new T[n];
           
            bool van = false;
            Backtrack(n, ref E, ref van, ref eredmeny);

            return eredmeny;

        }
       
    }
}
