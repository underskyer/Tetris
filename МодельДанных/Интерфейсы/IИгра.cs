using System.Threading;

namespace Тетрис.МодельДанных.Интерфейсы
{
	public interface IИгра
	{
		void Старт(CancellationToken cancellationToken);

		IИгровоеПоле ИгровоеПоле { get; }
		IСтатистикаИгры СтатистикаИгры { get; }

		void ФигуруВлево();
		void ФигуруВправо();
		void ФигуруПовернуть();
		void ФигуруСбросить();
	}
}