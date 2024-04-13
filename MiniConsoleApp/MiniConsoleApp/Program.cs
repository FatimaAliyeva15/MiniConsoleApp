using Core;

namespace MiniConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool check = true;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Menu");
                Console.WriteLine("1. Classroom yarat");
                Console.WriteLine("0. Proqramı bitir");
                Console.WriteLine("");
                string choiceStr;
                byte choice;

                do
                {
                    Console.WriteLine("");
                    Console.Write("Sechim edin: ");
                    choiceStr = Console.ReadLine();
                } while (!byte.TryParse(choiceStr, out choice));

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("");
                        Console.WriteLine("Classroom yarat");
                        

                        string strClassname = "";
                        bool checkClassname = false;
                        while (!checkClassname)
                        {
                            Console.WriteLine("");
                            Console.Write("Classroom: ");
                            strClassname = Console.ReadLine();
                            checkClassname = strClassname.CheckClassname();
                            if (!checkClassname)
                            {
                                Console.WriteLine("Yeniden daxil edin");
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine("1. BackEnd");
                        Console.WriteLine("2. FrontEnd");
                        string choiceTypeStr = "";
                        int choiceType;

                        do
                        {
                            Console.WriteLine("");
                            Console.Write("Choice Type: ");
                            choiceTypeStr = Console.ReadLine();
                        } while (!int.TryParse(choiceTypeStr, out choiceType));

                        Console.WriteLine("");
                        Console.WriteLine($"Classroom: {strClassname}, Type: {(Core.ClassType)choiceType}");

                        Classroom classroom = new Classroom(strClassname, (Core.ClassType)choiceType);

                        bool checkmenu2 = true;

                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Menu");
                            Console.WriteLine("1. Student yarat");
                            Console.WriteLine("2. Butun Telebeleri ekrana cixart");
                            Console.WriteLine("3. Secilmis sinifdeki telebeleri ekrana cixart");
                            Console.WriteLine("4. Telebe sil");
                            Console.WriteLine("0. Quit");
                            Console.WriteLine("");
                            string choiceStr2;
                            byte choice2;

                            do
                            {
                                Console.WriteLine("");
                                Console.Write("Sechim edin: ");
                                choiceStr2 = Console.ReadLine();
                            } while (!byte.TryParse(choiceStr2, out choice2));

                            switch(choice2)
                            {
                                case 1:

                                    if((classroom.Type == Core.ClassType.BackEnd && classroom.Length < 20) || (classroom.Type == Core.ClassType.FrontEnd && classroom.Length < 15))
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Student yarat");
                                        Console.WriteLine("");

                                        string strName = "";
                                        bool checkName = false;
                                        while (!checkName)
                                        {

                                            Console.Write("Name: ");
                                            strName = Console.ReadLine();
                                            checkName = strName.CheckName();
                                            if (!checkName)
                                            {
                                                Console.WriteLine("Yeniden daxil edin");
                                                Console.WriteLine("");
                                            }
                                        }

                                        string strSurname = "";
                                        bool checkSurname = false;
                                        while (!checkSurname)
                                        {
                                            Console.Write("Surname: ");
                                            strSurname = Console.ReadLine();
                                            checkSurname = strSurname.CheckSurname();
                                            if (!checkSurname)
                                            {
                                                Console.WriteLine("Yeniden daxil edin");
                                            }
                                        }

                                        Student student = new Student(strName, strSurname);

                                        classroom.StudentAdd(student);
                                    }
                                    else
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Daha telebe daxil etmek olmaz");
                                    }
                                   
                                    break;

                                case 2:

                                    Console.WriteLine("");
                                    Console.WriteLine("Butun Telebeleri ekrana cixart");
                                    Console.WriteLine("");

                                    for (int i = 0; i < classroom.GetAllStudents().Length; i++)
                                    {
                                        Console.WriteLine(classroom.GetAllStudents()[i]);
                                    }

                                    break;

                                case 3:

                                    Console.WriteLine("");
                                    Console.WriteLine("Secilmis sinifdeki telebeleri ekrana cixart");
                                    Console.WriteLine("");

                                    string idStr = "";
                                    int id;

                                    do
                                    {
                                        Console.Write("Id daxil et: ");
                                        idStr = Console.ReadLine();
                                    } while (!int.TryParse(idStr, out id));

                                    bool searchId = false;

                                    for (int i = 0; i < classroom.GetAllStudents().Length; i++)
                                    {
                                        Student studentId = classroom.GetAllStudents()[i];

                                        if (id == studentId.Id)
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine(studentId);
                                            searchId = true;
                                        }
                                    }
                                    if (!searchId)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Bele bir student yoxdur");
                                    }

                                    break;

                                case 4:

                                    try
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Telebe sil");
                                        Console.WriteLine("");

                                        string deleteIdStr = "";
                                        int deleteId;

                                        do
                                        {
                                            
                                            Console.Write("Id daxil et: ");
                                            deleteIdStr = Console.ReadLine();
                                        } while (!int.TryParse(deleteIdStr, out deleteId));

                                        classroom.Delete(deleteId);
                                        Console.WriteLine("");
                                        Console.WriteLine($"Id {deleteId} olan telebe silindi");


                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine(ex.Message);
                                    }

                                    break;

                                case 0:

                                    checkmenu2 = false;
                                    Console.WriteLine("");
                                    Console.WriteLine("Quit");
                                    break;

                                default:

                                    Console.WriteLine("");
                                    Console.WriteLine("Duzgun sechim et");
                                    break;

                            }
                        } while (checkmenu2);


                        break;
   
                    case 0:
                        check = false;
                        Console.WriteLine("");
                        Console.WriteLine("Proqram bitdi");
                        break;

                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Duzgun sechim et");
                        break;
                }

            } while (check);     


        }
    }
}
