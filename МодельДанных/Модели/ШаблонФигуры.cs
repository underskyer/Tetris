using System;
using System.Collections.Immutable;

namespace Тетрис.МодельДанных.Модели
{
	class ШаблонФигуры
	{
		public ШаблонФигуры(string название, Позиция[] точки)
		{
			Название = название ?? throw new ArgumentNullException();
			Точки = ImmutableArray.Create(точки);
		}

		public ШаблонФигуры(string название, (int x, int y)[] точки)
			: this(название, Array.ConvertAll(точки, тчк => new Позиция(тчк.x, тчк.y)))
		{
		}

		public ImmutableArray<Позиция> Точки { get; }
		public string Название { get; }
		public override string ToString() => Название;
	}
}
