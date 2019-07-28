using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Unity;
using Тетрис.МодельДанных;
using Тетрис.МодельДанных.Интерфейсы;

namespace Тетрис.ЗапускаемыйМодуль
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Container = new UnityContainer().Зарегистрировать();
			Игра = Container.Resolve<IИгра>();
			//Игра.СчётИзменился += (s, a) => Dispatcher.Invoke(() => БлокСчёта.Text = Игра.Счёт.ToString());
			Игра.СтатистикаИгры.PropertyChanged += (s, a) =>
			{
				if (a.PropertyName == nameof(Игра.СтатистикаИгры.Счёт))
					Dispatcher.Invoke(() => БлокСчёта.Text = Игра.СтатистикаИгры.Счёт.ToString());
				else if (a.PropertyName == nameof(Игра.СтатистикаИгры.Ход))
					Dispatcher.Invoke(() => БлокХода.Text = Игра.СтатистикаИгры.Ход.ToString());
				else if (a.PropertyName == nameof(Игра.СтатистикаИгры.ХодыВМинуту))
					Dispatcher.Invoke(() => БлокСкорости.Text = Игра.СтатистикаИгры.ХодыВМинуту.ToString());
			};

			Игра.ИгровоеПоле.ПолеИзменилось += (s, a) => Dispatcher.Invoke(ОтрисовкаПоля);
		}

		IUnityContainer Container;
		IИгра Игра;

		void ОтрисовкаПоля()
		{
			Поле.Children.Clear();

			var ширинаКлетки = Поле.ActualWidth / Игра.ИгровоеПоле.Ширина;
			var высотаКлетки = Поле.ActualHeight / Игра.ИгровоеПоле.Вышина;

			var ряды = Игра.ИгровоеПоле.Ряды;
			for (int y = 0; y < ряды.Count; ++y)
			{
				var ряд = ряды[y];
				for (int x = 0; x < ряд.Count; ++x)
					if (ряд[x] > 0)
					{
						var клетка = new Rectangle
						{
							Width = ширинаКлетки,
							Height = высотаКлетки,
							//Fill = ряд[x] > 0 ? Brushes.Black : Brushes.White,
							//Stroke = Brushes.LightGray,
							Fill = Brushes.Black,
							Stroke = Brushes.Transparent,
							StrokeThickness = 2,
						};
						Canvas.SetLeft(клетка, x * ширинаКлетки);
						Canvas.SetTop(клетка, y * высотаКлетки);
						Поле.Children.Add(клетка);
					}
			}
		}

		Task ИгроваяЗадача;
		CancellationTokenSource CancellationTokenSource;
		async void Start_Click(object sender, RoutedEventArgs e) => await Старт();
		Task Старт()
		{
			CancellationTokenSource?.Cancel();
			CancellationTokenSource?.Dispose();
			CancellationTokenSource = new CancellationTokenSource();

			var tocken = CancellationTokenSource.Token;
			ИгроваяЗадача = Task.Run(() =>
			{
				Игра.Старт(tocken);
				Dispatcher.Invoke(() => MessageBox.Show("Игра окончена!", "Тетрис", MessageBoxButton.OK, MessageBoxImage.Information));
			}, tocken);
			return ИгроваяЗадача;
		}
		async void Left_Click(object sender, RoutedEventArgs e)
		{
			await Task.Run(Игра.ФигуруВлево);
		}
		async void Right_Click(object sender, RoutedEventArgs e)
		{
			await Task.Run(Игра.ФигуруВправо);
		}
		async void Rotate_Click(object sender, RoutedEventArgs e)
		{
			await Task.Run(Игра.ФигуруПовернуть);
		}

		async void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				await Старт();
				return;
			}
			var действие = e.Key switch
			{
				Key.Up => Игра.ФигуруПовернуть,
				Key.Down => Игра.ФигуруСбросить,
				Key.Left => Игра.ФигуруВлево,
				Key.Right => Игра.ФигуруВправо,
				_ => (Action)null,
			};
			if (действие!= null)
				await Task.Run(действие);
		}
	}
}
