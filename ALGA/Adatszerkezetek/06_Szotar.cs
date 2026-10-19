using System;
using System.Numerics;

namespace OE.ALGA.Adatszerkezetek
{
    // 6. heti labor feladat - Tesztek: 06_SzotarTesztek.cs

    public class SzotarElem<K, T> 
    {
        public SzotarElem(K kulcs, T tart)
        {
            this.kulcs = kulcs;
            this.tart = tart;
        }

        public K kulcs { get; set; }
        public T tart { get; set; }


    }

    public class HasitoSzotarTulcsordulasiTerulettel<K, T> : Szotar<K, T>
    {
        public SzotarElem<K, T>[] E { get; set; }
        public Func<K, int> H { get; set; }
        public LancoltLista<SzotarElem<K, T>> U { get; set; }

        public HasitoSzotarTulcsordulasiTerulettel(int meret, Func<K, int> hasitoFuggveny)
        {
            this.E = new SzotarElem<K, T>[meret];
            this.H = (t => Math.Abs(hasitoFuggveny(t)) % E.Length);
            this.U = new LancoltLista<SzotarElem<K, T>>();
        }
        public HasitoSzotarTulcsordulasiTerulettel(int meret)
        {
            this.E = new SzotarElem<K, T>[meret];
            this.H = (t => Math.Abs(t.GetHashCode()) % E.Length);
            this.U = new LancoltLista<SzotarElem<K, T>>();
        }

        private SzotarElem<K, T> KulcsKeres(K kulcs)
        {
            if (E[H(kulcs)] != null && object.Equals(E[H(kulcs)].kulcs, kulcs))
            {
                return E[H(kulcs)];
            }
            else
            {
                SzotarElem<K, T> e = null;
                U.Bejar(x => {
                    if (object.Equals(x.kulcs, kulcs))
                    {
                        e = x;
                    }
                });
                return e;
            }
        }
        public void Beir(K kulcs, T ertek)
        {
            SzotarElem<K, T> meglevo = KulcsKeres(kulcs);
            if (meglevo != null)
            {
                meglevo.tart = ertek;
            }
            else
            {
                SzotarElem<K, T> ujElem = new SzotarElem<K, T>(kulcs, ertek);
                if (E[H(kulcs)] == null)
                {
                    E[H(kulcs)] = ujElem;
                }
                else
                {
                    U.Hozzafuz(ujElem);
                }
            }
        }

        public T Kiolvas(K kulcs)
        {
            SzotarElem<K,T> meglevo =KulcsKeres(kulcs);

            if(meglevo!= null)
            {
                return meglevo.tart;
            }
            else
            {
                throw new HibasKulcsKivetel();

            }

        }

        public void Torol(K kulcs)
        {
            if (E[H(kulcs)] != null && object.Equals(E[H(kulcs)].kulcs, kulcs))
            {
                E[H(kulcs)] = null;
            }
            else
            {
                SzotarElem<K, T> e;

                U.Bejar(x => {
                    if (object.Equals(x.kulcs, kulcs))
                    {
                        e = x;
                        U.Torol(e);
                    }

                });

                if (e != null)
                {

                }
            }

        }
    }

}
