using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class BinaryTree
    {
        public string section; //элемент в узле дерева
         
        public BinaryTree Right;
        public BinaryTree Left;

        public void AdditionR()
        {
            this.Right = new BinaryTree();
          
                
        }
        public void AdditionL()
        {
            this.Left = new BinaryTree();
        
        }
        public void SetSection(string section)
        {
            this.section = section;
        }
    }
}
