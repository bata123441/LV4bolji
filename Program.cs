using System;

namespace VjezbaLV4
{
    enum Mjeseci { Sijecanj = 1, Veljaca, Ozujak, Travanj, Svibanj, Lipanj, Srpanj, Kolovoz, Rujan, Listopad, Studeni, Prosinac }

    class Program
    {
        static void Main(string[] args)
        {
            // Test zadataka 1-3
            GeometrijskiLik.BojaGL();
            PravokutniTrokut t1 = new PravokutniTrokut(3, 4, "Zelena");
            Console.WriteLine($"Broj zelenih likova: {GeometrijskiLik.BrojZelenihLikova}");

            int[] statistika = new int[13];

            Console.WriteLine("\n--- IZBORNIK MJESECI ---");
            foreach (var m in Enum.GetValues(typeof(Mjeseci)))
                Console.WriteLine($"{(int)m} = {m}");

            Console.WriteLine("\nUpute: Upišite broj i lupite Enter. Ako želite izaći, pritisnite ESC tipku (bez pisanja broja).");

            while (true)
            {
                Console.Write("\nUnos (ili ESC za kraj): ");

                // KLJUČNA PROMJENA: Prvo provjeravamo pritisak JEDNE tipke
                ConsoleKeyInfo tipkaInfo = Console.ReadKey(true);

                // Ako je tipka ESC, odmah prekini
                if (tipkaInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("ESC pritisnut.");
                    break;
                }

                // Ako nije ESC, uzmi tu prvu tipku i dopusti korisniku da dopiše ostatak (ReadLine)
                string prviZnak = tipkaInfo.KeyChar.ToString();
                Console.Write(prviZnak); // Ispiši taj prvi znak da korisnik vidi što piše
                string ostatak = Console.ReadLine();
                string unos = (prviZnak + ostatak).Trim();

                try
                {
                    if (!int.TryParse(unos, out int broj))
                    {
                        if (unos.Contains(".") || unos.Contains(","))
                            throw new Exception("POGREŠKA: Realni broj!");
                        else
                            throw new StringException("POGREŠKA: String!");
                    }

                    if (Enum.IsDefined(typeof(Mjeseci), broj))
                    {
                        Console.WriteLine($"\nOdabrali ste: {(Mjeseci)broj}");
                        statistika[broj]++;
                    }
                    else
                    {
                        Console.WriteLine("\nNepostojeći mjesec.");
                        statistika[0]++;
                    }
                }
                catch (StringException ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                    IspisiStatistiku(statistika);
                    Console.WriteLine("Program završen zbog kritične pogreške.");
                    Console.ReadKey();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message + " Nastavite unos.");
                }
            }

            IspisiStatistiku(statistika);
            Console.WriteLine("\nKraj. Pritisnite bilo što.");
            Console.ReadKey();
        }

        static void IspisiStatistiku(int[] polje)
        {
            Console.WriteLine("\n--- STATISTIKA ---");
            for (int i = 1; i <= 12; i++)
                Console.WriteLine($"{(Mjeseci)i}: {polje[i]} puta");
            Console.WriteLine($"Pogrešni cijeli brojevi: {polje[0]}");
        }
    }
}