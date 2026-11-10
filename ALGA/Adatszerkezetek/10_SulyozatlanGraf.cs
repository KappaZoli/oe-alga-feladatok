using OE.ALGA.Paradigmak;
using System;

namespace OE.ALGA.Adatszerkezetek
{
    // 10. heti labor feladat - Tesztek: 10_SulyozatlanGrafTesztek.cs

    public class EgeszGrafEl : GrafEl<int>, IComparable
    {
        public EgeszGrafEl(int honnan, int hova)
        {
            Honnan = honnan;
            Hova = hova;
        }

        public int Honnan { get; set; }

        public int Hova { get; set; }

        public int CompareTo((object? obj)
        {
            EgeszGrafEl teszt = (EgeszGrafEl)obj;
            if (this.Honnan != obj.Honnan)
            {
                if (this.Honnan < obj.Honnan)
                {
                    return -1;
                }
                else if (this.Honnan > obj.Honnan)
                {
                    return 1;
                }
            }
            else
            {
                if (this.Hova < obj.Hova)
                {
                    return -1;
                }
                else if (this.Hova > obj.Hova)
                {
                    return 1;
                }

            }

            return 0;
        }
    }




    public class CsúcsmátrixSúlyozatlanEgészGráf : SulyozatlanGraf<int, EgeszGrafEl>
    {
        int n;

        bool[,] M;
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

        public FaHalmaz<int> Csucsok { get
            {
                FaHalmaz<int> eredmeny;

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
                Halmaz<EgeszGrafEl> eredmeny;
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
            Halmaz<int> eredmeny;
            for (int i = 0; i < n; i++)
            {
                if (M[csucs, i])
                    eredmeny.Beszur(i);
            }
            return eredmeny;
        }

        public void UjEl(int honnan, int hova)
        {
            M[honnan - 1, hova - 1] = true;
        }

        public bool VezetEl(int honnan, int hova)
        {
            return M[honnan - 1, hova - 1];
        }
    }


    public class GrafBejarasok
    {
        public Halmaz<int> SzelessegiBejaras(int V, int E)
        {



            return null;

        }





    }
}
