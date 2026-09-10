using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;

namespace OE.ALGA.Paradigmak
{
    // 1. heti labor feladat - Tesztek: 01_ImperativParadigmaTesztek.cs
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

 
    public class FeladatTarolo<T> where T : IVegrehajthato
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
    }
    public class FuggoFeladatTarolo<T> :  FeladatTarolo<T> where T : IVegrehajthato, IFuggo
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

