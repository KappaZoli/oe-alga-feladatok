using OE.ALGA;
using OE.ALGA.Adatszerkezetek;
using OE.ALGA.ALGAme;
using OE.ALGA.Optimalizalas;
using OE.ALGA.Tesztek;

//Jatek jatek = new Jatek();
//jatek.Start();


HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
DinamikusHatizsakPakolas opt = new DinamikusHatizsakPakolas(problema);



