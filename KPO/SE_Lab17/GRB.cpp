#include <iostream>
#include <cstdarg>
#include <initializer_list>
#include "stdafx.h"

#define GRB_ERROR_SERIES 600
#define NS(n) GRB::Rule::Chain::N(n)
#define TS(n) GRB::Rule::Chain::T(n)

using namespace std;

namespace GRB {

	extern Greibach greibach;



	Rule::Chain::Chain(short psize, GRBALPHABET s, ...)
	{
		size = psize;
		nt = new GRBALPHABET[size];

		nt[0] = s;

		va_list args;
		va_start(args, s);
		for (short i = 1; i < size; ++i)
		{
			int v = va_arg(args, int);
			nt[i] = static_cast<GRBALPHABET>(v);
		}
		va_end(args);
	};

	Rule::Rule(GRBALPHABET pnn, int piderror, short psize, Chain c, ...)
	{
		nn = pnn;
		iderror = piderror;
		size = psize;
		chains = new Chain[size];

		chains[0] = c;

		va_list args;
		va_start(args, c);
		for (int i = 1; i < size; ++i)
		{
			chains[i] = va_arg(args, Chain);
		}
		va_end(args);
	};

	Greibach::Greibach(GRBALPHABET pstartN, GRBALPHABET pstbottom, std::initializer_list<Rule> rulesList)
	{
		startN = pstartN;
		stbottomT = pstbottom;
		size = static_cast<short>(rulesList.size());
		rules = new Rule[size];
		int i = 0;
		for (const Rule& r : rulesList) rules[i++] = r;
	};

	Greibach getGreibach() {
		return greibach;
	};

	short Greibach::getRule(GRBALPHABET pnn, Rule& prule)
	{

		//cout << "DEBUG getRule: ищем " << int(pnn) << " (" << (char)abs(pnn) << ")" << endl;
		//for (int k = 0; k < size; k++)
		//{
		//	cout << "  rule[" << k << "].nn = " << int(rules[k].nn)
		//		<< " (" << (char)abs(rules[k].nn) << ")" << endl;
		//}

		short rc = -1;
		short k = 0;
		while (k < size && rules[k].nn != pnn)
		{
			k++;
		}
		if (k < size)
		{
			prule = rules[rc = k];
		}
		return rc;
	};

	Rule Greibach::getRule(short n)
	{
		Rule rc;
		if (n < size)
		{
			rc = rules[n];
		}
		return rc;
	};

	char* Rule::getCRule(char* b, short nchain)
	{
		char bchain[200];
		b[0] = Chain::alphabet_to_char(nn);
		b[1] = '-';
		b[2] = '>';
		b[3] = 0x00;
		chains[nchain].getCChain(bchain);
		strcat_s(b, sizeof(bchain) + 5, bchain);
		return b;
	};

	short Rule::getNextChain(GRBALPHABET t, Rule::Chain& pchain, short j)
	{

		while (j < size)
		{

			//std::cout << "DEBUG getNextChain: t=" << int(t)
			//	<< " chain[" << j << "].nt[0]=" << int(chains[j].nt[0])
			//	<< std::endl;

			if (chains[j].nt[0] == t)
			{
				pchain = chains[j];
				return j;
			}
			++j;
		}
		return -1;
	}


	char* Rule::Chain::getCChain(char* b)
	{
		for (int i = 0; i < size; i++)
		{
			b[i] = Chain::alphabet_to_char(nt[i]);
		}
		b[size] = 0x00;
		return b;
	};




