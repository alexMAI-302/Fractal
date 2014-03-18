using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class BinaryTree
    {
        public string section;    //элемент в узле дерева
        public BinaryTree Right;  //правый потомок
        public BinaryTree Left;   //левый потомок

        public void AdditionR()             //запись в правую ветвь
        {
            this.Right = new BinaryTree();
        }
        public void AdditionL()             //запись в левую ветвь
        {
            this.Left = new BinaryTree();
        }
    }
}
