using NUnit.Framework;
using System;
using OE.ALGA.Optimalizalas;

namespace OE.ALGA.Tesztek.Optimalizalas


//public static readonly bool[] uresPakolas = [false, false, false, false, false, false];
//public static readonly bool[] feligPakolas = [false, true, false, true, false, false];
//public static readonly bool[] teljesPakolas = [true, true, true, true, true, true];

//public static readonly int[] jegyzet_w = [2, 1, 1, 1, 3, 2];
//public static readonly float[] jegyzet_p = [4, 3, 2, 8, 7, 5];
//public static readonly int jegyzet_n = jegyzet_w.Length;
//public static readonly int jegyzet_Wmax = 4;
//public static readonly float jegyzet_optimalis_ertek = 16;
//public static readonly bool[] jegyzet_optimalis_pakolas = [false, true, false, true, false, true];

//public static readonly int[] nagy_w = [21, 41, 26, 11, 37, 25, 25, 44, 33, 29, 32, 52, 41, 62, 56, 81, 43];
//public static readonly float[] nagy_p = [4, 3, 2, 8, 7, 5, 4, 3, 2, 5, 3, 9, 5, 1, 7, 9, 4];
//public static readonly int nagy_n = nagy_w.Length;
//public static readonly int nagy_Wmax = 100;
//public static readonly float nagy_optimalis_ertek = 24;
//public static readonly bool[] nagy_optimalis_pakolas = [true, false, false, true, true, true, false, false, false, false, false, false, false, false, false, false, false];

