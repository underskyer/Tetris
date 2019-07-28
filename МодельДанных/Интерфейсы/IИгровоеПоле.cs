using System;
using System.Collections.Generic;

namespace Тетрис.МодельДанных.Интерфейсы
{
	public interface IИгровоеПоле
	{
		int Вышина { get; }
		int Ширина { get; }
		IReadOnlyList<IReadOnlyList<int>> Ряды { get; }
		event EventHandler ПолеИзменилось;
	}
}