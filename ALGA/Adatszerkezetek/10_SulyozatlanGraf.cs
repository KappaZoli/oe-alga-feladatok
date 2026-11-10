using OE.ALGA.Paradigmak;
using System;

namespace OE.ALGA.Adatszerkezetek
{
    // 10. heti labor feladat - Tesztek: 10_SulyozatlanGrafTesztek.cs

    public class EgeszGrafEl : GrafEl<int>, IComparable<EgeszGrafEl>
    {
        public EgeszGrafEl(int honnan, int hova)
        {
            Honnan = honnan;
            Hova = hova;
        }

        public int Honnan { get; set; }

        public int Hova { get; set; }

        public virtual int CompareTo(EgeszGrafEl obj)
        {
            if ((obj != null && obj is EgeszGrafEl b))
            {
                if (Honnan != b.Honnan)
                    return Honnan.CompareTo(b.Honnan);
                else
                    return Hova.CompareTo(b.Hova);
            }
            else
                throw new InvalidOperationException();
        }
        public override bool Equals(object obj)
        {
            if (obj is EgeszGrafEl b)
                return Honnan == b.Honnan && Hova == b.Hova;
            return false;
        }

    }




    public class CsucsmatrixSulyozatlanEgeszGraf : SulyozatlanGraf<int, EgeszGrafEl>
    {
        int n;

        bool[,] M;

        public CsucsmatrixSulyozatlanEgeszGraf(int n)
        {
            this.n = n;
            M = new bool[n,n];
        }

        public int CsucsokSzama { get { return n; } }

        public int ElekSzama { get { return ElekSz(); } }

        private int ElekSz()
        {
            int eredmeny = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (M[i, j]) eredmeny++;
                }
            }
            return eredmeny;
        }

        public Halmaz<int> Csucsok { get
            {
                Halmaz<int> eredmeny= new FaHalmaz<int>();

                for (int i = 0; i < n; i++)
                {
                    ;
                    eredmeny.Beszur(i);
                }
                return eredmeny;
            }
        }

        public Halmaz<EgeszGrafEl> Elek { get
            {
                Halmaz<EgeszGrafEl> eredmeny= new FaHalmaz<EgeszGrafEl>();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (M[i, j])
                        {
                            eredmeny.Beszur(new EgeszGrafEl(i, j));
                        }
                    }
                }

                return eredmeny;
            }
        }

        public Halmaz<int> Szomszedai(int csucs)
        {
            Halmaz<int> eredmeny= new FaHalmaz<int>();
            for (int i = 0; i < n; i++)
            {
                if (M[csucs, i])
                    eredmeny.Beszur(i);
            }
            return eredmeny;
        }

        public void UjEl(int honnan, int hova)
        {
            M[honnan, hova] = true;
        }

        public bool VezetEl(int honnan, int hova)
        {
            return M[honnan, hova];
        }
    }


    public class GrafBejarasok
    {
        public static Halmaz<V> SzelessegiBejaras<V,E>(Graf<V, E> G,V start, Action<V> muvelet) where V : IComparable<V> 
        {
            Sor<V> S= new LancoltSor<V>();
            S.Sorba(start);
            Halmaz<V> F= new FaHalmaz<V>();
            F.Beszur(start);
            while (!S.Ures)
            {
                V k = S.Sorbol();
                muvelet(k);

                G.Szomszedai(k).Bejar(x =>
                {
                    if (!F.Eleme(x))
                    {
                        S.Sorba(x);
                        F.Beszur(x);
                    }
                });
            }


            return F;

        }


        public static void MelysegiBejarasRekurzio<V,E>(Graf<V,E> g, V k, Halmaz<V> F, Action<V> muvelet) where V : IComparable<V>
        {
            F.Beszur(k);
            muvelet(k);
            
            g.Szomszedai(k).Bejar(x =>
            {   
                if (!F.Eleme(x))
                {
                    MelysegiBejarasRekurzio(g, x, F, muvelet);
                }
            });
            
        }

        public static Halmaz<V> MelysegiBejaras<V, E>(Graf<V, E> G, V start, Action<V> muvelet) where V : IComparable<V>
        {
            Halmaz<V> F = new FaHalmaz<V>();
            MelysegiBejarasRekurzio(G, start, F, muvelet);
            return F;
        }




    }
}
