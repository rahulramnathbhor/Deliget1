using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemos
{
    public delegate int MyDelegate(int n1, int n2);
    public class Calculator
    {
        public int Add(int a,int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            MyDelegate myDelegate=new MyDelegate(c.Multiply); // added method reference
            myDelegate+=new MyDelegate(c.Sub); // add in the invocation
            myDelegate+=new MyDelegate(c.Add);
            // internally system will generate Invocation List

            myDelegate -= new MyDelegate(c.Sub); // remove method from invocation list
           Delegate[] list= myDelegate.GetInvocationList();
            foreach (Delegate d in list)
            {
                Console.WriteLine(d.Method);
                Console.WriteLine(d.DynamicInvoke(78,45));
            }

        }

    }
}

