using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication7
{

    class Program
    {
        public static int BrunchNumber = 0;  //количество ветвлений 
        
        public static void create_point(BinaryTree xy, double x, double y, int i, double step)
        {
            //рекурсивная функция для вычисления координат точек фрактала

            xy.section = x.ToString() + " ; " + y.ToString();  //конкатенация строк, содержащих координаты

            bool Flag = (i % 2 != 0);
            if (i != (BrunchNumber - 1))
                {
                    create_point(xy.Right = new BinaryTree(), x + ((Flag) ? step : 0), y + ((i % 2 != 0) ? 0 : step), i + 1, step / 2);
                    create_point(xy.Left = new BinaryTree(), x + ((Flag) ? -step : 0), y + ((i % 2 != 0) ? 0 : -step), i + 1, step / 2);  
                }
         }

        

        public static void PrintPoints(BinaryTree xy, StreamWriter SW)
        {
            //рекурсивная функция для вывода координат точек
            
                SW.WriteLine(xy.section);                    //вывод в файл
                System.Console.WriteLine(xy.section);        //вывод на консоль

                if (xy.Left != null)
                {
                    PrintPoints(xy.Left, SW);
                }

                if (xy.Right != null)
                {
                    PrintPoints(xy.Right, SW);
                }
        }

            static void Main(string[] args)
        {
            StreamWriter SW = new StreamWriter(new FileStream("FileName.txt", FileMode.Create, FileAccess.Write));
            System.Console.WriteLine("Программа   для  генерации   точек  фрактала,");
            System.Console.WriteLine("координаты точек  хранятся  в бинарном дереве");
            System.Console.WriteLine("---------------------------------------------");
            System.Console.WriteLine("Длина  родительского   отрезка  и  количество");
            System.Console.WriteLine("ветвлений задается пользователем с клавиатуры");
            System.Console.WriteLine("---------------------------------------------");
            System.Console.WriteLine("Введите длину начального отрезка фрактала:");

            /*var FileName = DateTime.UtcNow.ToString("dd-MM-yy HH-mm").ToString();
            System.Text.StringBuilder FileNameStructure = new System.Text.StringBuilder();
            FileNameStructure.AppendLine("Leaves" + FileName.ToString() + ".txt");
            System.Console.WriteLine(FileNameStructure);
            string name = FileNameStructure.ToString();*/

            /*
             *  Хотел сделать, что бы запись шла в файл с таким именем, но выдавалась ошибка о недопустимом пути
             *  Если сможете сказать в чем ошибка, буду очень признателен
             */

            try
            {
                float Len = float.Parse(System.Console.ReadLine());
                System.Console.WriteLine("Длина родительского звена = " + Len);

                System.Console.WriteLine();
                System.Console.WriteLine("Введите количество ветвлений фрактала:");
                BrunchNumber = int.Parse(System.Console.ReadLine());

                System.Console.WriteLine();
                System.Console.WriteLine("Количество ветвлений = " + BrunchNumber);

                BinaryTree BT = new BinaryTree();

                create_point(BT , 0, Len, 1, Len / 2);

                PrintPoints(BT, SW);

                SW.Close();  // в конце вывода данных закрываем поток
            }

            //адекватная реакция на ошибки

            catch (FormatException e1)
            {
                System.Console.WriteLine("Введены недопустимые символы"); //исключение неверного формата
            }

            catch (OverflowException e2)
            {
                System.Console.WriteLine("Введена слишком большая последовательность символов"); //исключение слишком большого числа
            }

            finally
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Данные были записаны в файл: 'FileName.txt'");
                System.Console.WriteLine();
                System.Console.WriteLine("По нажатию любой клавиши работа завершится автоматически");
                System.Console.ReadKey();
            }
        }
    }
}
