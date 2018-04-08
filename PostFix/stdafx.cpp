// stdafx.cpp : 표준 포함 파일만 들어 있는 소스 파일입니다.
// PostFix.pch는 미리 컴파일된 헤더가 됩니다.
// stdafx.obj에는 미리 컴파일된 형식 정보가 포함됩니다.

#include "stdafx.h"
int order(int ch);
void push(int n);
int pop();
int stack[STK_SIZ + 1];
int stkct;
char plsh_out[80];

char* polish(char *s)
{
	int wk=0;
	char *out = plsh_out;

	stkct = 0;
	for (;;)
	{
		while (*s == ' ')
		{
			++s;
		}
		if (*s == '\0')
		{
			while (stkct > 0)
			{
				if ((*out++ = pop()) == '(')
				{
					puts("'('가 바르지 않음\n"); 
					exit(1);
				}
			}
			return plsh_out;
		}
		if (islower(*s) || isdigit(*s))
		{
			*out++ = *s++;
			continue;
		}
		switch (*s)
		{
			case '(':
				push(*s);
				break;
			case ')':
				while ((wk == pop()) != '(')
				{
					*out++ = wk;
					if (stkct == 0)
					{
						puts("'('가 바르지 않음\n"); 
						exit(1);
					}
					break;
				}
			default:
				if (order(*s) == -1)
				{
					cout << "다음 문자가 바르지 않음: " << *s << endl;
					exit(1);
					while (stkct > 0 && (order(stack[stkct]) >= order(*s)))
					{
						*out++ = pop();
					}
					push(*s);
				}
				s++;
		}
		*out = '\0';
	}
	return s;
}

int order(int ch)
{
	switch (ch)
	{
	case '*':case'/':
		return 3;
	case '+':case '-': 
		return 2;
	case '(':
		return 1;
	}
	return -1;
}
void push(int n)
{
	if (stkct + 1 > STK_SIZ)
	{
		puts("스택 언더플로우"); 
		exit(1);
	}
	stack[++stkct] = n;
}

int pop(){
	if (stkct < 1)
	{
		puts("스택 언더플로우");
		exit(1);
	}
	return stack[stkct--];
}