using OE.ALGA.Adatszerkezetek;
using OE.ALGA.ALGAme;

//Jatek jatek = new Jatek();
//jatek.Start();

TombLista<int> lista = new TombLista<int>();
lista.Hozzafuz(1);
lista.Hozzafuz(3);
lista.Hozzafuz(1);
lista.Torol(0);


for (int i = 0; i < lista.Elemszam; i++)
{
    Console.WriteLine(lista.Kiolvas(i));
}