	Greibach greibach(NS('S'), TS('$'),
		{
			// --- Начало программы ---
			Rule(NS('S'), GRB_ERROR_SERIES + 0,
				3,
				Rule::Chain(8, TS('m'), TS('{'), NS('N'), TS('r'), NS('E'), TS(';'), TS('}'), TS(';')),
				Rule::Chain(14, TS('t'), TS('i'), TS('f'), TS('('), NS('F'), TS(')'), TS('{'), NS('N'), TS('r'), NS('E'), TS(';'), TS('}')),
				Rule::Chain(9, TS('m'), TS('{'), NS('N'), TS('r'), NS('E'), TS(';'), TS('}'), TS(';'), NS('S'))
			),

				// --- Операторы ---
				Rule(NS('N'), GRB_ERROR_SERIES + 1,
					17,
					Rule::Chain(4, TS('d'), TS('t'), TS('i'), TS(';')),
					Rule::Chain(3, TS('r'), NS('E'), TS(';')),
					Rule::Chain(4, TS('i'), TS('='), NS('E'), TS(';')),
					Rule::Chain(8, TS('d'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS(';')),
					Rule::Chain(5, TS('d'), TS('t'), TS('i'), TS(';'), NS('N')),
					Rule::Chain(4, TS('r'), NS('E'), TS(';'), NS('N')),
					Rule::Chain(5, TS('i'), TS('='), NS('E'), TS(';'), NS('N')),
					Rule::Chain(9, TS('d'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS(';'), NS('N')),
					Rule::Chain(6, TS('i'), TS('='), TS('i'), TS('('), NS('F'), TS(')'), TS(';')),
					Rule::Chain(4, TS('i'), TS('='), TS('l'), TS(';')),
					Rule::Chain(5, TS('i'), TS('='), TS('l'), TS(';'), NS('N')),
					Rule::Chain(4, TS('p'), TS('i'), TS(';'), NS('N')),
					Rule::Chain(3, TS('p'), TS('i'), TS(';')),
					Rule::Chain(4, TS('p'), TS('l'), TS(';'), NS('N')),
					Rule::Chain(3, TS('p'), TS('l'), TS(';')),
					Rule::Chain(7, TS('p'), TS('i'), TS('('), NS('F'), TS(')'), TS(';'), NS('N')),
					Rule::Chain(6, TS('p'), TS('i'), TS('('), NS('F'), TS(')'), TS(';'))
				),

				// --- Выражения ---
				Rule(NS('E'), GRB_ERROR_SERIES + 2,
					10,
					Rule::Chain(1, TS('i')),
					Rule::Chain(1, TS('l')),
					Rule::Chain(3, TS('('), NS('E'), TS(')')),
					Rule::Chain(4, TS('i'), TS('('), NS('W'), TS(')')),
					Rule::Chain(4, TS('i'), TS('('), NS('F'), TS(')')),
					Rule::Chain(2, TS('i'), NS('M')),
					Rule::Chain(2, TS('l'), NS('M')),
					Rule::Chain(4, TS('('), NS('E'), TS(')'), NS('M')),
					Rule::Chain(5, TS('i'), TS('('), NS('W'), TS(')'), NS('M')),
					Rule::Chain(5, TS('i'), TS('('), NS('F'), TS(')'), TS(';'))
				),

				// --- Параметры функции (описание при объявлении функции) ---
				Rule(NS('F'), GRB_ERROR_SERIES + 3,
					4,
					Rule::Chain(4, TS('t'), TS('i'), TS(','), NS('F')),
					Rule::Chain(2, TS('t'), TS('i')),
					Rule::Chain(3, TS('i'), TS(','), NS('F')),
					Rule::Chain(1, TS('i'))
				),

				// --- Аргументы функции (при вызове функции) ---
				Rule(NS('W'), GRB_ERROR_SERIES + 4,
					3,
					Rule::Chain(1, NS('E')),                      // одно выражение
					Rule::Chain(3, NS('E'), TS(','), NS('W')),    // несколько аргументов: E, W
					Rule::Chain(1, TS(')'))                       // пустой список аргументов (вызов без параметров)
				),

				// --- Продолжение выражения (операторы +, -, *, /) ---
				Rule(NS('M'), GRB_ERROR_SERIES + 2,
					4,
					Rule::Chain(2, TS('+'), NS('E')),             // +E
					Rule::Chain(2, TS('-'), NS('E')),             // -E
					Rule::Chain(2, TS('*'), NS('E')),             // *E
					Rule::Chain(2, TS('/'), NS('E'))             // /E
				)
		});



}