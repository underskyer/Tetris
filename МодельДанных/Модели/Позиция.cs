namespace Тетрис.МодельДанных.Модели
{
	readonly struct Позиция
	{
		public Позиция(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }

		public Позиция Вправо(int сдвиг = 1) => new Позиция(X + сдвиг, Y);
		public Позиция Влево(int сдвиг = 1) => new Позиция(X - сдвиг, Y);
		public Позиция Вниз(int сдвиг = 1) => new Позиция(X, Y + сдвиг);
		public Позиция Сдвинуть(Позиция начало) => new Позиция(X + начало.X, Y + начало.Y);
		public override string ToString() => $"(Y:{Y}, X:{X})";
	}
}