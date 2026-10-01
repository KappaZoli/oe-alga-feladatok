using System;

namespace OE.ALGA.Adatszerkezetek
{
    public class LancElem<T>
    {
        public T tart;
        public LancElem<T> kov;

        public LancElem(T tartalom)
        {
            tart = tartalom;
            kov = null;
        }
    }

    public class LancoltVerem<T> : Verem<T>
    {
        public LancElem<T> fej;
        public bool Ures { get { return fej == null; } }

        public T Felso()
        {
            throw new NotImplementedException();
        }

        public void Verembe(T ertek)
        {
            throw new NotImplementedException();
        }

        public T Verembol()
        {
            if (Ures)
            {
                throw new NincsElemKivetel();
            }
            else
            {
                T ertek = fej.tart;
                fej = fej.kov;
                return ertek;
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
            throw new NotImplementedException();
        }

        public void Sorba(T ertek)
        {
            throw new NotImplementedException();
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

    public class LancoltLista<T> : Lista<T>
    {
        public LancElem<T> fej;
        public int Elemszam => throw new NotImplementedException();

        public void Bejar(Action<T> muvelet)
        {
            throw new NotImplementedException();
        }

        public void Beszur(int index, T ertek)
        {
            throw new NotImplementedException();
        }

        public void Hozzafuz(T ertek)
        {
            throw new NotImplementedException();
        }

        public T Kiolvas(int index)
        {
            throw new NotImplementedException();
        }

        public void Modosit(int index, T ertek)
        {
            throw new NotImplementedException();
        }

        public void Torol(T ertek)
        {
            throw new NotImplementedException();
        }
    }
}