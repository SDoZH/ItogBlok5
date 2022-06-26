using System;

namespace Final5._21
{
    namespace Final521
    {
        internal class Program
        {

          //вывод метода 
            static void Main(string[] args)
            {
                var Anketa = EnterUser();
                OutPrint(Anketa.Name, Anketa.Surname, Anketa.Age, Anketa.HasPets, Anketa.PetName, Anketa.favcolors);
            }


            //обявим метод
            static (string Name, string Surname, uint Age, bool HasPets, string[] PetName, string[] favcolors) EnterUser()
            {
                (string Name, string Surname, uint Age, bool HasPets, string[] PetName, string[] favcolors) Users;//кортеж

                
                Console.Write("Введите ваше Имя: ");
                Users.Name = Console.ReadLine();

                Console.Write("Введите вашу Фамилию: ");
                Users.Surname = Console.ReadLine();
                
                bool flag = true;

                do
                {
                    Console.Write("Укажите Ваш возраст: ");
                    string age = Console.ReadLine();
                    Users.Age = 0;
                    CheckNum(age, out Users.Age);
                    if (Users.Age == 0) //условие что возраст больше 0
                    {
                        continue;
                    }
                    flag = false;


                } while (flag);
               

                //про питомца 
                do
                {
                    Console.Write("Увас есть питомец Да либо Нет?: ");
                    Users.HasPets = false;
                    Users.PetName = null;
                    var Nik = Console.ReadLine();
                    if ( Nik == "Да" || Nik == "Нет") //Nik может быть только Да или (||)Нет
                    {
                        if (Nik == "Да")
                        {
                            Users.HasPets = true;
                            Console.Write("\nСколько у вас питомцев?: ");
                            uint countPets = 0;
                            string temp = Console.ReadLine();
                            CheckNum(temp, out countPets);
                            if (countPets > 0)
                            {
                                Users.PetName = new string[countPets];
                                for (int i = 0; i < Users.PetName.Length; i++)
                                {
                                    Console.Write("Как {0} - зовут: ", (i + 1));
                                    Users.PetName[i] = Console.ReadLine();
                                }
                                break;
                            }
                        }

                        if (Nik == "Нет")
                        {
                            Console.WriteLine();
                            Users.HasPets = false;
                            break;


                        }
                        Console.WriteLine();


                    }

                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nУкажите корректные данные Да либо Нет");
                        Console.ForegroundColor = ConsoleColor.White;
                        flag = true;

                    }

                } while (flag);
              

                

                do
                {

                    Console.Write("Сколько у Вас любимых цветов: ");
                    int countCollors = 0;
                    Users.favcolors = null;

                    string colors = (Console.ReadLine());
                    bool result = int.TryParse(colors, out countCollors);
                    if (result == true && countCollors != 0)  //ждем резултьат ввода: числоне не равное нулю
                    {
                        Users.favcolors = new string[countCollors];
                        for (int i = 0; i < Users.favcolors.Length; i++)
                        {
                            Console.Write("Введите {0} - цвет: ", (i + 1));
                            Users.favcolors[i] = Console.ReadLine();
                            flag = false;
                        }
                    }
                    if (result == false || countCollors == 0)  //если чсило не ведено либо равно 0 выводим ошибку
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите корректное значение ");
                        Console.ForegroundColor = ConsoleColor.White;
                        flag = true;
                    }

                } while (flag);

              



                return Users;


            }

            //метод проверки ввода возраста
            static uint CheckNum(string tempAge, out uint age)
            {
                if (uint.TryParse(tempAge, out age) == false || age == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы указали неверное значение,попробуйте еще раз");
                    Console.ForegroundColor = ConsoleColor.White;

                }

                return age;
            }
            //метод вывода на экран кортежа
            static void OutPrint(string Name, string Surname, uint Age, bool Pets, string[] Nickname, string[] favcolors)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine();
                Console.Write($"\tВас зовут {Name}\n");
                Console.Write($"\tВаша фамилия {Surname}\n");
                Console.Write($"\tВаш возраст {Age}\n");
                Console.Write($"\tНаличие животных {Pets}\n");
                if (Pets == true)
                {
                    for (int i = 0; i < Nickname.Length; i++)
                    {
                        Console.Write($"\t{i + 1}-го зовут {Nickname[i]}\n");

                    }
                }
                for (int i = 0; i < favcolors.Length; i++)
                {
                    Console.Write($"\t{i + 1} цвет {favcolors[i]}\n");

                }
                Console.ResetColor();
            }






        }
    }
}