namespace ������.������������.������
{
	readonly struct �������
	{
		public �������(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }

		public ������� ������(int ����� = 1) => new �������(X + �����, Y);
		public ������� �����(int ����� = 1) => new �������(X - �����, Y);
		public ������� ����(int ����� = 1) => new �������(X, Y + �����);
		public ������� ��������(������� ������) => new �������(X + ������.X, Y + ������.Y);
		public override string ToString() => $"(Y:{Y}, X:{X})";
	}
}