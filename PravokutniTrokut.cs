using System;

namespace VjezbaLV4
{
    public class PravokutniTrokut : GeometrijskiLik, IUsporediPovrsinu<PravokutniTrokut>
    {
        public double KatetaA { get; set; }
        public double KatetaB { get; set; }

        public PravokutniTrokut(double a, double b, string boja) : base(boja)
        {
            this.KatetaA = a;
            this.KatetaB = b;
        }

        public override void Crtaj()
        {
            Console.WriteLine($"Crtam trokut: Boja={Boja}, Površina={Povrsina()}");
        }

        public override double Povrsina()
        {
            return (KatetaA * KatetaB) / 2.0;
        }

        public int Usporedi(PravokutniTrokut drugi)
        {
            double p1 = this.Povrsina();
            double p2 = drugi.Povrsina();
            if (p1 == p2) return 0;
            return (p1 > p2) ? 1 : 2;
        }
    }
}