using System;
using System.Linq;
using System.Collections.Generic;

namespace labb2
{
    class Program
    {
        static void Main(string[] args)
        {

            string meny = "0";
            while (meny != "5")
            {
                Console.WriteLine("\n\nThis is the way");
                Console.WriteLine("1. Visa gångertabeller");
                Console.WriteLine("2. Kalkylera ett medelvärde, summa & min/max value av dina tal");
                Console.WriteLine("3. Här har du en slumpad array, kul va?");
                Console.WriteLine("4. Skapa personer");
                Console.WriteLine("5. Exit");
                Console.Write("\nVälj ett alternativ ");
                meny = Console.ReadLine();
                //Switch agerar som en branch för casen
                switch (meny)
                {
                    case "1": //case 1 är alternativ 1
                        caseOne();

                        break;//Break får loopen att lämna case 1

                    case "2": //alternativ 2
                        caseTwo();

                        break;

                    case "3": //alternativ 3
                        caseThree();

                        break;

                    case "4":
                        caseFour();

                        break;

                    case "5":
                        Console.Clear();
                        //behövs för att inte ha error
                        break;

                    //case "6":
                      //  caseSix();
                        //break;


                    default:
                        Console.Clear();
                        Console.Write("Error.");//skrivs ut när en annan tangent används än de i menyn

                        break;

                }
            }
        }
        public static void caseOne()
        {
            for (int i = 1; i <= 9; i++)
            {
                Console.WriteLine();
                for (int j = 1; j <= 9; j++)
                {
                    Console.Write("{0} ", i * j);
                } //Här loopar jag 2 gånger i en for loop för att kunna få ihop en gångertabell       
            }
        }

        public static void caseTwo()
        {
            double sum = 0, avg = 0;
            int u, n = 0;
            bool success = false;
            string input;

            Console.WriteLine("Skriv in hur många element du vill fylla din array med.");
            while (!success)
            {
                input = Console.ReadLine();
                success = Int32.TryParse(input, out n);

                if (!success)
                {
                    Console.WriteLine("Fel input, prova igen.");
                }
            }
            double[] alt2 = new double[n];

            Console.WriteLine("Skriv in {0} tal", n);

            for (u = 0; u < n; u++)
            {
                string input2 = Console.ReadLine();
                double x;
                success = double.TryParse(input2, out x);
                if (!success)
                {
                    Console.WriteLine("Fel input, prova igen.");
                    u--;
                    continue;
                }

                alt2[u] = x;

            }

            //I den här loopen gör jag det möjligt för användaren att lägga in X antal tal
            //Loopen gör att man kan lägga in 1 string, X gånger, sen konverteras de till double

            for (u = 0; u < n; u++)
            {
                sum += alt2[u];
            }
            //I den här loopen plussar jag ihop alla olika element i arrayn
            Console.WriteLine("\nSumman av dina tal är {0}", sum);
            avg = sum / 5;
            Console.WriteLine("och {0} är medelvärdet utav dina {1} tal.", avg, n);

            double minValue;
            double maxValue;

            Array.Sort(alt2);

            minValue = alt2[0];

            int length = alt2.Length;

            maxValue = alt2[length - 1];

            Console.WriteLine("Ditt minsta värde är {0}", minValue);
            Console.WriteLine("samtidigt som ditt högsta värde är {0}", maxValue);




            //int[] intalt2 = Alt2(alt2);

            //Console.WriteLine("Din högsta element var {0}", intalt2.Max()); Console.WriteLine("medans ditt minsta element var {0}.", intalt2.Min());
        }

        public static void caseThree()
        {
            int[] alt3 = new int[10];
            Random rng = new Random();

            for (int i = 0; i < 10; i++) //Varje gång elementet har en slumpad siffra går den vidare till nästa element
            {
                alt3[i] = rng.Next(0, 100); //Här väljer arrayn en slumpad siffra
            }
            Array.Sort(alt3);

            foreach (int value in alt3)
            {
                Console.Write(value + " ");
            }//Här loopas alla värden och skriver ut de
        }
        public static void caseFour()
        {
            string sex, eyeCol, namn, okej;
            hair har = new hair();

            List<person> ppl = new List<person>();
            while (true)
            {
                Console.WriteLine("Skriv in ett namn på din person");
                namn = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Skriv in vilket kön du vill ha (Male eller Female)");
                    okej = (Console.ReadLine());

                    if (!(okej == "male" || okej == "Male" || okej == "Female" || okej == "female"))
                    {

                        Console.WriteLine("Fel input, prova igen.");
                    }
                    else
                    {
                        sex = okej;
                        break;
                    }
                }
                Console.WriteLine("Skriv in vilken hårfärg du vill ha");
                har.color = Console.ReadLine();

                Console.WriteLine("Skriv in vilken ögonfärg det ska vara");
                eyeCol = Console.ReadLine();

                Console.WriteLine("Skriv in vilken hårlängd det ska vara");
                har.length = Convert.ToInt32(Console.ReadLine());



                DateTime BirthDay;
                while (true)
                {
                    Console.WriteLine("Skriv in vilket datum personen är född");
                    Console.WriteLine("Använd (yyyy-mm-dd)");
                    string wInput = Console.ReadLine();
                    if (!DateTime.TryParse(wInput, out BirthDay))
                    {
                        Console.WriteLine("Fel input, prova igen.");
                    }
                    else
                    {
                        break;
                    }
                }

                ppl.Add(new person(namn, sex, eyeCol, har, BirthDay));

                Console.WriteLine("Vill du mata in en till person? ja/nej");
                string ja = Console.ReadLine();
                if (ja == "nej")
                {
                    break;
                }
            }
            Console.WriteLine("Vill du lista upp alla personer? ja/nej");
            string val = Console.ReadLine();
            if (val == "ja")
            {
                foreach (var person in ppl)
                {
                    Console.WriteLine(person.name + " ");
                    Console.WriteLine(person.BirthDay.ToString() + " ");
                    Console.WriteLine(person.trait.color + " ");
                    Console.WriteLine(person.trait.length + " ");
                    Console.WriteLine(person.eyeCol + " ");
                    Console.WriteLine(person.Getsex() + "\n ");
                }
            }
            else
            {
                return;
            }
        }
        /*public static void caseSix()
        {
            foreach (var person in ppl)
            {
                Console.WriteLine(person.name + " ");
                Console.WriteLine(person.BirthDay.ToString() + " ");
                Console.WriteLine(person.trait.color + " ");
                Console.WriteLine(person.trait.length + " ");
                Console.WriteLine(person.eyeCol + " ");
                Console.WriteLine(person.Getsex() + "\n ");
            }
        }*/
    }
    public class person
    {
        public DateTime BirthDay;
        public hair trait;

        private string kon;
        public string eyeCol, name;

        public person(string Name, string sex, string EyeCol, hair hTrait, DateTime bd)
        {
            name = Name;
            BirthDay = bd;
            kon = sex;
            trait = hTrait;
            eyeCol = EyeCol;
        }
        public string Getsex()
        {
            return kon;
        }
        public void setsex(string sex)
        {
            kon = sex;
        }


    }
    public struct hair
    {
        public string color;
        public int length;


    }
}
