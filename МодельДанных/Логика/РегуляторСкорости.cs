﻿using System;
using Тетрис.МодельДанных.Интерфейсы;

namespace Тетрис.МодельДанных.Логика
{
	class РегуляторСкорости : IРегуляторСкорости
	{
		public int Рассчитать(IСтатистикаИгры статистикаИгры)
		{
			return (int)(1.8 * Math.Sqrt(статистикаИгры.Ход) + 59);
		}
	}
}
