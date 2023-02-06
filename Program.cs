//Name:         Lauren Griswold
//Course:       .Net
//Due Date:     02/06/23 @ 11:59pm
//Assignment:   A1 Ticketing System


/*
    1. Read data from file.
        -The file example below (tickets.csv) is an example of what this file should look like prior to reading it
        -Be sure to not display the header when displaying the contents to the screen
    2.Create file from data.
        The file example below (tickets.csv) is an example of what this file should look like when written after collecting user input
        ---note the header must be in the file and remain after writing
        -Add the header to the file when writing out the final file
        -Be sure to ask the user for the "Watching" names in a loop.  Do not, for example, just ask for an already pipe delimited text string to be entered.

    The following is an example of your final file

    Note the first line is the headers and should be included in the file
*/

using Microsoft.VisualBasic;

namespace Griswold_A1_Ticketing_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.txt";
            string choice;
            string fileHeader = "TicketID, Summary, Status, Priority, Submitter, Assigned, Watching";
            
            do
            {
                Console.WriteLine("1. Read data from file.");
                Console.WriteLine("2. Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        
                        // read file data
                        StreamReader sr = new StreamReader(file);

                        sr.ReadLine();

                        // read file data
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            string[] arr = line.Split(',');

                            Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", 
                                arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }

                        sr.Close(); // always close!
                    }
                    else //file doesn't exist option
                    {
                        Console.WriteLine("No file exists. Please create a file with option 2.");
                    }
                }
                else if (choice == "2")
                {
                    //create file
                    StreamWriter sw = new StreamWriter(file, true);

                    sw.WriteLine(fileHeader);

                    //create ticket y-continue n-end
                    Console.WriteLine("Create a ticket (Y/N)?");
                    string resp = Console.ReadLine().ToUpper();
                    if (resp != "Y") { break; }

                    //input - ticket id
                    Console.WriteLine("Enter a TicketID.");
                    string ticketID = Console.ReadLine();

                    //input - ticket summary
                    Console.WriteLine("What is the issue?");
                    string summary = Console.ReadLine().ToUpper();
                    
                    //input - ticket ststus
                    Console.WriteLine("Is the ticket open or closed?");
                    string status = Console.ReadLine().ToUpper();
                    
                    //input - ticket priority
                    Console.WriteLine("What is the ticket priority?");
                    string priority = Console.ReadLine().ToUpper();
                    
                    //input - ticket submitter
                    Console.WriteLine("Who submitted the ticket?");
                    string submitter = Console.ReadLine().ToUpper();
                    
                    //input - ticket assigned to
                    Console.WriteLine("Who is assigned to the ticket?");
                    string assigned = Console.ReadLine().ToUpper();
                    
                    //input - ticket watcher
                    Console.WriteLine("Who is watching this ticket?");

                    //watchers list
                    List<string> myWatchers = new List<string>();
                    myWatchers.Add("Drew Kjell");
                    myWatchers.Add("John Smith");
                    myWatchers.Add("Bill Jones");

                    foreach (string i in myWatchers)
                    {
                        Console.WriteLine(i);
                    }
                    string watching = Console.ReadLine().ToUpper();

                    //output
                    sw.WriteLine($"{ticketID}, {summary}, {status}, {priority}, {submitter}, {assigned}, {watching}");

                    sw.Close(); // always close!
                }
            } while (choice == "1" || choice == "2");
        }
    }
}