using System;
using System.Collections;
using System.Collections.Generic;

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
        public bool FuggosegTeljesul { set; }


    }

    public interface IVegrehajthato
    {
        void Vegrehajtas();
    }

    public interface IEnumerable
    {
        public void BejaroLetrehozas();
    }
    public interface IEnumerator
    {
        public IVegrehajthato T { get; set; }
        public void Alaphelyzet();
        public bool Kovetkezo();
    }
    public class FeladatTarolo : IVegrehajthato
    {
        public IVegrehajthato[] Tarolo { get; set; }
        public int n = 0;

        public FeladatTarolo(int n)
        {
            Tarolo = new IVegrehajthato[n];

        }

        public void Felvesz(IVegrehajthato feladat)
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

        public void Vegrehajtas()
        {

        }

        public void MindentVegrehajt(IVegrehajthato elem)
        {
            for (int i = 0; i < n; i++)
            {

                Tarolo[i].Vegrehajtas();
            }
        }
    }
    public class FuggoFeladatTarolo : FeladatTarolo, IFuggo, IVegrehajthato
    {
       
        public FuggoFeladatTarolo(int n) : base(n)
        {
           
        }

        public bool FuggosegTeljesul { get;  set; }

        public override void MindentVegrehajt(IVegrehajthato vegrehajthato)
        {
            for (int i = 0; i < n; i++)
            {
                if (FuggosegTeljesul) Tarolo[i].Vegrehajtas();
            }

        }
       
    }

    
}

