using System.ComponentModel;

namespace Тетрис.МодельДанных.Интерфейсы
{
	public interface IСтатистикаИгры : INotifyPropertyChanged
	{
		int Счёт { get; }
		int Ход { get; }
		int ХодыВМинуту { get; }
	}
}