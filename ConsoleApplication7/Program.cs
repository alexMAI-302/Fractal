﻿using System;
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
        public static string[] point;        //вспомогательный массив
        public static int k = 0;             //вспомогательная переменная

        public static int create_point(BinaryTree xy, double x, double y, int i, double step)
        {
            //рекурсивная функция для вычисления координат точек фрактала

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(x.ToString() + " ; " + y.ToString());              //конкатенация строк, содержащих координаты
            xy.section = sb.ToString();                                      //запись в "лист" дерева

            if (i == (BrunchNumber - 1))
                {
                    return 0;
                }

                else
                {
                    

                   if (i % 2 != 0)
                    {
                        xy.Right = new BinaryTree();
                        create_point(xy.Right , x + step, y, i + 1, step / 2);
                        xy.Left = new BinaryTree();
                        create_point(xy.Left ,  x - step, y, i + 1, step / 2);
                    }

                    else
                    {
                        xy.Right = new BinaryTree();
                        create_point(xy.Right ,x, y + step, i + 1, step / 2);
                        xy.Left = new BinaryTree();
                        create_point(xy.Left , x, y - step, i + 1, step / 2);
                    }
                }
            
                return 0;
        }

        public static void PrintPoints(BinaryTree xy)
        {
            //рекурсивная функция для вывода координат точек

                System.Console.WriteLine(xy.section);        //вывод на консоль

                point[k] = xy.section.ToString();            //заполнение вспомогательного массива
                k = k + 1;

                if (xy.Left != null)
                {
                    PrintPoints(xy.Left);
                }

                if (xy.Right != null)
                {
                    PrintPoints(xy.Right);
                }
        }


        static void Main(string[] args)
        {
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

                point = new string[(int)Math.Pow(2, BrunchNumber)];  //инициализация вспомогательного массива point
     
                create_point(BT , 0, Len, 1, Len / 2);

                PrintPoints(BT);

                

                //вывод в текстовый файл из вспомогательного массива:
                StreamWriter SW = new StreamWriter(new FileStream("FileName.txt", FileMode.Create, FileAccess.Write)); // !!! здесь вместо "FileName.txt" было name
                for (int j = 0; j < Math.Pow(2, BrunchNumber); j++)
                {
                    SW.WriteLine(point[j]); 
                }
                    
                SW.Close();
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