{
    [TestFixture(Category = "Optimalizalas", TestName = "07 - Hátiszák Tesztek")]
    public class HatizsakTesztek
    {
        [TestCase]
        public void UresTeszt()
        {
            HatizsakProblema problema = new HatizsakProblema(0, 0, [], []);
            Assert.Multiple(() =>
            {
                Assert.That(problema.OsszSuly(PakolasTesztEsetek.uresPakolas), Is.EqualTo(0));
                Assert.That(problema.OsszSuly(PakolasTesztEsetek.teljesPakolas), Is.EqualTo(0));
                Assert.That(problema.OsszSuly(PakolasTesztEsetek.feligPakolas), Is.EqualTo(0));
            });
            Assert.Multiple(() =>
            {
                Assert.That(problema.OsszErtek(PakolasTesztEsetek.uresPakolas), Is.EqualTo(0));
                Assert.That(problema.OsszErtek(PakolasTesztEsetek.teljesPakolas), Is.EqualTo(0));
                Assert.That(problema.OsszErtek(PakolasTesztEsetek.feligPakolas), Is.EqualTo(0));
            });
            Assert.Multiple(() =>
            {
                Assert.That(problema.Ervenyes(PakolasTesztEsetek.uresPakolas), Is.True);
                Assert.That(problema.Ervenyes(PakolasTesztEsetek.teljesPakolas), Is.True);
                Assert.That(problema.Ervenyes(PakolasTesztEsetek.feligPakolas), Is.True);
            });
        }
        [TestCase]
        public void SulyTeszt()
        {
            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
            Assert.Multiple(() =>
            {
                Assert.That(problema.OsszSuly(PakolasTesztEsetek.uresPakolas), Is.EqualTo(0));
                Assert.That(problema.OsszSuly(PakolasTesztEsetek.teljesPakolas), Is.EqualTo(10));
                Assert.That(problema.OsszSuly(PakolasTesztEsetek.feligPakolas), Is.EqualTo(2));
            });
        }
        [TestCase]
        public void JosagTeszt()
        {
            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
            Assert.Multiple(() =>
            {
                Assert.That(problema.OsszErtek(PakolasTesztEsetek.uresPakolas), Is.EqualTo(0));
                Assert.That(problema.OsszErtek(PakolasTesztEsetek.teljesPakolas), Is.EqualTo(29));
                Assert.That(problema.OsszErtek(PakolasTesztEsetek.feligPakolas), Is.EqualTo(11));
            });
        }
        [TestCase]
        public void ErvenyesTeszt()
        {
            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
            Assert.Multiple(() =>
            {
                Assert.That(problema.Ervenyes(PakolasTesztEsetek.uresPakolas), Is.True);
                Assert.That(problema.Ervenyes(PakolasTesztEsetek.teljesPakolas), Is.False);
                Assert.That(problema.Ervenyes(PakolasTesztEsetek.feligPakolas), Is.True);
            });
        }
    }

    [TestFixture(Category = "Optimalizalas", TestName = "07 - Nyers Ero Tesztek")]
    public class NyersEroTesztek
    {
        [TestCase]
        public void UresTeszt()
        {
            int[] A = { 4, 6, 7, 4, 2, 1 };
            NyersEro<int> opt = new NyersEro<int>(
                0,
                x => { Guardian.Recursion.CheckStackTrace(); return A[x - 1]; },
                x => { Guardian.Recursion.CheckStackTrace(); return x; });
            Assert.Multiple(() =>
            {
                Assert.That(opt.OptimalisMegoldas(), Is.EqualTo(4));
                Assert.That(opt.LepesSzam, Is.EqualTo(0));
            });
        }
        [TestCase]
        public void TombLegnagyobbEleme()
        {
            int[] A = { 4, 6, 7, 4, 2, 1 };
            NyersEro<int> opt = new NyersEro<int>(
                A.Length,
                x => { Guardian.Recursion.CheckStackTrace(); return A[x - 1]; },
                x => { Guardian.Recursion.CheckStackTrace(); return x; });
            Assert.Multiple(() =>
            {
                Assert.That(opt.OptimalisMegoldas(), Is.EqualTo(7));
                Assert.That(opt.LepesSzam, Is.EqualTo(5));
            });
        }

    }

    [TestFixture(Category = "Optimalizalas", TestName = "07 - Nyers Ero Hátizsák Pakolás Tesztek")]
    public class NyersEroHatizsakPakolasTesztek
    {
        [TestCase]
        public void UresTeszt()
        {
            HatizsakProblema problema = new HatizsakProblema(0, 0, [], []);
            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
            Assert.Multiple(() =>
            {
                Assert.That(opt.OptimalisErtek(), Is.EqualTo(0));
                Assert.That(opt.OptimalisMegoldas(), Is.EquivalentTo(Array.Empty<bool>()));
                Assert.That(opt.LepesSzam, Is.EqualTo(0));
            });
        }
        [TestCase]
        public void JegyzetbenLevoPeldaErtekTeszt()
        {
            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
            Assert.Multiple(() =>
            {
                Assert.That(opt.OptimalisErtek(), Is.EqualTo(PakolasTesztEsetek.jegyzet_optimalis_ertek));
                Assert.That(opt.LepesSzam, Is.EqualTo(63));
            });
        }
        [TestCase]
        public void JegyzetbenLevoPeldaMegoldasTeszt()
        {
            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.jegyzet_n, PakolasTesztEsetek.jegyzet_Wmax, PakolasTesztEsetek.jegyzet_w, PakolasTesztEsetek.jegyzet_p);
            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
            Assert.Multiple(() =>
            {
                Assert.That(opt.OptimalisMegoldas(), Is.EquivalentTo(PakolasTesztEsetek.jegyzet_optimalis_pakolas));
                Assert.That(opt.LepesSzam, Is.EqualTo(63));
            });
        }
        [TestCase]
        public void NagyPeldaMegoldasErtekTeszt()
        {
            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.nagy_n, PakolasTesztEsetek.nagy_Wmax, PakolasTesztEsetek.nagy_w, PakolasTesztEsetek.nagy_p);
            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
            Assert.Multiple(() =>
            {
                Assert.That(opt.OptimalisErtek(), Is.EqualTo(PakolasTesztEsetek.nagy_optimalis_ertek));
                Assert.That(opt.LepesSzam, Is.EqualTo(131071));
            });
        }
        [TestCase]
        public void NagyPeldaMegoldasTeszt()
        {
            HatizsakProblema problema = new HatizsakProblema(PakolasTesztEsetek.nagy_n, PakolasTesztEsetek.nagy_Wmax, PakolasTesztEsetek.nagy_w, PakolasTesztEsetek.nagy_p);
            NyersEroHatizsakPakolas opt = new NyersEroHatizsakPakolas(problema);
            Assert.Multiple(() =>
            {
                Assert.That(opt.OptimalisMegoldas(), Is.EquivalentTo(PakolasTesztEsetek.nagy_optimalis_pakolas));
                Assert.That(opt.LepesSzam, Is.EqualTo(131071));
            });
        }
    }
}