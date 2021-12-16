using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iface
{
    public class Class1 : IClass1
    {
        int _value=-1;

        public int Value 
        { 
            get => _value; 
            set => _value = value; 
        }

        public void DoSomething()
        {
            Console.WriteLine("Did something.");
        }
    }
}
