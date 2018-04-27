using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_cs
{
    static public class Table
    {

        static public List<string> CodeList;    //코드가 담길 문자열형 리스트
        static public Dictionary<string, FuncStruct> FuncTable;     //문자열을 키값으로 받고, 아래에 선언된 함수 스트럭트형을 가져다 값으로 씀
        static public Dictionary<string, string> VarTable;
        static public Dictionary<string, LVarStruct> LVarTable;

        static public Stack<TaskStruct> TaskStk; 
        static Table()
        {
            CodeList = new List<string>();
            VarTable = new Dictionary<string, string>();
            LVarTable = new Dictionary<string, LVarStruct>();
            TaskStk = new Stack<TaskStruct>();
            FuncTable = new Dictionary<string, FuncStruct>();
        }
        
       

        public struct TaskStruct
        {
            public string Type;
            public int LineNo;
            public int ReturnNo;
            public TaskStruct(string Type, int LineNo,int ReturnNo)
            {
                this.Type = Type;
                this.LineNo = LineNo;
                this.ReturnNo = ReturnNo;
            }
        };

        public struct LVarStruct
        {
            public string Val;
            public string FuncName;
            public LVarStruct(string val,string Funcname)
            {
                Val = val;
                FuncName = Funcname;
            }
        };

        public struct FuncStruct
        {
            public int StartLn;
            public int Argc;
            public List<string> Params;
            
        };

    }
}
