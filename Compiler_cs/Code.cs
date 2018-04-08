using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_cs
{
    //enum Token
    //{
    //      Print
    //};
    class Code
    {
        int Count = 0;
        public Code(string[] Code)
        {
            
            for(; Count < Code.Length; Count++)
            {
                Parse(Code[Count]);
            }
        }
        public void Parse(string CodeLine)
        { 
            string[] Words;
            string PrintText;
            string[] tmp;
            string Str;
            double TDbl = 0;
            bool IsRight = false;

            Table.FuncStruct TmpFncStruct = new Table.FuncStruct();

            Words = CodeLine.Split(' ');

            if(Table.TaskStk.Count > 0)
            {
                if(Table.TaskStk.Peek().Type.CompareTo("FalseIf")==0)
                {
                    if(Words[0].CompareTo("EndIf") == 0)
                    {
                        Table.TaskStk.Pop();
                    }
                    return;
                }
                if(Table.TaskStk.Peek().Type.CompareTo("TrueWhile") == 0)
                {
                    if(Words[0].CompareTo("EndWhile") == 0)
                    {
                        Count = Table.TaskStk.Pop().LineNo-1;
                    }
                    
                }
                else if(Table.TaskStk.Peek().Type.CompareTo("FalseWhile") == 0)
                {
                    if(Words[0].CompareTo("EndWhile")==0)
                    {
                        Table.TaskStk.Pop();
                    }
                    return;
                }
                if(Table.TaskStk.Peek().Type.CompareTo("EndFunc")==0)
                {
                    Table.TaskStk.Pop();
                    return;
                }
            }
            

            switch (Words[0])
            {
                case "Print":
                    PrintText = "";
                    if(Table.VarTable.ContainsKey(Words[1]))
                    {
                        Table.VarTable.TryGetValue(Words[1], out PrintText);
                        Console.Write(PrintText);
                        return;
                    }
                    for (int i = 1; i < Words.Length; i++)
                    {
                        
                        if (i != Words.Length - 1)
                        {
                            PrintText += (Words[i] + " ");
                        }
                        else
                            PrintText += (Words[i]);
                    }


                    Console.Write(PrintText);
                    return;
                case "Println":
                    PrintText = "";
                    if (Table.VarTable.ContainsKey(Words[1]))
                    {
                        Table.VarTable.TryGetValue(Words[1], out PrintText);
                        Console.WriteLine(PrintText);
                        return;
                    }
                    for (int i = 1; i < Words.Length; i++)
                    {
                        if (i != Words.Length - 1)
                        {
                            PrintText += (Words[i] + " ");
                        }
                        else
                            PrintText += (Words[i]);
                    }
                    Console.WriteLine(PrintText);
                    return;
                case "Calc":
                    PrintText = "";
                    
                    for (int i = 1; i < Words.Length; i++)
                    {
                        PrintText += (Words[i]);
                        PrintText += " ";
                    }
                    tmp = PrintText.Split(' ');
                    foreach(string str in PostFix(tmp))
                    {
                        Console.Write(str);
                    }
                    Console.WriteLine();
                    Console.WriteLine(Calc(PostFix(tmp)));

                    return;
                case "Var":
                    if(Words.Length>=3)
                    {
                        MakeVar(Words[1],Words[2]);
                    }
                    else
                    {
                        MakeVar(Words[1]);
                    }
                    
                    return;
                case "Input":
                    Table.VarTable[Words[1]] = Console.ReadLine();
                    
                    return;
                case "If":
                    
                    if(!Table.VarTable.ContainsKey(Words[1]))
                    {
                        Exit(1);
                    }
                    if (!Table.VarTable.TryGetValue(Words[3], out Str))
                    {
                        TDbl = Double.Parse(Words[3]);
                    }
                    else
                        TDbl = Double.Parse(Str);

                    

                    switch(Words[2])
                    {
                        case "==":
                            IsRight = Double.Parse(Table.VarTable[Words[1]]) == TDbl;
                            break;
                        case "<":
                            IsRight = Double.Parse(Table.VarTable[Words[1]]) < TDbl;
                            break;
                        case ">":
                            IsRight = Double.Parse(Table.VarTable[Words[1]]) > TDbl;
                            break;
                        case "<=":
                            IsRight = Double.Parse(Table.VarTable[Words[1]]) <= TDbl;
                            break;
                        case ">=":
                            IsRight = Double.Parse(Table.VarTable[Words[1]]) >= TDbl;
                            break;
                        case "!=":
                            IsRight = Double.Parse(Table.VarTable[Words[1]]) != TDbl;
                            break;
                    }
                    
                    
                    if(IsRight)
                    {
                        Table.TaskStk.Push(new Table.TaskStruct("TrueIf", Count));
                    }
                    else
                    {
                        Table.TaskStk.Push(new Table.TaskStruct("FalseIf", Count));
                    }


                    return;
                case "While":
                    if(Words[1] == null)
                    {
                        Table.TaskStk.Push(new Table.TaskStruct("TrueWhile", Count));
                    }
                    else
                    {
                        if (!Table.VarTable.ContainsKey(Words[1]))
                        {
                            Exit(1);
                        }
                        if (!Table.VarTable.TryGetValue(Words[3], out Str))
                        {
                            TDbl = Double.Parse(Words[3]);
                        }
                        else
                            TDbl = Double.Parse(Str);


                        switch (Words[2])
                        {
                            case "==":
                                IsRight = Double.Parse(Table.VarTable[Words[1]]) == TDbl;
                                break;
                            case "<":
                                IsRight = Double.Parse(Table.VarTable[Words[1]]) < TDbl;
                                break;
                            case ">":
                                IsRight = Double.Parse(Table.VarTable[Words[1]]) > TDbl;
                                break;
                            case "<=":
                                IsRight = Double.Parse(Table.VarTable[Words[1]]) <= TDbl;
                                break;
                            case ">=":
                                IsRight = Double.Parse(Table.VarTable[Words[1]]) >= TDbl;
                                break;
                            case "!=":
                                IsRight = Double.Parse(Table.VarTable[Words[1]]) != TDbl;
                                break;
                        }

                        if (IsRight)
                        {
                            Table.TaskStk.Push(new Table.TaskStruct("TrueWhile", Count));
                        }
                        else
                        {
                            Table.TaskStk.Push(new Table.TaskStruct("FalseWhile", Count));
                        }
                    }
                    return;
                case "Func":
                    int ArgCount = 0;
                    TmpFncStruct.StartLn = Count;
                    TmpFncStruct.Params = new List<string>();

                    for (int i = 2; Words[i] != null; i++)
                    {
                        TmpFncStruct.Params.Add(Words[1]);
                        ArgCount++;
                    }
                    TmpFncStruct.Argc = ArgCount;
                    Table.FuncTable.Add(Words[1], TmpFncStruct);
                    Table.TaskStk.Push(new Table.TaskStruct("Func", Count));
                    return;
                default:
                    if(!(Table.VarTable.ContainsKey(Words[0])))
                    {
                        break;
                    }
                    Table.VarTable[Words[0]] = Words[1];
                    break;
            }
        }

        void Exit(int Code)
        {
            switch(Code)
            {
                case 1:
                    Console.WriteLine("조건문 첫번째 인수에는 선언된 변수만 들어갈 수 있습니다");
                    break;
            }
            Environment.Exit(0);
        }

        void MakeVar(string name,double val)
        {
            if (!(Table.VarTable.Keys.Contains(name)))
            {
                Table.VarTable.Add(name, val.ToString());
            }
            else
            {

            }
        }
        void MakeVar(string name,string val)
        {
            if (!(Table.VarTable.Keys.Contains(name)))
            {
                Table.VarTable.Add(name, val);
            }
            else
            {

            }
        }
        void MakeVar(string name)
        {
            if (!(Table.VarTable.Keys.Contains(name)))
            {
                Table.VarTable.Add(name, "0");
            }
            else
            {

            }
        }

        double Calc(string[] arg)
        {
            //a 10 * 8 b * + c -
            Stack<string> TmpStk = new Stack<string>();
            double LDbl = 0;
            double RDbl = 0;
            double TDbl = 0;
            string TmpStr = "";

            foreach(string tmp in arg)
            {
                switch(tmp)
                {
                    case "+":
                        if (!Double.TryParse(TmpStk.Peek(), out RDbl))
                        {
                            Table.VarTable.TryGetValue(TmpStk.Pop(), out TmpStr);
                            RDbl = Double.Parse(TmpStr);
                            //변수 없을시 예외처리 해야함
                        }
                        else TmpStk.Pop();
                        if(!Double.TryParse(TmpStk.Peek(),out LDbl))
                        {
                            Table.VarTable.TryGetValue(TmpStk.Pop(), out TmpStr);
                            LDbl = Double.Parse(TmpStr);
                        }
                        else TmpStk.Pop();
                        TDbl = LDbl + RDbl;
                        TmpStk.Push(TDbl.ToString());
                        break;
                    case "-":
                        if (!Double.TryParse(TmpStk.Peek(), out RDbl))
                        {
                            Table.VarTable.TryGetValue(TmpStk.Pop(), out TmpStr);
                            RDbl = Double.Parse(TmpStr);
                            //변수 없을시 예외처리 해야함
                        }
                        else TmpStk.Pop();
                        if (!Double.TryParse(TmpStk.Peek(), out LDbl))
                        {
                            Table.VarTable.TryGetValue(TmpStk.Pop(), out TmpStr);
                            LDbl = Double.Parse(TmpStr);
                        }
                        else TmpStk.Pop();
                        TDbl = LDbl - RDbl;
                        TmpStk.Push(TDbl.ToString());
                        break;
                    case "*":
                        if (!Double.TryParse(TmpStk.Peek(), out RDbl))
                        {
                            Table.VarTable.TryGetValue(TmpStk.Pop(), out TmpStr);
                            RDbl = Double.Parse(TmpStr);
                            //변수 없을시 예외처리 해야함
                        }
                        else TmpStk.Pop();
                        if (!Double.TryParse(TmpStk.Peek(), out LDbl))
                        {
                            Table.VarTable.TryGetValue(TmpStk.Pop(), out TmpStr);
                            LDbl = Double.Parse(TmpStr);
                        }
                        else TmpStk.Pop();
                        TDbl = LDbl * RDbl;
                        TmpStk.Push(TDbl.ToString());
                        break;
                    case "/":
                        if (!Double.TryParse(TmpStk.Peek(), out RDbl))
                        {
                            Table.VarTable.TryGetValue(TmpStk.Pop(), out TmpStr);
                            RDbl = Double.Parse(TmpStr);
                            //변수 없을시 예외처리 해야함
                        }
                        else TmpStk.Pop();
                        if (!Double.TryParse(TmpStk.Peek(), out LDbl))
                        {
                            Table.VarTable.TryGetValue(TmpStk.Pop(), out TmpStr);
                            LDbl = Double.Parse(TmpStr);
                        }
                        else TmpStk.Pop();
                        TDbl = LDbl / RDbl;
                        TmpStk.Push(TDbl.ToString());
                        break;
                    default:
                        TmpStk.Push(tmp);
                        break;
                }
            }

            return TDbl;
        }

        string[] PostFix(string[] arg)
        {
            Stack<string> TmpStk = new Stack<string>();
            List<string> OpList = new List<string>();
            List<string> PostFixList = new List<string>();
            string tmp;
            foreach(string str in arg)
            {
                if (str.CompareTo("") == 0)
                    continue;
                if(str.CompareTo("+")==0 ||str.CompareTo("-") == 0) // 현재 연산자가 +, - 
                {
                    if(TmpStk.Count == 0) // 스택이 비었을 때
                    {
                        TmpStk.Push(str);
                    }
                    else 
                    {
                        for(; 0< TmpStk.Count;)
                        {
                            PostFixList.Add(TmpStk.Pop());
                        }
                        TmpStk.Push(str);
                    }
                }
                else if (str.CompareTo("*") == 0 || str.CompareTo("/") == 0) // 현재 연산자가 *, /
                {
                    if (TmpStk.Count == 0)
                    {
                        TmpStk.Push(str);
                    }
                    else
                    {
                        for (; 0 < TmpStk.Count; )
                        {
                            tmp = TmpStk.Pop();
                            if (tmp.CompareTo("+") == 0 || tmp.CompareTo("-") == 0) // 스택의 맨 위가 + - 일때
                            {
                                TmpStk.Push(tmp);
                                TmpStk.Push(str);
                                break;
                            }
                            else
                            {
                                PostFixList.Add(tmp);
                            }
                        }
                    }
                }
                else
                {
                    PostFixList.Add(str);
                }
            }
            for (; 0 < TmpStk.Count;)
            {
                PostFixList.Add(TmpStk.Pop());
            }
            return PostFixList.ToArray();
        }
    }
}

