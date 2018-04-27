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
            string[] Code = null;
            try
            {
                Code = File.ReadAllLines(Path);
            }
            catch (Exception e)
            {
                Console.WriteLine("파일 경로나 파일이 올바르지 않습니다");
                Console.WriteLine("사용법: Compiler_cs [파일 경로]");
                Environment.Exit(0);
            }
            //Console.WriteLine(Code[0]);
            return Code;
        } 
        
    }
}
