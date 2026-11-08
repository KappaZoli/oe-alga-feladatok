using System;
using System.Linq;
using OE.ALGA.Optimalizalas;

namespace OE.ALGA.Optimalizalas
{
    public class VisszalepesesOptimalizacio<T>
    {
        public int n;
        public int[] M;
        public T[,] R;
        public Func<int, T, bool> ft;
        public Func<int, T, T[], bool> fk;
        public Func<T[], float> josag;

        public int LepesSzam { get; protected set; }
        public T[] legjobbMegoldas;
        public float legjobbErtek;
        public T[] E; // aktuális megoldás

        public VisszalepesesOptimalizacio(int n, int[] M, T[,] R, Func<int, T, bool> ft, Func<int, T, T[], bool> fk, Func<T[], float> josag)
        {
            this.n = n;
            this.M = M;
            this.R = R;
            this.ft = ft;
            this.fk = fk;
            this.josag = josag;
        }

        public T[] OptimalisMegoldas()
        {
            bool van = false;
            T[] E = new T[n];
            T[] O = new T[n];
            Backtrack(0, E, ref van, O);
            return O;
        }

        public virtual void Backtrack(int szint, T[] E, ref bool van, T[] O)
        {
            int i = -1;
            while (i < M[szint] - 1)
            {
                LepesSzam++;
                i++;
                if (ft(szint, R[szint, i]))
                {
                    if (fk(szint, R[szint, i], E))
                    {
                        E[szint] = R[szint, i];
                        if (szint == n - 1)
                        {
                            if (!van || josag(E) > josag(O))
                            {
                                Array.Copy(E, O, E.Length);

                            }
                            van = true;
                        }
                        else
                        {

                            Backtrack(szint + 1, E, ref van, O);
                        }
                    }
                }

            }

        }
    }

    public class VisszalepesesHatizsakPakolas
    {
        protected HatizsakProblema problema;
        public int LepesSzam { get; protected set; }

        public VisszalepesesHatizsakPakolas(HatizsakProblema problema)
        {
            this.problema = problema;
        }
        public virtual bool[] OptimalisMegoldas()
        {
            int[] M = new int[problema.n];
            bool[,] R = new bool[problema.n, 2];
            for (int i = 0; i < problema.n; i++)
            {
                M[i] = 2;
                for (int j = 0; j < 2; j++)
                {
                    R[i, j] = (j == 0);
                }
            }
            VisszalepesesOptimalizacio<bool> optimalizacio = new VisszalepesesOptimalizacio<bool>(
                problema.n,
                M,
                R,
                (szint, r) => true,
                (szint, r, E) =>
                {
                    float sum = problema.OsszSuly(E);
                    if (r)
                    {
                        sum += problema.w[szint];
                    }
                    return sum <= problema.Wmax;
                },
                r => problema.OsszErtek(r));
            bool[] O = optimalizacio.OptimalisMegoldas();
            LepesSzam = optimalizacio.LepesSzam;
            return O;
        }
        public float OptimalisErtek()
        {
            return problema.OsszErtek(OptimalisMegoldas());
        }
    }

    public class SzetvalasztasEsKorlatozasOptimalizacio<T> : VisszalepesesOptimalizacio<T>
    {
        readonly Func<int, T[], float> fb;

        public SzetvalasztasEsKorlatozasOptimalizacio(int n, int[] m, T[,] r, Func<int, T, bool> ft, Func<int, T, T[], bool> fk, Func<int, T[], float> fb, Func<T[], float> josag)
            : base(n, m, r, ft, fk, josag)
        {
            this.fb = fb;
        }

        public override void Backtrack(int szint, T[] E, ref bool van, T[] O)
        {
            int i = -1;
            while (i < M[szint] - 1)
            {
                LepesSzam++;
                i++;
                if (ft(szint, R[szint, i]))
                {
                    if (fk(szint, R[szint, i], E))
                    {

                        E[szint] = R[szint, i];
                        if (szint == n - 1)
                        {
                            if (!van || josag(E) > josag(O))
                            {
                                Array.Copy(E, O, E.Length);

                            }
                            van = true;

                        }
                        else
                        {
                            if (josag(E) + fb(szint, E) > josag(O))
                            {
                                Backtrack(szint + 1, E, ref van, O);

                            }
                        }
                    }
                }

            }

        }
    }

    public class SzetvalasztasEsKorlatozasHatizsakPakolas : VisszalepesesHatizsakPakolas
    {
        public SzetvalasztasEsKorlatozasHatizsakPakolas(HatizsakProblema problema) : base(problema)
        {

        }

        public override bool[] OptimalisMegoldas()
        {

            int[] M = new int[problema.n];
            bool[,] R = new bool[problema.n, 2];
            for (int i = 0; i < problema.n; i++)
            {
                M[i] = 2;
                for (int j = 0; j < 2; j++)
                {
                    R[i, j] = (j == 0);
                }
            }
            SzetvalasztasEsKorlatozasOptimalizacio<bool> optimalizacio = new SzetvalasztasEsKorlatozasOptimalizacio<bool>(
                problema.n,
                M,
                R,
                (szint, r) => true,
                (szint, r, E) =>
                {
                    float sum = problema.OsszSuly(E);
                    if (r)
                    {
                        sum += problema.w[szint];
                    }
                    return sum <= problema.Wmax;
                },
                (szint, E) =>
                {
                    float bena = 0;
                    for (int i = szint; i < problema.n; i++)
                    {
                        if (problema.OsszSuly(E) + problema.w[i] <= problema.Wmax)
                        {
                            bena += problema.p[i];
                        }
                    }
                    return bena;
                },
                r => problema.OsszErtek(r));
            bool[] O = optimalizacio.OptimalisMegoldas();
            LepesSzam = optimalizacio.LepesSzam;
            return O;
        }




    }
}