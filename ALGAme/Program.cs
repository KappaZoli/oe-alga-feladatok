using OE.ALGA.Adatszerkezetek;
using OE.ALGA.ALGAme;

//Jatek jatek = new Jatek();
//jatek.Start();

TombSor<int> sor = new TombSor<int>(3);
sor.Sorba(1);
sor.Sorba(3);
sor.Sorba(2);

for (int i = 0; i < 4; i++)
{
    Console.WriteLine(sor.Sorbol());
}
