using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;

namespace Interpreter_cs
{
    class Code
    {
        int Count = 0;
        static int FncCount = 0;
        bool IsDebug = true;
        public Code(string[] Code)
        {
            Parse(Code);
            if(IsDebug)
            {
                foreach (string Str in Table.CodeList)
                {
                    Console.WriteLine(Str);
                }
            }
            ReadCode();
           
            //for(; Count < Code.Length; Count++)
            //{
            //    Parse(Code[Count]);
            //}
        }
        //public void Parse(string CodeLine)
        //{ 
        //    string[] Words;
        //    string PrintText;
        //    string[] tmp;
        //    string Str;
        //    double TDbl = 0;
        //    bool IsRight = false;

        //    Table.FuncStruct TmpFncStruct = new Table.FuncStruct();

        //    Words = CodeLine.Split(' ');

        //    if(Table.TaskStk.Count > 0)
        //    {
        //        if(Table.TaskStk.Peek().Type.CompareTo("FalseIf")==0)
        //        {
        //            if(Words[0].CompareTo("EndIf") == 0)
        //            {
        //                Table.TaskStk.Pop();
        //            }
        //            return;
        //        }
        //        if(Table.TaskStk.Peek().Type.CompareTo("TrueWhile") == 0)
        //        {
        //            if(Words[0].CompareTo("EndWhile") == 0)
        //            {
        //                Count = Table.TaskStk.Pop().LineNo-1;
        //            }
                    
        //        }
        //        else if(Table.TaskStk.Peek().Type.CompareTo("FalseWhile") == 0)
        //        {
        //            if(Words[0].CompareTo("EndWhile")==0)
        //            {
        //                Table.TaskStk.Pop();
        //            }
        //            return;
        //        }
        //        if(Table.TaskStk.Peek().Type.CompareTo("Func")==0)
        //        {
        //            if(Words[0].CompareTo("EndFunc") == 0)
        //            {
        //                Table.TaskStk.Pop();
        //                if (FncCount == 0)
        //                {
        //                    Count = FncCount;
        //                    FncCount = 0;
        //                    Table.LVarTable = new Dictionary<string, Table.LVarStruct>();
        //                }
        //            }
                    

        //            return;
        //        }
        //    }
            

        //    switch (Words[0])
        //    {
        //        case "Print":
        //            PrintText = "";
        //            if(Table.VarTable.ContainsKey(Words[1]))
        //            {
        //                Table.VarTable.TryGetValue(Words[1], out PrintText);
        //                Console.Write(PrintText);
        //                return;
        //            }
                    
        //            for (int i = 1; i < Words.Length; i++)
        //            {
                        
        //                if (i != Words.Length - 1)
        //                {
        //                    PrintText += (Words[i] + " ");
        //                }
        //                else
        //                    PrintText += (Words[i]);
        //            }


        //            Console.Write(PrintText);
        //            return;
        //        case "Println":
        //            PrintText = "";
        //            if (Table.VarTable.ContainsKey(Words[1]))
        //            {
        //                Table.VarTable.TryGetValue(Words[1], out PrintText);
        //                Console.WriteLine(PrintText);
        //                return;
        //            }
        //            for (int i = 1; i < Words.Length; i++)
        //            {
        //                if (i != Words.Length - 1)
        //                {
        //                    PrintText += (Words[i] + " ");
        //                }
        //                else
        //                    PrintText += (Words[i]);
        //            }
        //            Console.WriteLine(PrintText);
        //            return;
        //        case "Calc":
        //            PrintText = "";
                    
        //            for (int i = 1; i < Words.Length; i++)
        //            {
        //                PrintText += (Words[i]);
        //                PrintText += " ";
        //            }
        //            tmp = PrintText.Split(' ');
        //            foreach(string str in PostFix(tmp))
        //            {
        //                Console.Write(str);
        //            }
        //            Console.WriteLine();
        //            Console.WriteLine(Calc(PostFix(tmp)));

        //            return;
        //        case "Var":
        //            if(Words.Length>=3)
        //            {
        //                MakeVar(Words[1],Words[2]);
        //            }
        //            else
        //            {
        //                MakeVar(Words[1]);
        //            }
                    
        //            return;
        //        case "Input":
        //            Table.VarTable[Words[1]] = Console.ReadLine();
        //            return;
        //        case "If":
                    
