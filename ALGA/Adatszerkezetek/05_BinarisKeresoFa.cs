using System;
using System.ComponentModel.Design;

namespace OE.ALGA.Adatszerkezetek
{
    public class FaElem<T> where T : IComparable<T>
    {
        public T tart { get; set; }
        public FaElem<T> bal { get; set; }
        public FaElem<T> jobb { get; set; }
      
    }

    public class FaHalmaz<T> : Halmaz<T> where T : IComparable<T>
    {
        public FaElem<T> gyoker;
        public FaHalmaz()
        {
        }

        public void Bejar(Action<T> muvelet)
        {
           BejarasPreorder(gyoker, muvelet);

        }
        public void BejarasPreorder(FaElem<T> p, Action<T> muvelet)
        {
            if(p != null)
            {
                muvelet(p.tart);
                BejarasPreorder(p.bal, muvelet);
                BejarasPreorder(p.jobb, muvelet);
            }
            
        }
        public void Beszur(T ertek)
        {
            
              gyoker=ReszhalmazBeszur(gyoker, ertek);
            
        }
        public FaElem<T> ReszhalmazBeszur(FaElem<T> p, T ertek)
        {
            if (p == null)
            {
                p = new FaElem<T>() { tart = ertek, bal = null, jobb = null };
                return p;
            }
            else
            {


                if (p.tart.CompareTo(ertek) > 0)
                {

                    p.bal = ReszhalmazBeszur(p.bal, ertek);


                }
                else
                {


                    if (p.tart.CompareTo(ertek) < 0)
                    {

                        p.jobb = ReszhalmazBeszur(p.jobb, ertek);


                    }
                }
            
                return p;
                
            }
        }

        public bool Eleme(T ertek)
        {
            
            return ReszhalmazEleme(gyoker, ertek);
        }

        public bool ReszhalmazEleme(FaElem<T> p, T ertek)
        {
            if(p != null)
            {
                if( p.tart.CompareTo(ertek) == 0)
                {
                    return true;
                }
                else if (p.tart.CompareTo(ertek) > 0)
                {
                    return ReszhalmazEleme(p.bal, ertek);
                }
                else
                {
                    return ReszhalmazEleme(p.jobb, ertek);
                }
            }
            else
            {
                return false;
            }
        }

        public void Torol(T ertek)
        {
           gyoker= ReszhalmazTorol(gyoker, ertek);

        }

        public FaElem<T> ReszhalmazTorol(FaElem<T> p, T ertek)
        {
            if (p != null)
            {
                
                if (p.tart.CompareTo(ertek) < 0)
                {
                    p.jobb = ReszhalmazTorol(p.jobb, ertek);
                }
                else
                {
                    if (p.tart.CompareTo(ertek) > 0)
                    {
                        p.bal = ReszhalmazTorol(p.bal, ertek);
                    }
                    else
                    {
                        if (p.bal == null)
                        {
                            FaElem<T> q = p;
                            p = p.jobb;
                              

                        }
                        else
                        {
                            if (p.jobb == null)
                            {
                                FaElem<T> q = p;
                                p = p.bal;

                               

                            }
                            else
                            {
                              
                               p.bal= KetGyerekesTorles(p, p.bal);
                            }
                        }

                    }
                   
                   
                }
                return p;
            }
            else
            {

                throw new NincsElemKivetel();
            }
        }

        public FaElem<T> KetGyerekesTorles(FaElem<T> e, FaElem<T> r)
        {

            if (r.jobb == null)
            {
                r.jobb=KetGyerekesTorles(e, r.jobb);
                return r;
            }
            else
            {
                e.tart = r.tart;
                FaElem<T> q = r;
                r=r.bal;

              
            }
            return r;
        }
    }
}
