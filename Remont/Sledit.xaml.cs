using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Remont
{
    /// <summary>
    /// Логика взаимодействия для Sledit.xaml
    /// </summary>
    public partial class Sledit : Window
    {
        public ProgramEntities11 db = new ProgramEntities11();
        Пользователь user;
		List<Заявка1> za = new List<Заявка1>();
		public Sledit(Пользователь user)
        {
            InitializeComponent();
            this.user = user;
			za = db.Заявка1.ToList();
			list1.ItemsSource = za;
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Welcome wel = new Welcome(user);
            wel.Show(); this.Hide();
        }

        private void list1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (list1.SelectedItem != null)
            {
				Заявка1 selectedZayavka = (Заявка1)list1.SelectedItem;

				// Получение данных из БД по выбранной заявке
				var statcode = db.Заявка1.FirstOrDefault(x => x.Код_заявки == selectedZayavka.Код_заявки);
				Статус sta = db.Статус.Where(x => x.Код_статуса == statcode.Код_статуса).FirstOrDefault();

				// Проверяем, что объект был найден
				if (statcode != null)
				{
					if(sta != null)
					{
						t1.Text = sta.Наименование;
						t2.Text = statcode.Комментарий;
					}
					else
					{
						MessageBox.Show("Нет данных.");
					}
				}
				else
				{
					MessageBox.Show("Заявка не найдена.");
				}
			}
        }

        private void QR_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                // URL для перехода
                string url = "https://docs.google.com/forms/d/e/1FAIpQLSdhZcExx6LSIXxk0ub55mSu-\r\nWIh23WYdGG9HY5EZhLDo7P8eA/viewform?usp=sf_link";
                OpenLink(url);
            }
        }

        private void OpenLink(string url)
        {
            try
            {
                // Открытие ссылки в браузере
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии ссылки: " + ex.Message);
            }
        }
    }
}
