using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compiler_cs
{
    class Iosys
    {
       static public string[] ReadFile(string Path)
        {
            string[] Code = File.ReadAllLines(Path);
            //Console.WriteLine(Code[0]);
            return Code;
        } 
    }
}
