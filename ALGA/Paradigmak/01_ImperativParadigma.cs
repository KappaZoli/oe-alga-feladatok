using System;
using System.Collections.Generic;

namespace OE.ALGA.Paradigmak
{
    // 1. heti labor feladat - Tesztek: 01_ImperativParadigmaTesztek.cs
    //Zalan
    public class TaroloMegteltKivetel : Exception
    {
        public TaroloMegteltKivetel(string msg)
        {
            Console.WriteLine(msg);
        }
    }
    public interface IFuggo
    {
        public bool FuggosegTeljesul { get; }


    }

    public interface IVegrehajthato
    {
        void Vegrehajtas();
    }
    public interface IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator();
    }


    public class FeladatTarolo<T> : IEnumerable<T> where T : IVegrehajthato
    {
        public T[] Tarolo { get; set; }
        public int n = 0;

        public FeladatTarolo(int n)
        {
            Tarolo = new T[n];

        }

        public void Felvesz(T feladat)
        {
            if (n < Tarolo.Length)
            {
                Tarolo[n] = feladat;
                n++;
            }
            else
            {
                throw new TaroloMegteltKivetel("baj van");
            }
        }

        public void MindentVegrehajt()
        {
            for (int i = 0; i < n; i++)
            {

                Tarolo[i].Vegrehajtas();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < n; i++)
            {
                yield return Tarolo[i];
            }
        }
    }
    public class FuggoFeladatTarolo<T> : FeladatTarolo<T> where T : IVegrehajthato, IFuggo
    {

        public FuggoFeladatTarolo(int n) : base(n)
        {

        }

        public void MindentVegrehajt()
        {
            for (int i = 0; i < n; i++)
            {
                if (Tarolo[i].FuggosegTeljesul)
                {
                    Tarolo[i].Vegrehajtas();
                }
            }

        }


    }




}
