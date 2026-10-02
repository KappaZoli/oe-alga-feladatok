using OE.ALGA;
using OE.ALGA.Adatszerkezetek;
using OE.ALGA.ALGAme;

//Jatek jatek = new Jatek();
//jatek.Start();

Lista<int> l = new LancoltLista<int>();
l.Hozzafuz(1);
l.Hozzafuz(2);
l.Hozzafuz(3);
l.Hozzafuz(4);
l.Hozzafuz(5);

for (int i = 0; i < l.Elemszam; i++)
{
    Console.WriteLine(l.Kiolvas(i));
}
