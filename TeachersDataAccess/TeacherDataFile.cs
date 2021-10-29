using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TeacherDataStore
{
    class TeacherDataFile
    {
        static void Main(string[] args)
        {
            int IDfromUser;
            string NamefromUser;
            int ClassfromUser;
            string SectionfromUser;
            
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

            // Create Teacher Register File 
            //FileStream fileStreamCreate = new FileStream("C:\\Dell\\Data\\TeachersNew.txt", FileMode.Create);
            //Console.WriteLine("*** Teachers Register created succesfully ***");
            //byte[] bdata = Encoding.Default.GetBytes("*** Welcome to Rainbow School Teacher's database ***");
            //fileStreamCreate.Write(bdata, 0, bdata.Length);
            //Console.WriteLine("Content written to the file.");
            //fileStreamCreate.Close();

            string Filepath = @"C:\Dell\Data\Teacher Project\TeacherData.txt";
            List<string> NewRecord = new List<string>();
            List<string> UpdatedRecord = new List<string>();
            int IDToSearch, IDToUpdate;
            string response2;

        SwitchMenu: Console.ForegroundColor = ConsoleColor.Green;
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
                    EnterDetails: Console.ForegroundColor = ConsoleColor.Yellow;
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
                        ClassfromUser = Convert.ToInt32(Console.ReadLine());
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
                            List<string> Lines1 = File.ReadAllLines(Filepath).ToList();

                            foreach (var line in Lines1)
                            {
                                string[] entries = line.Split(',');

                                TeacherDetails TeachersDets = new TeacherDetails();
                                TeachersDets.ID = Convert.ToInt32(entries[0]);
                                TeachersDets.Name = entries[1];
                                TeachersDets.Class = Convert.ToInt32(entries[2]);
                                TeachersDets.Section = entries[3];

                                TeachersList.Add(TeachersDets);
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
                            goto EnterDetails;
                        }
                        Console.Write("\n___Do you want to enter Another Teacher's details (y/n) : ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        response2 = Console.ReadLine();
                        if (response2.ToLower() == "y")
                        {
                            goto EnterDetails;

                        }
                        else
                        {
                            goto SwitchMenu;
                        }

                    case 2:
                        //----- View All Records ---;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        List<TeacherDetails> Teachers = new List<TeacherDetails>();
                        List<string> Lines = File.ReadAllLines(Filepath).ToList();

                        foreach (var line in Lines)
                        {
                            string[] entries = line.Split(',');

                            TeacherDetails TeachersDets = new TeacherDetails();
                            TeachersDets.ID = Convert.ToInt32(entries[0]);
                            TeachersDets.Name = entries[1];
                            TeachersDets.Class = Convert.ToInt32(entries[2]);
                            TeachersDets.Section = entries[3];

                            Teachers.Add(TeachersDets);
                        }

                        Console.WriteLine("\n___All Records from the Teacher's Register___\n ");
                        foreach (var Teacher in Teachers)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"ID = {Teacher.ID} \nName =  {Teacher.Name} \nClass = {Teacher.Class} \nSection {Teacher.Section}\n");

                        }
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\n___Do you want to Return To Main Menu (y/n) : ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        response1 = Console.ReadLine();
                        if (response1.ToLower() == "y")
                        {
                            goto SwitchMenu;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("\n___Thanks! Please visit us again___");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 3:
                    //----- Retrive Records based on Id -----//

                    SearchID: Console.Write("\nPlease Enter Teacher's Badge Id to Search Record: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        IDToSearch = Convert.ToInt32(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        List<TeacherDetails> TeachersList2 = new List<TeacherDetails>();
                        List<string> Lines2 = File.ReadAllLines(Filepath).ToList();

                        foreach (var line in Lines2)
                        {
                            string[] entries = line.Split(',');
                            TeacherDetails TeachersDets = new TeacherDetails();
                            TeachersDets.ID = Convert.ToInt32(entries[0]);
                            TeachersDets.Name = entries[1];
                            TeachersDets.Class = Convert.ToInt32(entries[2]);
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

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\n___Do you want to retrive another Teacher's Details (y/n) : ");
                        response2 = Console.ReadLine();
                        if (response2.ToLower() == "y")
                        {
                            goto SearchID;
                        }
                        if (response2.ToLower() == "n")
                        {
                            goto SwitchMenu;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\n___Thanks! Please visit us again___");
                            Console.ForegroundColor = ConsoleColor.White;
                            break; 
                        }


                    case 4:
                    //----- Update Records based on Id -----//

                    UpdateID: Console.Write("\nPlease Enter Teacher's Badge Id to Update Record: ");
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
                            TeachersDets.Class = Convert.ToInt32(entries[2]);
                            TeachersDets.Section = entries[3];
                            TeachersList3.Add(TeachersDets);
                        }
                       
                        if (TeachersList3.Any(x => x.ID == IDToUpdate))
                        {
                            //#
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n___Found Records from the Teacher's Register___\n ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Please Enter Teacher's Name : ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            NamefromUser = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Please Enter Teacher's Class : ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            ClassfromUser = Convert.ToInt32(Console.ReadLine());
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
                            response1 = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            //#

                           
                            int i = TeachersList3.FindIndex(r => r.ID == IDToUpdate);
                            TeachersList3[i].Name = NamefromUser;
                            TeachersList3[i].Class = ClassfromUser;
                            TeachersList3[i].Section = SectionfromUser.ToUpper();
                            Console.WriteLine("\n___Updating Records from the Teacher's Register___\n ");
                           
                            foreach (var Teacher in TeachersList3)
                            {
                                UpdatedRecord.Add($"{Teacher.ID},{Teacher.Name},{Teacher.Class},{Teacher.Section}");
                            }
                            File.WriteAllLines(Filepath, UpdatedRecord);                           
                            Console.WriteLine("\n___Updated Records from the Teacher's Register___\n ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n___No Records Found from the Teacher's Register___");
                        }

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\n___Do you want to Update another Teacher's Details (y/n) : ");
                        response2 = Console.ReadLine();
                        if (response2.ToLower() == "y")
                        {
                            goto UpdateID;
                        }
                        if (response2.ToLower() == "n")
                        {
                            goto SwitchMenu;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\n___Thanks! Please visit us again___");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("\n___Thanks! Please visit us again___");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    default:
                        Console.Write("___Incorrect Input option.. Try again \n");
                        goto SwitchMenu;

                }
            }

            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n*** Exception occured while entering details :: {0} *** \n", ex.Message);
                goto SwitchMenu;


            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n *** Exception occured :: {0} *** \n", ex.Message);
                goto SwitchMenu;
            }

            Console.ReadKey();
        }
    }
}
