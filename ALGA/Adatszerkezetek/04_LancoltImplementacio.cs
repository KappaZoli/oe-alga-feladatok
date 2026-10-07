using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace OE.ALGA.Adatszerkezetek
{
    public class LancElem<T>
    {
        public T tart;
        public LancElem<T> kov;

        public LancElem(T tartalom, LancElem<T> kovetkezo)
        {
            tart = tartalom;
            kov = kovetkezo;
        }
    }

    public class LancoltVerem<T> : Verem<T>
    {
        public LancElem<T>? fej;
        public bool Ures { get { return fej == null; } }


        public LancoltVerem()
        {
            fej=null;
        }
        public T Felso()
        {
            if (fej != null)
            {
                return fej.tart;
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }

        public void Verembe(T ertek)
        {
            LancElem<T> ujElem = new LancElem<T>(ertek, fej);
            fej = ujElem;
        }

        public T Verembol()
        {
            if (fej != null)
            {
                T ertek = fej.tart;
                fej = fej.kov;
                return ertek;
            }
            else
            {
                
                throw new NincsElemKivetel();
            }
        }
    }

    public class LancoltSor<T> : Sor<T>
    {
        public LancElem<T> fej;
        public LancElem<T> vege;
        public bool Ures { get { return fej == null; } }

        public T Elso()
        {
            if (fej != null)
            {
                return fej.tart;
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }

        public void Sorba(T ertek)
        {
            if(fej == null)
            {
                fej = new LancElem<T>(ertek, null);
                vege = fej;
            }
            else
            {
                vege.kov = new LancElem<T>(ertek, null);
                vege = vege.kov;
            }
            
        }

        public T Sorbol()
        {
            if(Ures)
            {
                throw new NincsElemKivetel();
            }
            else
            {
                T ertek = fej.tart;
                fej = fej.kov;
                if (fej == null)
                {
                    vege = null;
                }
                return ertek;
            }
        }
    }

    public class LancoltLista<T> : Lista<T>, IEnumerable<T>
    {
        public LancElem<T> fej;
        public int Elemszam{ get 
            { 
                int count = 0;
                LancElem<T> p = fej;

                while (p != null)
                {
                    count++;
                    p = p.kov;
                }
                return count;
            } }

        public void Bejar(Action<T> muvelet)
        {
            LancElem<T> p = fej;
            while (p != null)
            {
                muvelet(p.tart);
                p = p.kov;
            }
        }

        public void Beszur(int index, T ertek)
        {
            if (fej == null || index == 0)
            {
                LancElem<T> ujElem = new LancElem<T>(ertek, fej);
                fej = ujElem;
            }
            else
            {
                LancElem<T> p = fej;
                int i = 1;
                while(p.kov != null && i < index)
                {
                    p = p.kov;
                    i++;
                }

                if(index == i)
                {
                    LancElem<T> ujElem = new LancElem<T>(ertek, p.kov);
                    p.kov = ujElem;
                }
                else
                {
                    throw new HibasIndexKivetel();
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            LancElem<T> p = fej;
            while (p != null)
            {
                yield return p.tart;
                p = p.kov;
            }
        }

        public void Hozzafuz(T ertek)
        {
            LancElem<T> ujElem = new LancElem<T>(ertek, null);
            if(fej == null)
            {
                fej = ujElem;
            }
            else
            {
                LancElem<T> p = fej;
                while (p.kov != null)
                {
                    p = p.kov;
                }
                p.kov = ujElem;
                
            }
            
        }

        public T Kiolvas(int index)
        {
            LancElem<T> p = fej;

            if (p!= null)
            {
                for (int i = 0; i < index; i++)
                {
                    p = p .kov;
                }
                return p.tart;
            }
            else
            {
                throw new HibasIndexKivetel();
            }
            
        }

        public void Modosit(int index, T ertek)
        {
           LancElem<T> p= fej;
            int i = 0;
            while(p != null && i < index)
            {
                p = p.kov;
                i++;
            }
            if( p != null )
            {
                p.tart = ertek;
            }
            else
            {
                throw new HibasIndexKivetel();
            }
        }

        public void Torol(T ertek)
        {
            LancElem<T> p = fej;
            LancElem<T> e = null;
            do
            {
                while (p != null && !p.tart.Equals(ertek))
                {
                    e = p;
                    p = p.kov;
                }
                if (p != null)
                {
                    LancElem<T> q=p.kov;
                    if (e == null)
                    {
                        fej = q;
                    }
                    else
                    {
                        e.kov = q;
                    }
                    p = q;
                }

            } while (p!=null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LancoltListaBejaro<T> : IEnumerator<T>
    {
        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}