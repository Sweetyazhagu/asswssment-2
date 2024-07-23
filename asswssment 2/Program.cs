using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace assessment_2
{
    internal class Program
    {

        static string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string backup = "backup.txt";
        static void Main(string[] args)
        {


            char ans = 'n';
            do
            {
                Console.WriteLine("\n***********************************");
                Console.WriteLine("Hotel Management System Menu:       *");
                Console.WriteLine("*************************************");
                Console.WriteLine("*1.Add Room                         *");
                Console.WriteLine("*2.Display Rooms                    *");
                Console.WriteLine("*3.Allocate Room                    *");
                Console.WriteLine("*4.De-Allocate Room                 *");
                Console.WriteLine("*5.Display Room Allocation          *");
                Console.WriteLine("*6.Billing                          *");
                Console.WriteLine("*7.Save Room Allocation to File     *");
                Console.WriteLine("*8.Show Room Allocation from File   *");
                Console.WriteLine("*9. Admin access only               *");
                Console.WriteLine("*0.Exit                             *");
                Console.WriteLine("*************************************");
                Console.WriteLine("Please enter your choice (0-9):");


                try
                {
                   
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddRoom();
                            break;
                        case 2:
                            DisplayRooms();
                            break;
                        case 3:
                            AllocateRoom();
                            break;
                        case 4:
                            DeAllocateRoom();
                            break;
                        case 5:
                            DisplayRoomAllocations();
                            break;
                        case 6:
                            Console.WriteLine("Billing Feature is Under Construction and will be added soon...!!!");
                            break;
                        case 7:
                            SaveRoomAllocationsToFile();
                            break;
                        case 8:
                            ShowRoomAllocationsFromFile();
                            break;
                        case 9:
                            adminaccess();
                            break;

                        case 0:
                            Console.WriteLine("Exiting...");
                            break;
                        
                        default:
                           // Console.WriteLine(" Invalid Number");
                            //break;
                            throw new InvalidOperationException();
                    }


                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: The input is not a valid number. Please enter a numeric value.");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: The entered value does not match any existing items." + ex.Message);
                }


                Console.Write("\nWould You Like To Continue(Y/N):");
                ans = Convert.ToChar(Console.ReadLine());
            }


            while (ans == 'y');


        }

        static void AddRoom() // create a method for add rooms
        {

            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HotelManagement");
            string filePath = Path.Combine(directoryPath, "lhms_Roomadded.txt");
            
                // Check if the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    // Create the directory
                    Directory.CreateDirectory(directoryPath);
                    Console.WriteLine("Directory created: " + directoryPath);
                }


            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // Create the file
                using (FileStream fs = File.Create(filePath))
                {
                    Console.WriteLine("File created: " + filePath);
                }
            }
            else
            {
                Console.WriteLine("File already exists: " + filePath);
            }
                Console.WriteLine("\n\n****************");
                Console.WriteLine("     Add Room       ");
                Console.WriteLine("\n****************");
                Console.WriteLine("Enter the Room NUmber");
                int roomnumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Floor numbber");
                int floornumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Room Created by: ");
                string createname = Convert.ToString(Console.ReadLine());
            // storing the input in the text file as lhms_Roomadded.txt
            using (StreamWriter writer = new StreamWriter(myDocuments + "\\HotelManagement\\lhms_Roomadded.txt", true))
            {
                writer.WriteLine("**********************************");
                writer.WriteLine("  Room Added " + DateTime.Now);
                writer.WriteLine("********************************");
                writer.WriteLine("\n Room Number: " + roomnumber + "\n Floor Number: " + floornumber);
                writer.WriteLine("Room Created by: " + createname);
                writer.WriteLine("**************************");
            }

        }
        // creating the method to display the aded rooms
        static void DisplayRooms()
        {
            // display the text saved in add rooms
            string allfileText = File.ReadAllText(myDocuments + "\\HotelManagement\\lhms_Roomadded.txt");
            Console.WriteLine(allfileText);
            Console.ReadLine();



        }

        // creating the method for roomallocation 
        static void AllocateRoom()
        {
            Console.WriteLine("\n\n****************");
            Console.WriteLine("    Allocate Room   ");
            Console.WriteLine("\n****************");
            Console.WriteLine("Enter the room number:");
            int roomnumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Floor Number:");
            int floornumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the coustmer full name:");
            string customername = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter customer phone number");
            int phonenumber= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a check in date (format: yyyy-MM-dd):");
            string checkin = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter a check Out date (format: yyyy-MM-dd");
            string checkout = Convert.ToString(Console.ReadLine());
            // storing the input in the text file as lhms_roomallocate.txt
            using (StreamWriter writer = new StreamWriter(myDocuments + "\\HotelManagement\\lhms_Roomallocate.txt", true))
            {
                writer.WriteLine("*************************************");
                writer.WriteLine("  Allocate Room " + DateTime.Now); 
                writer.WriteLine("*************************************");
                writer.WriteLine("\n Room Number: " + roomnumber + "\n Floor Number: " + floornumber);
                writer.WriteLine(" customer name: " + customername + "\n customer phone number: " + phonenumber);
                writer.WriteLine("Check In Date: " + checkin+ "\n Check out: " + checkout);
                writer.WriteLine("*************************************");
            }

        }
        //creating method for deallocateroom
        static void DeAllocateRoom()
        {
            Console.WriteLine("\n****************");
            Console.WriteLine("  DeAllocate Room ");
            Console.WriteLine("\n****************");
            Console.WriteLine("Enter the Room NUmber");
            int roomnumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Floor Number:");
            int floornumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the coustmer full name:");
            string customername = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter customer phone number");
            int phonenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name");
            string employeename = Convert.ToString(Console.ReadLine());
            // storing the input in the text file as lhms_roomallocate.txt
            using (StreamWriter writer = new StreamWriter(myDocuments + "\\HotelManagement\\lhms_Roomallocate.txt", true))
            {
                writer.WriteLine("***************************************");
                writer.WriteLine(" DeAllocate Room " + DateTime.Now);
                writer.WriteLine("***************************************");
                writer.WriteLine("\n Room Number: " + roomnumber + "\n Floor Number: " + floornumber);
                writer.WriteLine(" customer name: " + customername + "\n customer phone number: " + phonenumber);
                writer.WriteLine("Employee Name: " + employeename);
                writer.WriteLine("*************************************");
            }

        }
        // creating a method for display roomallocation 
        static void DisplayRoomAllocations()

        {
            // display the text saved in lhms_Roomallocate.txt
            string allfileText = File.ReadAllText(myDocuments + "\\HotelManagement\\lhms_Roomallocate.txt");
            Console.WriteLine(allfileText);
            Console.ReadLine();

        }
        static void SaveRoomAllocationsToFile()
        {
            try
            {
                // 
                string source1 = File.ReadAllText(myDocuments + "\\HotelManagement\\lhms_Roomadded.txt");// add rooms
                string source2 = File.ReadAllText(myDocuments + "\\HotelManagement\\lhms_Roomallocate.txt");//allocate room
                string doctempory = myDocuments + "\\HotelManagement\\" + backup; // is used to save the backup temporely
                using (StreamWriter newfile = new StreamWriter(doctempory))
                {
                    newfile.WriteLine("information from Room Added");
                    newfile.WriteLine(source1);
                    newfile.WriteLine("information from Allocate and De Allocate Room");
                    newfile.WriteLine(source2);

                }
                // creating a fullbackup text file in backup_fullbackup.txt
                string fullBack = myDocuments + "\\HotelManagement\\" + backup + "_fullbackup.txt";

                File.Copy(doctempory, fullBack);
                using (FileStream fs = new FileStream(doctempory, FileMode.Open))
                {
                    fs.SetLength(0); // it is used to cleanup the text in tempory file 

                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Unauthorized access. The file has only read permission.");
            }
            Console.WriteLine("backup created");
          
        }
        // creating a method to shaw all the saved text in fullbackup text
        static void ShowRoomAllocationsFromFile()
        {
            try
            {
                // 
                string allfileText = File.ReadAllText(myDocuments + "\\HotelManagement\\backup.txt_fullbackup.txt");
                Console.WriteLine(allfileText);
                Console.ReadLine();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The specified file was not found.");
            }
        }
        // creating method to readonly file for adminacess
        static void adminaccess()
        {

            try
            {
            string backup1 = "backup1.txt";
            string source1 = File.ReadAllText(myDocuments + "\\HotelManagement\\lhms_Roomadded.txt");// add rooms
            string source2 = File.ReadAllText(myDocuments + "\\HotelManagement\\lhms_Roomallocate.txt");//allocate room
            string doctempory1 = myDocuments + "\\HotelManagement\\" + backup1; 
            using (StreamWriter newfile = new StreamWriter(doctempory1))
            {
                newfile.WriteLine("information from Room Added");
                newfile.WriteLine(source1);
                newfile.WriteLine("information from Allocate and De Allocate Room");
                newfile.WriteLine(source2);

            }
                 // creating readonlyfile text
                string readOnlyFilePath = Path.Combine(myDocuments, "HotelManagement", "readOnlyFile.txt");

                // Ensure the file exists and set it to read-only
                if (!File.Exists(readOnlyFilePath))
                {
                    File.WriteAllText(readOnlyFilePath, "This is a read-only file.");
                    File.SetAttributes(readOnlyFilePath, FileAttributes.ReadOnly);
                }

                // Attempt to write to the read-only file
                File.WriteAllText(readOnlyFilePath, "Attempting to write to a read-only file.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Unauthorized access. The file has only read permission.");
            } 
}

    }
    
    }

    
        
    
    

