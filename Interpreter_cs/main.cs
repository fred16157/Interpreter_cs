using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_cs
{
    class main
    {
        static void Main(string[] args)
        {
            string[] Code;
            if (args.Length == 0)
            {
                return;
            }

            Code = Iosys.ReadFile(args[0]);
            Code code;

            code = new Code(Code);
        }
    }
}
