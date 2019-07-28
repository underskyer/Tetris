using Unity;
using Тетрис.МодельДанных.Интерфейсы;
using Тетрис.МодельДанных.Логика;

namespace Тетрис.МодельДанных
{
	public static class РегистрацияВUnityContainer
	{
		public static IUnityContainer Зарегистрировать(this IUnityContainer container)
		{
			return container
				.RegisterType<IГенераторФигур, ГенераторФигур>()
				.RegisterType<IИгра, Игра>()
				.RegisterType<IИгровоеПоле, ИгровоеПоле>()
				.RegisterType<IРегуляторСкорости, РегуляторСкорости>()				
				.RegisterType<IНачислительОчков, НачислительОчков>()
		   ;
		}
	}
}
