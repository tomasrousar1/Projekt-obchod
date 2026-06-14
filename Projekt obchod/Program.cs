    namespace Projekt_Obchod
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                List<Produkty> produtcs = new List<Produkty>();
                using (StreamReader sr = new StreamReader("Data.csv"))
                {
                    sr.ReadLine();
                    string radek = sr.ReadLine();
                    while (radek != null)
                    {

                        string[] poleuser = radek.Split(",");

                        Produkty prod = new Produkty();
                        prod.ID = int.Parse(poleuser[0]);
                        prod.Name = poleuser[1];
                        prod.Pocet = int.Parse(poleuser[2]);
                        prod.Kategorie = poleuser[3];
                        prod.Cena = decimal.Parse(poleuser[4]);
                        prod.MinimalniPocet = int.Parse(poleuser[5]);
                        produtcs.Add(prod);

                        radek = sr.ReadLine();

                    }

                }

                while (true)
                {
                
                    int pomocnik = 0;
                    foreach (Produkty vec in produtcs)
                    {
                        vec.Pocet -= 2;
                        if (vec.Pocet <= vec.MinimalniPocet)
                        {
                            pomocnik++;
                        }
                    }
                    if (pomocnik>0)
                    {
                        Console.Clear();
                        Console.WriteLine("kolik chcete pridat produktu od kazdeho ktereho bude malo??");
                        int pridani = int.Parse(Console.ReadLine());
                        foreach (Produkty vec in produtcs)
                        {
                        
                            if (vec.Pocet <= vec.MinimalniPocet)
                            {
                            
                                vec.Pocet += pridani;
                            }
                        }
                    }
                
                    Console.Clear();
                    Console.WriteLine("1. Vypsat všechny produkty");
                    Console.WriteLine("2. Vypsat produkty podle vybrané kategorie");
                    Console.WriteLine("3. Naskladnění nebo odebrání hromadně u celé kategorie");
                    Console.WriteLine("4. Přidat nový produkt včetně kategorie");
                    Console.WriteLine("5. Zobrazit produkty s nízkým počtem kusů");
                    Console.WriteLine("6. Uložit data do souboru");
                    int vyber = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (vyber)
                    {
                        case 1:
                            foreach (Produkty vec in produtcs)
                            {
                                Console.WriteLine($"ID: {vec.ID}, Nazev: {vec.Name}, Pocet: {vec.Pocet}, Kategorie: {vec.Kategorie}, Cena: {vec.Cena} Kc");
                            
                            
                            }
                            Console.WriteLine();
                            Console.WriteLine("zmacni cokoliv pro pokracovani: ");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("jakou kategorii chcete vypsat? \r\n(elektro\r\njidlo\r\nobleceni\r\nnaradi\r\npapirnictvi\r\ndrogerie\r\nsport\r\nhracky\r\ndomacnost\r\nzahrada)");
                            string kat = Console.ReadLine();
                            foreach (Produkty vec in produtcs)
                            {
                                if (vec.Kategorie == kat)
                                {
                                    Console.WriteLine($"ID: {vec.ID}, Nazev: {vec.Name}, Pocet: {vec.Pocet}, Kategorie: {vec.Kategorie}, Cena: {vec.Cena} Kc");
                                }
                            }
                            Console.WriteLine();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("jakou kategorii chcete hromadne doskladnit nebo odebrat? \r\n(elektro\r\njidlo\r\nobleceni\r\nnaradi\r\npapirnictvi\r\ndrogerie\r\nsport\r\nhracky\r\ndomacnost\r\nzahrada)");
                            string kat2 = Console.ReadLine();
                            Console.WriteLine("pokud chcete odebirat zmacknete 1 pokud pricitat tak 2");
                            int vybrano = int.Parse(Console.ReadLine());
                            switch (vybrano)
                            {
                                case 1:
                                    Console.WriteLine("kolik chcete odebrat?");
                                    int odebrani = int.Parse(Console.ReadLine());
                                    foreach (Produkty vec in produtcs)
                                    {
                                        if (vec.Kategorie == kat2)
                                        {
                                            vec.Pocet -=odebrani;
                                        }
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("kolik chcete pridat?");
                                    int pridani = int.Parse(Console.ReadLine());
                                    foreach (Produkty vec in produtcs)
                                    {
                                        if (vec.Kategorie == kat2)
                                        {
                                            vec.Pocet += pridani;
                                        }
                                    }
                                    break;
                            }
                            break;
                        case 4:
                            Console.WriteLine("ID: "+ (produtcs.Count+1));
                            Console.WriteLine("jmeno produktu: ");
                            string nazev = Console.ReadLine();
                            Console.WriteLine("kolik jich bude naskladneno: ");
                            int poc = int.Parse(Console.ReadLine());
                            Console.WriteLine("Jaka to bude kategorie? \r\n(elektro\r\njidlo\r\nobleceni\r\nnaradi\r\npapirnictvi\r\ndrogerie\r\nsport\r\nhracky\r\ndomacnost\r\nzahrada)\r\nmuzes si napsat i novou");
                            string kateg = Console.ReadLine();
                            Console.WriteLine("cena: ");
                            int price = int.Parse(Console.ReadLine());
                            Produkty prod = new Produkty();
                            prod.Name = nazev;
                            prod.ID = produtcs.Count + 1;
                            prod.Pocet = poc;
                            prod.Kategorie = kateg;
                            prod.Cena = price;
                            prod.MinimalniPocet = 3;
                            produtcs.Add(prod);
                            Console.WriteLine("produkt pridan");
                            Console.ReadKey();
                            break;
                        case 5:
                        
                            Console.WriteLine("zobrazit produkty s maximalne: ");
                            int max = int.Parse(Console.ReadLine());
                            foreach (Produkty produkt in produtcs)
                            {
                                if (produkt.Pocet <= max)
                                {
                                    Console.WriteLine($"ID: {produkt.ID}, Nazev: {produkt.Name}, Pocet: {produkt.Pocet}, Kategorie: {produkt.Kategorie}, Cena: {produkt.Cena} Kc");
                                }
                            }
                            Console.ReadKey();
                            break;
                        case 6:
                            using (StreamWriter sw = new StreamWriter("Data.csv", false))
                            {

                                foreach (Produkty produkt in produtcs)
                                {
                                    sw.WriteLine($"{produkt.ID},{produkt.Name},{produkt.Pocet},{produkt.Kategorie},{produkt.Cena}.{produkt.MinimalniPocet}");
                                }
                            }
                            Console.WriteLine("Uloženo!");
                            Console.WriteLine();
                            break;
                    
                    }

                }


            }
        }
    }

