using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

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
        public T[] E= new T[5];
        public int n=0;

        public bool Ures { get; private set; }

        

        public int Elemszam { get { return n; } }

        public TombLista()
        {
            
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
            if(n >= E.Length)
            {
                T[] ujE = new T[E.Length * 2];
                for (int i = 0; i < n; i++)
                {
                    ujE[i] = E[i];
                }
                E = ujE;
              
            }
            
                E[n] = ertek;
                n++;
                
                        
        }

        public void Beszur(int index, T ertek)
        {
            if (index <= n && index >= 0)
            {
                if (E.Length <= n)
                {
                    T[] ujE = new T[E.Length * 2];
                    for (int i = 0; i < n; i++)
                    {
                        ujE[i] = E[i];
                    }
                    E = ujE;
                    
                }
                n++;
                for (int i = n-1; i > index; i--)
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
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                if (object.Equals(E[i], ertek))
                {
                    db++; 
                }
                else
                {
                    E[i-db] = E[i];
                }
            }
            n =n-db;
            

        }

        public void Bejar(Action<T> muvelet)
        {
            for (int i = 0; i < n; i++)
            {
                muvelet(E[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < n; i++)
            {
                yield return E[i];
            }
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
