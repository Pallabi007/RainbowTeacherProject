using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TeacherDataStore
{
    class TeacherDataFile
    {
        static bool IsFileEmpty()
        {
            string Filepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\TeacherData.txt";

            if (File.ReadAllText(Filepath) == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void ViewAllRecords()
        {
            string Filepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\TeacherData.txt";
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (!IsFileEmpty())
            {
                List<TeacherDetails> Teachers = new List<TeacherDetails>();
                List<string> Lines = File.ReadAllLines(Filepath).ToList();

                foreach (var line in Lines)
                {
                    string[] entries = line.Split(',');

                    TeacherDetails TeachersDets = new TeacherDetails();
                    TeachersDets.ID = Convert.ToInt32(entries[0]);
                    TeachersDets.Name = entries[1];
                    TeachersDets.Class = entries[2];
                    TeachersDets.Section = entries[3];

                    Teachers.Add(TeachersDets);
                }

                Console.WriteLine("\n___All Records from the Teacher's Register___\n ");
                foreach (var Teacher in Teachers)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID = {Teacher.ID} \nName =  {Teacher.Name} \nClass = {Teacher.Class} \nSection {Teacher.Section}\n");

                }
            }
            else
            {
                Console.WriteLine("\n___No Records available in the Teacher's Register___\n ");
            }
        }
        static void EnterDetails()
        {
            int IDfromUser;
            string NamefromUser;
            string ClassfromUser;
            string SectionfromUser;

            List<string> NewRecord = new List<string>();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPlease Enter Teacher's Badge Id : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            IDfromUser = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Please Enter Teacher's Name : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            NamefromUser = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Please Enter Teacher's Class : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            ClassfromUser = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Please Enter Teacher's section : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            SectionfromUser = Console.ReadLine();
            Console.WriteLine("\n___Please verify the below details :");
            Console.WriteLine("Teacher's Id - " + IDfromUser);
            Console.WriteLine("Teacher's Name - " + NamefromUser);
            Console.WriteLine("Teacher's Class - " + ClassfromUser);
            Console.WriteLine("Teacher's section - " + SectionfromUser.ToUpper());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n___Do you want to save the details in the register (y/n) : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;

            if (response1.ToLower() == "y")
            {
                List<TeacherDetails> TeachersList = new List<TeacherDetails>();
                string Filepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\TeacherData.txt";

                if (!IsFileEmpty())
                {
                     List<string> Lines = File.ReadAllLines(Filepath).ToList();

                    foreach (var line in Lines)
                    {
                        string[] entries = line.Split(',');

                        TeacherDetails TeachersDets = new TeacherDetails();
                        TeachersDets.ID = Convert.ToInt32(entries[0]);
                        TeachersDets.Name = entries[1];
                        TeachersDets.Class = entries[2];
                        TeachersDets.Section = entries[3];

                        TeachersList.Add(TeachersDets);
                    }
                }
                TeachersList.Add(new TeacherDetails { ID = IDfromUser, Name = NamefromUser, Class = ClassfromUser, Section = SectionfromUser });
                foreach (var Teacher in TeachersList)
                {
                    NewRecord.Add($"{Teacher.ID},{Teacher.Name},{Teacher.Class},{Teacher.Section}");
                }
                File.WriteAllLines(Filepath, NewRecord);
            }
            else
            {
                Console.WriteLine("___Enter correct details again___");
                EnterDetails();
            }
            
        }
        static void RetriveRecords()
        {
            string Filepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\TeacherData.txt";
            Console.Write("\nPlease Enter Teacher's Badge Id to Search Record: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            int IDToSearch = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            List<TeacherDetails> TeachersList2 = new List<TeacherDetails>();
            List<string> Lines2 = File.ReadAllLines(Filepath).ToList();

            foreach (var line in Lines2)
            {
                string[] entries = line.Split(',');
                TeacherDetails TeachersDets = new TeacherDetails();
                TeachersDets.ID = Convert.ToInt32(entries[0]);
                TeachersDets.Name = entries[1];
                TeachersDets.Class = entries[2];
                TeachersDets.Section = entries[3];
                TeachersList2.Add(TeachersDets);
            }

            TeachersList2 = TeachersList2.Where(x => x.ID == IDToSearch).ToList();
            if (TeachersList2.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n___No Records Found from the Teacher's Register___");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n___Found Records from the Teacher's Register___\n ");
                foreach (var Teacher in TeachersList2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID = {Teacher.ID} \nName =  {Teacher.Name} \nClass = {Teacher.Class} \nSection {Teacher.Section}\n");
                }
            }

            
        }
        static void UpdateRecords()
        {
            int IDToUpdate;
            string NamefromUser;
            string ClassfromUser;
            string SectionfromUser;
            string Filepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\TeacherData.txt";
            List<string> UpdatedRecord = new List<string>();

            Console.Write("\nPlease Enter Teacher's Badge Id to Update Record: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            IDToUpdate = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;

            List<TeacherDetails> TeachersList3 = new List<TeacherDetails>();
            List<string> Lines3 = File.ReadAllLines(Filepath).ToList();

            foreach (var line in Lines3)
            {
                string[] entries = line.Split(',');
                TeacherDetails TeachersDets = new TeacherDetails();
                TeachersDets.ID = Convert.ToInt32(entries[0]);
                TeachersDets.Name = entries[1];
                TeachersDets.Class = entries[2];
                TeachersDets.Section = entries[3];
                TeachersList3.Add(TeachersDets);
            }

            if (TeachersList3.Any(x => x.ID == IDToUpdate))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n___Found Records from the Teacher's Register___\n ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please Enter Teacher's Name : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                NamefromUser = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please Enter Teacher's Class : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                ClassfromUser = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please Enter Teacher's section : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                SectionfromUser = Console.ReadLine();
                Console.WriteLine("\n___Please verify the below details :");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Teacher's Id - " + IDToUpdate);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Teacher's Name - " + NamefromUser);
                Console.WriteLine("Teacher's Class - " + ClassfromUser);
                Console.WriteLine("Teacher's section - " + SectionfromUser.ToUpper());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n___Do you want to save the details in the register (y/n) : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string response = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                int i = TeachersList3.FindIndex(r => r.ID == IDToUpdate);
                TeachersList3[i].Name = NamefromUser;
                TeachersList3[i].Class = ClassfromUser;
                TeachersList3[i].Section = SectionfromUser.ToUpper();
                foreach (var Teacher in TeachersList3)
                {
                    UpdatedRecord.Add($"{Teacher.ID},{Teacher.Name},{Teacher.Class},{Teacher.Section}");
                }
                File.WriteAllLines(Filepath, UpdatedRecord);
                Console.WriteLine("\n___Updated Record in the Teacher's Register___\n ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n___No Records Found from the Teacher's Register___");
            }
        }
        static void Main(string[] args)
        {       
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("***Welcome to ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("a");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("i");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("b");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("o");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("w");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" School Teacher's database***\n\n");
            string UserSelection = string.Empty;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n___Select any option___");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Choose 1  -> Store Teacher's Details\nChoose 2  -> Display Teacher's Register \nChoose 3  -> Search Teacher's Record \nChoose 4  -> Update Teacher's Record\nChoose 5  -> Exit\n");
                Console.Write("\nInput your choice : ");
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            EnterDetails();                            
                            break;
                        case 2:
                            ViewAllRecords();
                            break;
                        case 3:
                            RetriveRecords();                            
                            break;
                        case 4:
                            UpdateRecords();
                            break;
                        case 5:                            
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\n___Thanks! Please visit us again___");
                            Console.ForegroundColor = ConsoleColor.White;
                            UserSelection = "N";
                            break;

                        default:
                            Console.Write("___Incorrect Input option.. Try again \n");
                            break;
                    }                    
                }

                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n*** Exception occured while entering details :: {0} *** \n", ex.Message);                   
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n *** Exception occured :: {0} *** \n", ex.Message);                   
                }  
                do
                {
                    if (UserSelection != "N")
                    {
                        Console.Write("\n___Do you want to go back to Main Menu (y/n)___ : ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        UserSelection = Console.ReadLine().ToUpper();
                        if (UserSelection != "Y" && UserSelection != "N")
                        {
                            Console.Write("\n___Invalid Input___");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                while (UserSelection != "Y" && UserSelection != "N");
            }
            while (UserSelection != "N");
        }
    }
}