        //            if(!Table.VarTable.ContainsKey(Words[1]))
        //            {
        //                Exit(1);
        //            }
        //            if (!Table.VarTable.TryGetValue(Words[3], out Str))
        //            {
        //                TDbl = Double.Parse(Words[3]);
        //            }
        //            else
        //                TDbl = Double.Parse(Str);

                    

        //            switch(Words[2])
        //            {
        //                case "==":
        //                    IsRight = Double.Parse(Table.VarTable[Words[1]]) == TDbl;
        //                    break;
        //                case "<":
        //                    IsRight = Double.Parse(Table.VarTable[Words[1]]) < TDbl;
        //                    break;
        //                case ">":
        //                    IsRight = Double.Parse(Table.VarTable[Words[1]]) > TDbl;
        //                    break;
        //                case "<=":
        //                    IsRight = Double.Parse(Table.VarTable[Words[1]]) <= TDbl;
        //                    break;
        //                case ">=":
        //                    IsRight = Double.Parse(Table.VarTable[Words[1]]) >= TDbl;
        //                    break;
        //                case "!=":
        //                    IsRight = Double.Parse(Table.VarTable[Words[1]]) != TDbl;
        //                    break;
        //            }
                    
                    
        //            if(IsRight)
        //            {
        //                Table.TaskStk.Push(new Table.TaskStruct("TrueIf", Count));
        //            }
        //            else
        //            {
        //                Table.TaskStk.Push(new Table.TaskStruct("FalseIf", Count));
        //            }


        //            return;
        //        case "While":
        //            if(Words[1] == null)
        //            {
        //                Table.TaskStk.Push(new Table.TaskStruct("TrueWhile", Count));
        //            }
        //            else
        //            {
        //                if (!Table.VarTable.ContainsKey(Words[1]))
        //                {
        //                    Exit(1);
        //                }
        //                if (!Table.VarTable.TryGetValue(Words[3], out Str))
        //                {
        //                    TDbl = Double.Parse(Words[3]);
        //                }
        //                else
        //                    TDbl = Double.Parse(Str);


        //                switch (Words[2])
        //                {
        //                    case "==":
        //                        IsRight = Double.Parse(Table.VarTable[Words[1]]) == TDbl;
        //                        break;
        //                    case "<":
        //                        IsRight = Double.Parse(Table.VarTable[Words[1]]) < TDbl;
        //                        break;
        //                    case ">":
        //                        IsRight = Double.Parse(Table.VarTable[Words[1]]) > TDbl;
        //                        break;
        //                    case "<=":
        //                        IsRight = Double.Parse(Table.VarTable[Words[1]]) <= TDbl;
        //                        break;
        //                    case ">=":
        //                        IsRight = Double.Parse(Table.VarTable[Words[1]]) >= TDbl;
        //                        break;
        //                    case "!=":
        //                        IsRight = Double.Parse(Table.VarTable[Words[1]]) != TDbl;
        //                        break;
        //                }

        //                if (IsRight)
        //                {
        //                    Table.TaskStk.Push(new Table.TaskStruct("TrueWhile", Count));
        //                }
        //                else
        //                {
        //                    Table.TaskStk.Push(new Table.TaskStruct("FalseWhile", Count));
        //                }
        //            }
        //            return;
        //        case "Func":
        //            int ArgCount = 0;
        //            TmpFncStruct.StartLn = Count;
        //            TmpFncStruct.Params = new List<string>();

        //            for (int i = 2; i < Words.Length; i++)
        //            {
        //                TmpFncStruct.Params.Add(Words[1]);
        //                ArgCount++;
        //            }
        //            TmpFncStruct.Argc = ArgCount;
        //            Table.FuncTable.Add(Words[1], TmpFncStruct);
        //            Table.TaskStk.Push(new Table.TaskStruct("Func", Count));
        //            return;
        //        case "Exit":
        //            Exit(-1);
        //            return;
        //        default:
        //            if (!(Table.VarTable.ContainsKey(Words[0])))
        //            {
        //                if (Table.FuncTable.ContainsKey(Words[0]))
        //                {
        //                    Table.FuncTable.TryGetValue(Words[0], out TmpFncStruct);
        //                    for (int i = 1; i < Words.Length; i++)
        //                    {
        //                        Table.LVarTable.Add(TmpFncStruct.Params[i - 1],
        //                            new Table.LVarStruct(Words[i], Words[0]));
        //                    }
        //                    FncCount = Count + 1;
        //                    Count = TmpFncStruct.StartLn;
        //                    return;
        //                }
        //            }
        //            else
        //                Table.VarTable[Words[0]] = Words[1];
        //            break;
        //    }
        //}

