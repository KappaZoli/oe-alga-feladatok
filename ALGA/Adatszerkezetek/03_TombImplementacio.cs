using System;
using System.Drawing;

namespace OE.ALGA.Adatszerkezetek
{
    // 3. heti labor feladat - Tesztek: 03_TombImplementacioTesztek.cs
    public class TombVerem<T> : Verem<T>
    {
        public T[] E;

        public int n;
        public bool Ures { get; }

        public TombVerem(int meret)
        {
            E = new T[meret];
            n = 0;
        }
        public T Felso()
        {
            throw new System.NotImplementedException();
        }

        public void Verembe(T ertek)
        {
            if (n < E.Length)
            {
                E[n] = ertek;
                n++;
            }
            else
            {
                throw new NincsElemKivetel();

            }

        }

        public T Verembol()
        {
            if (n == 0)
            {
                throw new NincsElemKivetel();
            }
            else
            {
                n--;
                return E[n];
            }
        }
    }

    public class TombSor<T> : Sor<T>
    {
        public bool Ures => throw new NotImplementedException();

        public void Sorba(T ertek)
        {
            throw new NotImplementedException();
        }

        public T Sorbol()
        {
            throw new NotImplementedException();
        }

        public T Elso()
        {
            throw new NotImplementedException();
        }
    }
}
