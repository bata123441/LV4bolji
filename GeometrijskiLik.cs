using System;

namespace VjezbaLV4
{
    public abstract class GeometrijskiLik
    {
        public string Boja { get; set; }

        // Statički brojač (Zadatak 2b)
        public static int BrojZelenihLikova = 0;

        public GeometrijskiLik(string boja)
        {
            this.Boja = boja;
            if (boja.ToLower() == "zelena")
                BrojZelenihLikova++;
        }

        // Apstraktne metode (Zadatak 1)
        public abstract void Crtaj();
        public abstract double Povrsina();

        // Statička metoda (Zadatak 2d)
        public static void BojaGL()
        {
            Console.WriteLine("Zadana boja klase GeometrijskiLik je: Zelena");
        }
    }
}