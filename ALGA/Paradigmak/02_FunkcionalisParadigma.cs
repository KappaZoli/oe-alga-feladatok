using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Paradigmak
{
    public class FeltetelesFeladatTarolo<T> : FeladatTarolo<T>, IEnumerable<T> where T : IVegrehajthato
    {
        
        public Func<T, bool> BejaroFeltetel { get; set; }
        public FeltetelesFeladatTarolo(int n) : base(n)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            if (BejaroFeltetel == null)
            {
                for (int i = 0; i < n; i++)
                {
                    yield return Tarolo[i];
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (BejaroFeltetel(Tarolo[i]))
                    {
                        yield return Tarolo[i];
                    }
                }
            }
        }

        public void FeltetelesVegrehajtas(Func<T, bool> fuggoseg)
        {
            for (int i = 0; i < n; i++)
            {
                if (fuggoseg(Tarolo[i]))
                {
                    Tarolo[i].Vegrehajtas();
                }
            }
        }


       

    }

    public class FeltetelesFeladatTaroloBejaro<T> : IEnumerator<T> where T : IVegrehajthato
    {

        int n;
        int index=-1;
        FeltetelesFeladatTarolo<T> tarolo;
        Func<T, bool> BejaroFeltetel;


        public FeltetelesFeladatTaroloBejaro(FeltetelesFeladatTarolo<T> tarolo, int n, Func<T, bool> BejaroFeltetel)
        {
            this.tarolo = tarolo;
            this.n = n;
            this.BejaroFeltetel = BejaroFeltetel;
        }
        public T Current { get; }

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