        public void Parse(string[] Code)
        {
            bool StrStart = false;
            bool IsRemarking = false;
            string Str ="";
            foreach(string CodeLine in Code)
            {
                foreach(char Ch in CodeLine)
                {
                    if(Ch == ';' && IsRemarking)
                    {
                        IsRemarking = false;
                    }
                    else if(IsRemarking)
                    {
                        break;
                    }
                        
                    if(Ch == '(' && StrStart == false)
                    {
                        Switch(Str);
                        Table.CodeList.Add("Lparen");
                        Str = "";
                    }
                    else if(Ch==')'&&StrStart == false)
                    {
                        Switch(Str);
                        Table.CodeList.Add("Rparen");
                        Str = "";
                    }
                    else if((Ch == ' ' || Ch == '\t') && StrStart == false)
                    {
                        Switch(Str);
                        Str = "";
                    }
                    else if(Ch == '=' && StrStart == false)
                    {
                        Switch(Str);
                        Table.CodeList.Add("Assign");
                        Str = "";
                    }
                    else if(Ch == '<' && StrStart == false)
                    {
                        Switch(Str);
                        Table.CodeList.Add("Less");
                        Str = "";
                    }
                    else if(Ch == '>' && StrStart == false)
                    {
                        Switch(Str);
                        Table.CodeList.Add("Great");
                    }
                    else if(Ch == ',' && StrStart == false)
                    {
                        Switch(Str);
                        Table.CodeList.Add("Comma");
                        Str = "";
                    }
                    else if(Ch == '!' && StrStart == false)
                    {
                        Switch(Str);
                        Table.CodeList.Add("NotEq");
                        Str = "";
                    }
                    else if(Ch == '"' && StrStart == false)
                    {
                        StrStart = true;
                    }
                    else if(Ch == '"' && StrStart == true)
                    {
                        StrStart = false;
                        Table.CodeList.Add(Str);
                        Str = "";
                    }
                    else if(Ch == '/')
                    {
                        Table.CodeList.Add("Remark");
                        Str = "";
                    }
                    else if(Ch == ';' && StrStart == false)
                    {
                        Switch(Str);
                        Table.CodeList.Add("\n");
                        Str = "";
                    }
                    else
                    {
                        Str += Ch;
                    }
                }
            }
        }

