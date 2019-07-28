using System.Configuration;

namespace Тетрис.МодельДанных.Модели
{
	public class ПараметрыИгровогоПоля : ApplicationSettingsBase
	{
		[ApplicationScopedSetting]
		[DefaultSettingValue("20")]
		public int Вышина { get => (int)this[nameof(Вышина)]; set => this[nameof(Вышина)] = value; }
		[ApplicationScopedSetting]
		[DefaultSettingValue("10")]
		public int Ширина { get => (int)this[nameof(Ширина)]; set => this[nameof(Ширина)] = value; }
	}
}
