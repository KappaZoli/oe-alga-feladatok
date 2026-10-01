using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace OE.ALGA.Adatszerkezetek
{
    internal class Program
    {
        static void Main()
        {
            
        }
    }
    // 3. heti labor feladat - Tesztek: 03_TombImplementacioTesztek.cs
    public class TombVerem<T> : Verem<T> //Verem: FILO (First In Last Out) elv alapján tárolja az elemeket, az utolsóként betett elem kerül ki először.
    {
        public T[] E;

        public int n;
        public bool Ures { get { return n == 0; } }

        public TombVerem(int meret)
        {
            E = new T[meret];
            n = 0;
        }
        public T Felso()
        {
            return E[n-1];
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
                throw new NincsHelyKivetel();

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

    public class TombSor<T> : Sor<T> //Sor: olyan sorrendbe tartja az elemeket, ahogy bekerültek, FIFO (First In First Out) elv alapján és kiolvassa őket. Az elsőként betett elem kerül ki először.
    {
        public T[] E;
        public int n;
        public int u; //utolso elem indexe

        public int e; //elso elem indexe
        public bool Ures { get { return n == 0; } }


        public TombSor(int meret)
        {
            E = new T[meret];
            n = 0;
            e = 0;
            u = 0;
        }
        public void Sorba(T ertek)
        {
            if (n < E.Length)
            {
                n++;
                u = (u+1)% E.Length ;
                E[u] = ertek;
                
               
            }
            else
            {
                throw new NincsHelyKivetel();

            }
        }

        public T Sorbol()
        {
            if (n > 0)
            {
                n--;
                e=(e+1) % E.Length;
                return E[e];
                
            }
            else
            {
                throw new NincsElemKivetel();

            }
        }

        public T Elso()
        {
            
           if(n>0)
            {
               
                return E[(e + 1) % E.Length];
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }
    }

    public class TombLista<T> : Lista<T>, IEnumerable<T> //Lista: olyan adatszerkezet, amely lehetővé teszi az elemek dinamikus tárolását és kezelését. Az elemeket sorban tárolja, és lehetővé teszi az elemek hozzáadását, eltávolítását és elérését.
    {
        public T[] E;
        public int n;

        public bool Ures { get{ return n == 0; } }


        public int Elemszam { get; private set; }
        public TombLista()
        {
            E = new T[5];
            n = 5;
            Elemszam = 0;

        }


        public T Kiolvas(int index)
        {
            return E[index];
        }

        public void Modosit(int index, T ertek)
        {
            E[index] = ertek;
        }

        public void Hozzafuz(T ertek)
        {
            if(Elemszam >= n)
            {
                T[] ujE = new T[n * 2];
                for (int i = 0; i < n; i++)
                {
                    ujE[i] = E[i];
                }
                E = ujE;
                n = ujE.Length;
            }
            else
            {
                E[Elemszam] = ertek;
                Elemszam++;
            }
            
        }

        public void Beszur(int index, T ertek)
        {
            if (Elemszam <= n + 1)
            {
                if (Elemszam == n)
                {
                    T[] ujE = new T[n * 2];
                    for (int i = 0; i < n; i++)
                    {
                        ujE[i] = E[i];
                    }
                    E = ujE;
                    n = ujE.Length;

                }
                n++;
                for (int i = Elemszam; i > index; i--)
                {
                    E[i] = E[i - 1];
                }
                E[index] = ertek;
            }
            else
            {
                throw new HibasIndexKivetel();
            }
        }

        public void Torol(T ertek)
        {
            for (int i = 0; i < Elemszam; i++)
            {
                if (E[i].Equals(ertek))
                {
                    for (int j = i; j < Elemszam - 1; j++)
                    {
                        E[j] = E[j + 1];
                    }
                    Elemszam--;
                    
                }
            }
        }

        public void Bejar(Action<T> muvelet)
        {
            foreach (var item in E)
            {
                muvelet(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class TombListaBejaro<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }





}
