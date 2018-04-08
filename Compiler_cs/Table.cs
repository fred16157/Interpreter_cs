using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_cs
{
    static public class Table
    {
        static public Dictionary<string, FuncStruct> FuncTable;
        static public Dictionary<string, string> VarTable;
        static public Dictionary<string, string> LVarTable;
        static public Stack<TaskStruct> TaskStk; 
        static Table()
        {
            VarTable = new Dictionary<string, string>();
            LVarTable = new Dictionary<string, string>();
            TaskStk = new Stack<TaskStruct>();
            FuncTable = new Dictionary<string, FuncStruct>();
        }
        

        public struct TaskStruct
        {
            public string Type;
            public int LineNo;
            public TaskStruct(string Type, int LineNo)
            {
                this.Type = Type;
                this.LineNo = LineNo;
            }
        };

        public struct FuncStruct
        {
            public int StartLn;
            public int Argc;
            public List<string> Params;

        }

    }
}
