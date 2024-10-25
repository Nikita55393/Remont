using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Redact.xaml
    /// </summary>
    public partial class Redact : Window
    {
        public ProgramEntities11 db = new ProgramEntities11();
        Пользователь user;
        List<Заявка1> za = new List<Заявка1>();
        List<Статус> stat;
        List<Пользователь> mast = new List<Пользователь>();
        public Redact(Пользователь user)
        {
            InitializeComponent();
            this.user = user;
            za = db.Заявка1.ToList();
            list1.ItemsSource = za;
            LoadData();
            stat = db.Статус.ToList();
            for (int i = 0; i < stat.Count; i++)
            {
                kod_stat.Items.Add(stat[i].Наименование);
            }
            if(user.Код_типа_пользователя == 1)
            {
                butt1.Visibility = Visibility.Visible;
                l1.Visibility = Visibility.Visible;
                kod_mast.Visibility = Visibility.Visible;
            }
            if(user.Код_типа_пользователя == 2)
            {
				butt2.Visibility = Visibility.Visible;
				l2.Visibility = Visibility.Visible;
				kod_stat.Visibility = Visibility.Visible;
                kom.Visibility = Visibility.Visible;
			}

		}
		private void LoadData()
		{
			// Отфильтровываем пользователей по типу пользователя
			mast = db.Пользователь.Where(x => x.Код_типа_пользователя == 2).ToList();

			// Заполняем ComboBox
			foreach (var пользователь in mast)
			{
				kod_mast.Items.Add(пользователь.ФИО);
			}

			// Загружаем заявки
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
                // Приведение типа для полученного элемента
                Заявка1 selectedZayavka = (Заявка1)list1.SelectedItem;

                // Получение данных из БД по выбранной заявке
                var statcode = db.Заявка1.FirstOrDefault(x => x.Код_заявки == selectedZayavka.Код_заявки);
                Оргтехника orteh = db.Оргтехника.FirstOrDefault(x => x.Код_оргтехники == statcode.Код_оргтехники);
                Вид vi = db.Вид.FirstOrDefault(x => x.Код_вида == orteh.Код_вида);

                // Проверяем, что объект был найден
                if (statcode != null)
                {
                    // Заполнение текстовых полей данными
                    t1.Text = orteh.Модель;
                    t2.Text = vi.Наименование;
                    t3.Text = statcode.Номер_заявки;
                    opis.Text = statcode.Описание;
                }
                else
                {
                    MessageBox.Show("Заявка не найдена.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку.");
            }
        }

        private void butt_Click(object sender, RoutedEventArgs e)
        {
            if (kod_mast != null)
            {
                if(kod_stat != null){
                    // Получаем выбранную заявку из ListView
                    Заявка1 selectedZayavka = (Заявка1)list1.SelectedItem;

                    // Проверяем, что выбрана заявка и код мастера существует
                    if (selectedZayavka != null)
                    {
                        Пользователь pol = db.Пользователь.Where(x => x.ФИО == kod_mast.Text).FirstOrDefault();
                        Статус st = db.Статус.Where(x => x.Наименование == kod_stat.Text).FirstOrDefault();
                        // Проверяем, что пользователь найден
                        if (pol != null)
                        {
                            // Обновляем Код_мастера для выбранной заявки
                            selectedZayavka.Код_мастера = pol.Код_пользователя;
                        
					        if (st != null)
					        {
                                selectedZayavka.Код_статуса = st.Код_статуса;
					        };
                            // Сохраняем изменения в базе данных
                            db.SaveChanges();
                            MessageBox.Show("Успех!");
							opis.Text = string.Empty;
							t1.Text = string.Empty;
							t2.Text = string.Empty;
							t3.Text = string.Empty;
							kom.Text = string.Empty;
							opis.Text = string.Empty;
							// Сбрасываем ComboBox
							kod_stat.SelectedIndex = -1;
							kod_mast.SelectedIndex = -1;
						}
                    }
                }
				else
				{
					MessageBox.Show("Не выбран статус!");
				}
			}
            else
            {
				MessageBox.Show("Не выбран мастер!");
			}
        }

		private void butt2_Click(object sender, RoutedEventArgs e)
		{
			if (kod_stat != null)
			{
				// Получаем выбранную заявку из ListView
				Заявка1 selectedZayavka = (Заявка1)list1.SelectedItem;

				// Проверяем, что выбрана заявка и код мастера существует
				if (selectedZayavka != null)
				{
					Статус st = db.Статус.Where(x => x.Наименование == kod_stat.Text).FirstOrDefault();

				    if (st != null)
					{
                        selectedZayavka.Комментарий = kom.Text;
						selectedZayavka.Код_статуса = st.Код_статуса;
					};
					// Сохраняем изменения в базе данных
					db.SaveChanges();
					MessageBox.Show("Успех!");
					opis.Text = string.Empty;
					t1.Text = string.Empty;
					t2.Text = string.Empty;
					t3.Text = string.Empty;
					kom.Text = string.Empty;
					opis.Text = string.Empty;
					// Сбрасываем ComboBox
					kod_stat.SelectedIndex = -1;
				}
			}
			else
			{
				MessageBox.Show("Не выбран статус!");
			}
		}
	}
}
