using System;


namespace OE.ALGA.Optimalizalas
{
    // 9. heti labor feladat - Tesztek: 09VisszalepesesKeresesTesztek.cs

    public class VisszalepesesOptimalizacio<T>
    {
        protected int n;
        protected int[] M;
        protected T[,] R;
        protected Func<int, T, bool> ft;
        protected Func<int, T, T[], bool> fk;
        protected Func<T[], float> josag;
        public int LepesSzam { get; set; }

        public VisszalepesesOptimalizacio(int n, int[] m, T[,] r, Func<int, T, bool> ft, Func<int, T, T[], bool> fk, Func<T[], float> josag)
        {
            this.n = n;
            M = m;
            R = r;
            this.ft = ft;
            this.fk = fk;
            this.josag = josag;
            LepesSzam = 0;
        }

        protected virtual void Backtrack(int szint, ref T[] E, ref bool van, ref T[] O)
        {
            int i = -1;
            while (i < M[szint] - 1)
            {
                i++;
                LepesSzam++;

                if (ft(szint, R[szint, i]))
                {
                    if (fk(szint, R[szint, i], E))
                    {
                        E[szint] = R[szint, i];

                        if (szint == n - 1)
                        {
                            if (!van || josag(E) > josag(O))
                            {
                                Array.Copy(E, O, n);
                                van = true;
                            }
                        }
                        else
                        {
                            Backtrack(szint + 1, ref E, ref van, ref O);
                        }
                    }
                }
            }
        }

        public T[] OptimalisMegoldas()
        {
            LepesSzam = 0;
            T[] O = new T[n];
            T[] E = new T[n];
            bool van = false;

            Backtrack(0, ref E, ref van, ref O);

            return O;
        }
    }

    // 2. FELADAT
    public class VisszalepesesHatizsakPakolas
    {
        protected HatizsakProblema problema;
        public int LepesSzam { get; protected set; }

        public VisszalepesesHatizsakPakolas(HatizsakProblema problema)
        {
            this.problema = problema;
        }

        protected bool Ft(int szint, bool r)
        {
            // Ha be akarjuk rakni, már itt ellenőrizhető, hogy önmagában befér-e a hátizsákba
            return !r || problema.w[szint] <= problema.Wmax;
        }

        protected bool Fk(int szint, bool r, bool[] E)
        {
            int suly = 0;
            for (int i = 0; i < szint; i++)
            {
                if (E[i])
                {
                    suly += problema.w[i];
                }
            }
            if (r)
            {
                suly += problema.w[szint];
            }
            return suly <= problema.Wmax;
        }

        protected float Josag(bool[] pakolas)
        {
            return problema.OsszErtek(pakolas);
        }

        public virtual bool[] OptimalisMegoldas()
        {
            int n = problema.n;
            int[] M = new int[n];
            bool[,] R = new bool[n, 2];

            for (int i = 0; i < n; i++)
            {
                M[i] = 2;
                R[i, 0] = true;
                R[i, 1] = false;
            }

            VisszalepesesOptimalizacio<bool> opt = new VisszalepesesOptimalizacio<bool>(n, M, R, Ft, Fk, Josag);

            bool[] optPakolas = opt.OptimalisMegoldas();
            this.LepesSzam = opt.LepesSzam;
            return optPakolas;
        }

        public float OptimalisErtek()
        {
            bool[] optPakolas = OptimalisMegoldas();
            return Josag(optPakolas);
        }
    }

    // 3. FELADAT
    public class SzetvalasztasEsKorlatozasOptimalizacio<T> : VisszalepesesOptimalizacio<T>
    {
        protected Func<int, T[], float> fb;

        public SzetvalasztasEsKorlatozasOptimalizacio(
            int n, int[] M, T[,] R,
            Func<int, T, bool> ft,
            Func<int, T, T[], bool> fk,
            Func<T[], float> josag,
            Func<int, T[], float> fb)
            : base(n, M, R, ft, fk, josag)
        {
            this.fb = fb;
        }

        protected override void Backtrack(int szint, ref T[] E, ref bool van, ref T[] O)
        {
            int i = -1;
            while (i < M[szint] - 1)
            {
                i++;
                LepesSzam++;

                if (ft(szint, R[szint, i]))
                {
                    if (fk(szint, R[szint, i], E))
                    {
                        E[szint] = R[szint, i];

                        if (szint == n - 1)
                        {
                            if (!van || josag(E) > josag(O))
                            {
                                Array.Copy(E, O, n);
                                van = true;
                            }
                        }
                        else
                        {
                            if (josag(E) + fb(szint, E) > josag(O))
                            {
                                Backtrack(szint + 1, ref E, ref van, ref O);
                            }
                        }
                    }
                }
            }
            // FONTOS: Kitisztítjuk az E[szint]-et visszalépéskor, hogy a josag(E) 
            // a felsőbb szinteken ne számolja bele a régi ágakból ott maradt értékeket!
            E[szint] = default(T);
        }
    }

    // 4. FELADAT
    public class SzetvalasztasEsKorlatozasHatizsakPakolas : VisszalepesesHatizsakPakolas
    {
        public SzetvalasztasEsKorlatozasHatizsakPakolas(HatizsakProblema problema)
            : base(problema)
        {
        }

        protected float Fb(int szint, bool[] E)
        {
            float b = 0;
            int eddigiSuly = problema.OsszSuly(E);

            // Csak azokat a hátralévő tárgyakat adjuk hozzá a becsléshez, 
            // amelyek egyenként még beférnek a megmaradt helyre!
            for (int i = szint + 1; i < problema.n; i++)
            {
                if (eddigiSuly + problema.w[i] <= problema.Wmax)
                {
                    b += problema.p[i];
                }
            }

            return b;
        }

        public override bool[] OptimalisMegoldas()
        {
            int n = problema.n;
            int[] M = new int[n];
            bool[,] R = new bool[n, 2];

            for (int i = 0; i < n; i++)
            {
                M[i] = 2;
                R[i, 0] = true;
                R[i, 1] = false;
            }

            SzetvalasztasEsKorlatozasOptimalizacio<bool> opt = new SzetvalasztasEsKorlatozasOptimalizacio<bool>(
                n, M, R, Ft, Fk, Josag, Fb
            );

            bool[] optPakolas = opt.OptimalisMegoldas();
            this.LepesSzam = opt.LepesSzam;
            return optPakolas;
        }
    }
}