﻿using Тетрис.МодельДанных.Интерфейсы;

namespace Тетрис.МодельДанных.Логика
{
	class НачислительОчков : IНачислительОчков
	{
		public int Рассчитать(int редуцированныеРяды) => редуцированныеРяды == 0 ? 0 : редуцированныеРяды * 2 - 1;
	}
}
