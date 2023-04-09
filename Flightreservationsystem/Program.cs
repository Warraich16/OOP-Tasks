using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Flightreservationsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string n;
            string p;
            string[] name = new string[5];
            string[] password = new string[5];
            string[] flight = new string[5];
            string[] companyname = new string[5];
            string[] flightdeparture = new string[5];
            string[] flightdestination = new string[5];
            string[] flighttime = new string[5];
            string[] flightdate = new string[5];
            int flightcount = 0;
            string flightnumber;
            int option;
            string path="E:\\OOP Lab\\Flightreservationsystem\\flightdata.txt";
            readdata(flight, companyname, flightdeparture, flightdestination,
            flighttime, flightdate, ref flightcount, path);


            do
            {
                option = loginmenu();
                if (option == 1)
                {
                    clearScreen();
                    Console.WriteLine("Enter your name: ");
                        n = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                        p = Console.ReadLine();

                    if (n == "Admin" && p == "oslo")
                    {
                        clearScreen();
                        
                        int adminoption = adminmenu();
                        if (adminoption == 1)
                        {
                            clearScreen();
                            addschedule(adminoption, flight, companyname, flightdeparture, flightdestination,
                            flighttime, flightdate, ref flightcount);
                        }
                        else if (adminoption == 2)
                        {
                            clearScreen();
                            Console.WriteLine("Enter flight number whose info you want to update:");
                            flightnumber = Console.ReadLine();
                            updateschedule(flightnumber, flight, flightdate, flighttime, flightdeparture, flightdestination);
                        }
                        else if (adminoption == 3)
                        {
                            clearScreen();
                            Console.WriteLine("Enter flight number whose data you want to remove:");
                            flightnumber =Console.ReadLine();
                            removeflight(flightnumber, flight, companyname, flightdeparture, flightdestination,
                            flighttime, flightdate, ref flightcount);
                        }
                        else if (adminoption == 4)
                        {
                            clearScreen();
                            ViewSchedule(flight, companyname, flightdeparture, flightdestination,
                            flighttime, flightdate, ref flightcount);
                        }

                       
                    }

                }
                storeflights(flight, companyname, flightdeparture, flightdestination,
                flighttime, flightdate, ref flightcount, path);
            }
            while (option != 2);
            clearScreen();


            
        }

        static void storeflights(string[] flight, string[] companyname, string[] flightdeparture, string[] flightdestination,
            string[] flighttime, string[] flightdate, ref int flightcount,string path)
        {
            StreamWriter flightdata = new StreamWriter(path,false);
              for (int i=0;i<flightcount;i++)
            {
                flightdata.WriteLine(flight[i] + "," + companyname[i] + "," + flightdeparture[i] + "," +
                flightdestination[i] + "," + flighttime[i] + "," + flightdate[i]);
            }
            flightdata.Flush();
            flightdata.Close();
        }

        static string parseData(string line, int field)
        {
            int comma = 0;
            string data = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    data = data + line[i];
                }
            }
            return data;
        }

        static void readdata(string[] flight, string[] companyname, string[] flightdeparture, string[] flightdestination,
            string[] flighttime, string[] flightdate, ref int flightcount, string path)
        {
            StreamReader flightdata = new StreamReader(path);
            string record;
            while((record = flightdata.ReadLine()) !=null)
            {
                flight[flightcount] = parseData(record, 0);
                companyname[flightcount] = parseData(record, 1);
                flightdeparture[flightcount] = parseData(record, 2);
                flightdestination[flightcount] = parseData(record, 3);
                flighttime[flightcount] = parseData(record, 4);
                flightdate[flightcount] = parseData(record, 5);
                flightcount++;
            }
            flightdata.Close();
        }


        static int loginmenu()
        {
            int option;
            Console.WriteLine("Press 1 to login");
            Console.WriteLine("Press 2 to Exit");
            option = int.Parse(Console.ReadLine());
            return option;


        }
        
        static int adminmenu()
        {
            int option;
            Console.WriteLine("1. Add Flight Schedule ");
            Console.WriteLine("2. Update Flight Schedule");
            Console.WriteLine("3. Remove FLight");
            Console.WriteLine("4. View FLight Schedule");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void addschedule(int adminoption, string[] flight, string[] companyname,string[] flightdeparture,string[] flightdestination,
            string[] flighttime,string[] flightdate,ref int flightcount)
        {
          
                Console.WriteLine("Enter Number of the flight: ");
                flight[flightcount] = Console.ReadLine();
                Console.WriteLine("Enter Company name of the flight: ");
                companyname[flightcount] = Console.ReadLine();
                Console.WriteLine("Enter Departure of the flight: ");
                flightdeparture[flightcount] = Console.ReadLine();
                Console.WriteLine("Enter Destination of the flight: ");
                flightdestination[flightcount] = Console.ReadLine();
                Console.WriteLine("Enter time of the flight: ");
                flighttime[flightcount] = Console.ReadLine();
                Console.WriteLine("Enter date of the flight: ");
                flightdate[flightcount] = Console.ReadLine();
                flightcount++;

            }
        

        static void updateschedule(string flightnumber,string[] flight, string[] flightdate, string[] flighttime, string[] flightdeparture, string[] flightdestination)
        {
           

                for (int i = 0; i < 5; i++)
                {


                    if (flightnumber == flight[i])
                    {
                        Console.WriteLine("Enter New Date of the Flight: ");
                        flightdate[i] = Console.ReadLine();
                        Console.WriteLine("Enter New Time of the Flight: ");
                        flighttime[i] = Console.ReadLine();
                        Console.WriteLine("Enter New Departure of the Flight: ");
                        flightdeparture[i] = Console.ReadLine();
                        Console.WriteLine("Enter New Destination of the Flight: ");
                        flightdestination[i] = Console.ReadLine();
                        break;



                    }
                    else
                    {
                        Console.WriteLine("The flight number you are searching does not exist");
                        Console.ReadKey();
                    }
                }
            }
        

    static void removeflight(string flightnumber,string[] flight, string[] companyname, string[] flightdeparture, string[] flightdestination,
            string[] flighttime, string[] flightdate, ref int flightcount)
    {
        int flightindex = 0;
        flightindex = int.Parse(Console.ReadLine());
        for (int i=0; i<flightcount;i++)
        {
            if (flightnumber==flight[i])
            {
                flightindex = i;
                break;
            }
        }

        for (int i=flightindex;i<flightcount-1;i++)
        {
            flight[i] =flight[i + 1];
            companyname[i] =companyname[i + 1];
            flightdeparture[i] =flightdeparture[i + 1];
            flightdestination[i] =flightdestination[i + 1];
            flightdate[i] =flightdate[i + 1];
            flighttime[i] =flighttime[i + 1];

  
        }
        flightcount--;

    }

    static void ViewSchedule(string[] flight, string[] companyname, string[] flightdeparture, string[] flightdestination,
            string[] flighttime, string[] flightdate, ref int flightcount)
    {
        Console.WriteLine("Flight Number\t\tCompany Name\t\tFlight Departure\t\tFlight Destination\t\tFlight Date\t\tFlight Time");
        for (int i=0;i<flightcount;i++)
        {
            Console.WriteLine(flight[i] + "\t\t" + companyname[i] + "\t\t" + flightdeparture[i] + "\t\t" + flightdestination[i] +
             "\t\t" + flightdate[i] + "\t\t" + flighttime[i]);
        }
    }


    }
}
