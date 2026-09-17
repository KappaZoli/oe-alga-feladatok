using System;
using System.Collections.Generic;

namespace OE.ALGA.Paradigmak
{
    public class FeltetelesFeladatTarolo<T> : FeladatTarolo<T>, IEnumerable<T> where T : IVegrehajthato
    {
        public int n { get; set; }
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


        public void FeltetesFeladatTárolóBejáró(Func<T, bool> fuggoseg)
        {
            for (int i = 0; i < n; i++)
            {
                if (fuggoseg(Tarolo[i]))
                {
                    fuggoseg(Tarolo[i]);

                }
            }


        }

    }
}
