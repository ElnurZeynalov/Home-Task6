using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region FirstOperation
            Console.WriteLine("Sisteme nece eded kitab daxil edeceksiniz?");
            int Quantity = GetInfoInt("Kitablarin sayini daxil edin: ", 0, int.MaxValue);
            Book[] Books = new Book[Quantity];
            for (int i = 0; i < Quantity; i++)
            {
                Console.WriteLine("\n---------------------------\n" + $"{i + 1} Kitabin melumatlari" + "\n---------------------------\n");
                int no = i + 1;
                string genere = GetInfoString("Kitabin janirini daxil edin: ", 2, 30);
                string name = GetInfoString("Kitabin adini daxil edin: ", 2, 30);
                int count = GetInfoInt("Kitabin sayini daxil edin: ", 0, int.MaxValue);
                double price = GetInfoDouble("Kitabin qiymetini daxil edin: ", 0.2, 200);
                Books[i] = new Book(no, name, price, genere)
                {
                    Count = count,
                    Name = name,
                    Price = price,
                    Genre = genere,
                    No = no,
                };
            }
            #endregion
            #region Selection part
            Console.WriteLine("\n===============================\n1.Kitablari qiymete gore filterle\n2.Kitablar icinde axtaris" +
                "\n3.Butun kitablari goster\n4.Proqrami bagla\n===============================\n");
            int Choose = GetInfoInt("Reqemi daxil edin: ", 0, 5);
            switch (Choose)
            {
                case (1):
                    Console.WriteLine("Min ve Maksimim Qiymmetleri daxil edin");
                    double min = GetInfoDouble("Min qiymet: ", 0, int.MaxValue);
                    double max = GetInfoDouble("Max qiymet: ", 0,int.MaxValue);
                    foreach (var item in SelectiveValue(Books, min, max))
                    {
                        Console.WriteLine(item.GetInfo());
                    }
                    break;
                case (2):
                    string SearchedName = GetInfoString("Kitabin adini daxil edin: ", 3, 30);
                    foreach (var item in SelectiveName(Books, SearchedName))
                    {
                        Console.WriteLine(item.GetInfo());
                    }
                    break;
                case (3):
                    for (int i = 0; i < Books.Length; i++)
                    {
                        Console.WriteLine("\n===============================\n" + $"{i + 1}. Kitab: ");
                        Console.WriteLine(Books[i].GetInfo());
                    }
                    break;
                case (4):
                    break;
            }
            #endregion
        }
        static int GetInfoInt(string str, int min, int max)
        {
            //string valueStr;
            int value;
            do
            {
                Console.Write(str);
                value = Convert.ToInt32(Console.ReadLine());
                #region CheckInt
                //    valueStr = Console.ReadLine();
                //    while (CheckInt(valueStr) != true)
                //{   
                //    Console.Write("Sayini yalniz reqemle daxil edin: ");
                //    valueStr = Console.ReadLine();
                //}
                //    value = Convert.ToInt32(valueStr);
                #endregion
                if (value <= min)
                    Console.WriteLine("\n==========================\n" + $"{min} Boyuk bir reqem daxil edin" + "\n==========================\n");
                else if (value >= max)
                    Console.WriteLine("\n==========================\n" + $"{max} kicik bir reqem daxil edin" + "\n==========================\n");
            } while (value <= min || value >= max);
            return value;
        }
        static string GetInfoString(string str, int min, int max)
        {
            string value;
            do
            {
                Console.Write(str);
                value = Console.ReadLine();
                if (value.Length <= min)
                    Console.WriteLine("\n==========================\n" + $"Daxil edilen deyerin sayi {min} kicik ola bilmez" + "\n==========================\n");
                else if (value.Length >= max)
                    Console.WriteLine("\n==========================\n" + $"Daxil edilen deyerin sayi {max} boyuk ola bilmez" + "\n==========================\n");
            } while (value.Length <= min || value.Length >= max);
            return value;
        }
        static double GetInfoDouble(string str, double min, double max)
        {
            double value;
            do
            {
                Console.Write(str);
                value = Convert.ToDouble(Console.ReadLine());
                if (value <= min)
                    Console.WriteLine("\n==========================\n" + $"{min} Boyuk bir reqem daxil edin" + "\n==========================\n");
                else if (value >= max)
                    Console.WriteLine("\n==========================\n" + $"{max} kicik bir reqem daxil edin" + "\n==========================\n");
            } while (value <= min || value > max);
            return value;
        }
        static Book[] SelectiveValue(Book[] books, double min, double max)
        {
            int count = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Price >= min && books[i].Price <= max)
                {
                    count++;
                }

            }
            Book[] books2 = new Book[count];
            int count2 = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Price >= min && books[i].Price <= max)
                {
                    books2[count2] = books[i];
                    count2++;
                }
            }
            if (books2.Length == 0)
                Console.WriteLine("Axtardiginiz qiymetde kitab sistemde movcud deyil");
            return books2;
        }
        static Book[] SelectiveName(Book[] books, string SearchedName)
        {
            int count = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Name == SearchedName)
                {
                    count++;
                }
            }
            Book[] books2 = new Book[count];
            int count2 = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Name == SearchedName)
                {
                    books2[count2] = books[i];
                    count2++;
                }
            }
            if(books2.Length == 0)
                Console.WriteLine("\nAxtardiginiz adda kitab movcud deyil");
            return books2;
        }
        //Yazmadim cunki double deyerde daxil ede bilmedim. Hemde mene aid deyil :D 
        #region CheckInt
        //static bool CheckInt(string input)
        //{
        //    char[] Numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        //    int total = 0;
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        for (int j = 0; j < Numbers.Length; j++)
        //        {
        //            if (input[i] == Numbers[j])
        //                 total++;
        //        }

        //    }
        //    if (total == input.Length)
        //        return true;
        //    else
        //        return false;
        //}
        #endregion
    }
}