        public void ReadCode()
        {
            bool IsVarDef = false;
            bool IsFuncDef = false;
            bool IsOpened = false;
            bool IsFuncCall = false;
            bool IsLooping = false;
            string tmp = "";
            string val = "";
            int LoopLn = 0;
            Table.LVarStruct lVarStruct = new Table.LVarStruct();
            Table.FuncStruct funcStruct = new Table.FuncStruct();
            Table.TaskStruct taskStruct = new Table.TaskStruct();
            funcStruct.Argc = 0;

            for(int Count = 0; Count < Table.CodeList.Count; Count++)
            {
                switch(Table.CodeList[Count])
                {
                    case "Remark":
                        for (; Table.CodeList[Count].CompareTo("\n") != 0; Count++) ;
                        break;
                    case "Print":
                        break;
                    case "Println":
                        Count +=2;
                        if (Table.VarTable.TryGetValue(Table.CodeList[Count],out tmp))
                        {
                            Console.WriteLine(tmp);
                            tmp = "";
                        }
                        else if(Table.LVarTable.TryGetValue(Table.CodeList[Count],out lVarStruct))
                        {
                            Console.WriteLine(lVarStruct.Val);
                        }
                        else
                        {
                            Console.WriteLine(Table.CodeList[Count]);
                        }
                        break;
                    case "Var":
                        IsVarDef = true;
                        break;
                    case "Input":
                        try
                        {
                            Table.VarTable[Table.CodeList[Count + 2]] = Console.ReadLine();
                        }
                        catch(Exception e)
                        {
                            Exit(2);
                        }
                        break;
                    case "If":
                        double Dbl;
                        bool IsRight = false;
                        if (!Table.VarTable.ContainsKey(Table.CodeList[Count + 2]))
                        {
                            Exit(1);
                        }
                        if (!Table.VarTable.TryGetValue(Table.CodeList[Count + 2], out tmp))
                        {
                            Dbl = Double.Parse(Table.CodeList[Count + 2]);
                        }
                        else
                            Dbl = Double.Parse(tmp);



                        switch (Table.CodeList[Count+3])
                        {
                            case "Assign":
                                if(Table.CodeList[Count + 4].CompareTo("Assign") == 0)
                                {
                                    IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) == Dbl;
                                }
                                break;
                            case "Less":
                                if (Table.CodeList[Count + 4].CompareTo("Assign") == 0)
                                {
                                    IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) <= Dbl;
                                    break;
                                }
                                IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) < Dbl;
                                break;
                            case "Great":
                                if (Table.CodeList[Count + 4].CompareTo("Assign") == 0)
                                {
                                    IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) >= Dbl;
                                    break;
                                }
                                IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) > Dbl;
                                break;
                            case "NotEq":
                                if (Table.CodeList[Count + 4].CompareTo("Assign") == 0)
                                    IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) != Dbl;
                                break;
                        }
                        if(!IsRight)
                        {
                            for (; Table.CodeList[Count].CompareTo("EndIf") != 0; Count++) ;
                        }
                        break;
                    case "While":
                        IsLooping = true;
                        IsRight = false;
                        LoopLn = Count-1;
                        if (!Table.VarTable.ContainsKey(Table.CodeList[Count + 2]))
                        {
                            Exit(1);
                        }
                        switch (Table.CodeList[Count + 3])
                        {
                            case "Assign":
                                if (Table.CodeList[Count + 4].CompareTo("Assign") == 0)
                                {
                                    Dbl = Double.Parse(Table.CodeList[Count + 5]);
                                    IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) == Dbl;
                                }
                                break;
                            case "Less":
                                if (Table.CodeList[Count + 4].CompareTo("Assign") == 0)
                                {
                                    Dbl = Double.Parse(Table.CodeList[Count + 5]);
                                    IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) <= Dbl;
                                    break;
                                }
                                Dbl = Double.Parse(Table.CodeList[Count + 4]);
                                IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) < Dbl;
                                break;
                            case "Great":
                                if (Table.CodeList[Count + 4].CompareTo("Assign") == 0)
                                {
                                    Dbl = Double.Parse(Table.CodeList[Count + 5]);
                                    IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) >= Dbl;
                                    break;
                                }
                                Dbl = Double.Parse(Table.CodeList[Count + 4]);
                                IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) > Dbl;
                                break;
                            case "NotEq":
                                if (Table.CodeList[Count + 4].CompareTo("Assign") == 0)
                                {
                                    Dbl = Double.Parse(Table.CodeList[Count + 5]);
                                    IsRight = Double.Parse(Table.VarTable[Table.CodeList[Count + 2]]) != Dbl;
                                }
                                break;
                        }
                        if (!IsRight)
                        {
                            for (; Table.CodeList[Count].CompareTo("EndWhile") != 0 &&
                                Count < Table.CodeList.Count; Count++) ;
                            Count++;
                            IsLooping = false;
                            break;
                        }
                        break;
                    case "EndWhile":
                        if(IsLooping)
                        {
                            Count = LoopLn;
                        }
                        break;
                    case "Func":
                        IsFuncDef = true;
                        break;
                    case "EndFunc":
                        taskStruct = Table.TaskStk.Pop();
                        Count = taskStruct.LineNo;
                        break;
                    case "Exit":
                        return;
                    default:
                        if(IsFuncDef && Table.CodeList[Count].CompareTo("\n")==0)
                        {
                            funcStruct.StartLn = Count + 1;
                            
                            if (Table.FuncTable.Keys.Contains(tmp))
                            {
                                    Exit(4);
                            }

                            for (; ; Count++)
                            {
                                if (Table.CodeList[Count].CompareTo("EndFunc") == 0)
                                {
                                    Count++;
                                    IsFuncDef = false;
                                    break;
                                }
                            }

                            Table.FuncTable.Add(tmp, funcStruct);
                            funcStruct.Argc = 0;
                            funcStruct.StartLn = 0;
                            if(funcStruct.Params != null)
                            {
                                funcStruct.Params.Clear();
                            }
                            tmp = "";
                        }
                        else if(IsFuncDef && Table.CodeList[Count].CompareTo("Lparen")==0)
                        {
                            IsOpened = true;
                        }
                        else if(IsFuncDef && Table.CodeList[Count].CompareTo("Rparen")==0)
                        {
                            IsOpened = false;
                        }
                        else if(IsOpened && IsFuncDef && Table.CodeList[Count].CompareTo("Comma")==0)
                        {
                            funcStruct.Argc++;
                            funcStruct.Params.Add(Table.CodeList[Count]);
                        }
                        else if(IsFuncDef && Table.CodeList[Count].CompareTo("EndFunc")==0)
                        {
                            IsFuncDef = false;
                        }
                        else if(IsFuncDef)
                        {
                            tmp = Table.CodeList[Count];
                        }
                        //함수 정의 끝
                        if (IsFuncCall && Table.CodeList[Count].CompareTo("Lparen") == 0)
                        {
                            if (funcStruct.Argc != 0)
                            {
                                funcStruct.Params.Add(Table.CodeList[Count + 1]);
                            }
                        }
                        else if (IsFuncCall && Table.CodeList[Count].CompareTo("Comma") == 0)
                        {
                            funcStruct.Params.Add(Table.CodeList[Count + 1]);
                            continue;
                        }
                        else if (IsFuncCall && Table.CodeList[Count].CompareTo("\n") == 0)
                        {
                            taskStruct.LineNo = Count + 1;
                            taskStruct.Type = "Func";
                            Table.TaskStk.Push(taskStruct);
                            Count = funcStruct.StartLn + 2;
                            IsFuncCall = false;
                        }
                        else if (IsFuncDef == false && Table.FuncTable.ContainsKey(Table.CodeList[Count]))
                        {
                            Table.FuncTable.TryGetValue(Table.CodeList[Count - 1], out funcStruct);
                            IsFuncCall = true;
                            taskStruct.ReturnNo = Count - 1;
                        }
                        //함수 호출 끝
                        if (IsVarDef && Table.CodeList[Count].CompareTo("\n")==0)
                        {
                            MakeVar(tmp, val);
                            IsVarDef = false;
                        }
                        else if(IsVarDef && Table.CodeList[Count].CompareTo("Assign")==0)
                        {
                            Count++;
                            val = Table.CodeList[Count];
                            //변수 초기화를 함수로 할 시엔 따로 처리를 해야함
                        }
                        else if(IsVarDef)
                        {
                            tmp = Table.CodeList[Count];
                        }
                        //변수 정의 끝
                        if(Table.CodeList[Count].CompareTo("Assign") == 0)
                        {
                            Table.VarTable[Table.CodeList[Count - 1]] = Table.CodeList[Count + 1];
                        }
                        break;
                }
            }
        }

        public void Switch(string Str)
        {
            switch (Str)
            {
                case "Print":
                    Table.CodeList.Add("Print");
                    break;
                case "Println":
                    Table.CodeList.Add("Println");
                    break;
                case "Var":
                    Table.CodeList.Add("Var");
                    break;
                case "Input":
                    Table.CodeList.Add("Input");
                    break;
                case "If":
                    Table.CodeList.Add("If");
                    break;
                case "While":
                    Table.CodeList.Add("While");
                    break;
                case "Func":
                    Table.CodeList.Add("Func");
                    break;
                case "EndFunc":
                    Table.CodeList.Add("EndFunc");
                    break;
                case "Exit":
                    Table.CodeList.Add("Exit");
                    return;
                default:
                    if(Str.CompareTo("")!=0)
                        Table.CodeList.Add(Str);
                    break;
            }
        }

        public void Exit(int Code)
        {
            switch(Code)
            {
                case 0:
                    Console.WriteLine("토큰이나 변수를 찾을 수 없습니다");    
                    break;
                case 1:
                    Console.WriteLine("조건문 첫번째 인수에는 선언된 변수만 들어갈 수 있습니다");
                    break;
                case 2:
                    Console.WriteLine("입력한 값이 올바르지 않습니다");
                    break;
                case 3:
                    Console.WriteLine("변수 이름이 중복되었습니다");
                    break;
                case 4:
                    Console.WriteLine("이 언어는 함수 오버로딩을 지원하지 않습니다");
                    break;
                case -1:
                    Console.WriteLine("프로그램이 강제 종료 되었습니다");
                    break;
            }
            Environment.Exit(0);
        }

        void MakeVar(string name,string val)
        {
            if (!(Table.VarTable.Keys.Contains(name)))
            {
                Table.VarTable.Add(name, val);
            }
            else
            {
                Exit(3);
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

