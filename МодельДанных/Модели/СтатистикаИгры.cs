using System.ComponentModel;
using Тетрис.МодельДанных.Интерфейсы;

namespace Тетрис.МодельДанных.Модели
{
	class СтатистикаИгры : IСтатистикаИгры
	{
		int _Ход = -1;
		public int Ход
		{
			get => _Ход;
			set
			{
				if (_Ход == value)
					return;
				_Ход = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ход)));
			}
		}
		int _Счёт = 1;
		public int Счёт
		{
			get => _Счёт;
			set
			{
				if (_Счёт == value)
					return;
				_Счёт = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Счёт)));
			}
		}
		int _ХодыВМинуту = -1;
		public int ХодыВМинуту
		{
			get => _ХодыВМинуту;
			set
			{
				if (_ХодыВМинуту == value)
					return;
				_ХодыВМинуту = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ХодыВМинуту)));
			}
		}
		public void Сбросить()
		{
			Ход = 0;
			Счёт = 0;
		}
		public void СледующийХод() => ++Ход;
		public void ДобавитьОчки(int очки) => Счёт += очки;
		public void УстановитьСкорость(int ходыВМинуту) => ХодыВМинуту = ходыВМинуту;
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
