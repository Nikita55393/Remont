using System;
using System.Collections;
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
    /// Логика взаимодействия для Raschet.xaml
    /// </summary>
    public partial class Raschet : Window
    {
        public ProgramEntities11 db = new ProgramEntities11();
        Пользователь user;
		List<Заявка1> za = new List<Заявка1>();
        List<Материал> mat;
		public Raschet(Пользователь user)
        {
            InitializeComponent();
            this.user = user;

            //list1.ItemsSource = za;
            LoadData();
            int count = db.Заявка1.Count(z => z.Код_статуса == 3);
            mat = db.Материал.ToList();
            for(int i = 0; i < mat.Count; i++) 
            {
                cb1.Items.Add(mat[i].Наименование);
            }
            // Вывод количества в TextBox
            t1.Text = count.ToString();
            Random rnd = new Random();
            int n1 = rnd.Next(30, 120);
            Random rnd2 = new Random();
            int n2 = rnd2.Next(30, 120);
            Random rnd3 = new Random();
            int n3 = rnd3.Next(30, 120);
            Random rnd4 = new Random();
            int n4 = rnd4.Next(30, 120);
            int num = (n1 + n2 + n3 + n4)/4;
            t2.Text = num.ToString() + " Мин.";
        }
        private void LoadData()
        {
            var filteredData = db.Заявка1.Where(z => z.Код_статуса == 3).ToList();

            // Очищаем ListView перед добавлением новых элементов
            //list1.Items.Clear();
            za = db.Заявка1.ToList();
            foreach (var za in filteredData)
            {

                // Здесь добавьте нужные поля из вашего объекта Заявка1
                // Например, если у вас есть столбцы "Идентификатор" и "Название"
                //item.Text = заявка.Код.ToString(); // или другое поле, которое вы хотите отображать

                // Добавляем элемент в ListView
                list1.Items.Add(za);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Welcome wel = new Welcome(user);
            wel.Show(); this.Hide();
        }

        private void list1_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
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
                    text1.Text = orteh.Модель;
                    text2.Text = vi.Наименование;
                    cb1.Visibility = Visibility.Visible;    
                    text3.Visibility = Visibility.Visible;
                    button.Visibility = Visibility.Visible;
                    l1.Visibility = Visibility.Visible;
                    l2.Visibility = Visibility.Visible;
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

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cb1 != null)
            {
                if (text3.Text != "")
                {
                    // Получаем выбранную заявку из ListView
                    Заявка1 selectedZayavka = (Заявка1)list1.SelectedItem;

                    // Проверяем, что выбрана заявка и код мастера существует
                    if (selectedZayavka != null)
                    {
                        Материал pol = db.Материал.FirstOrDefault(x => x.Наименование == cb1.Text);
                        int con = db.Заявка1.Count(z => z.Код_статуса == 3);
                        // Проверяем, что пользователь найден
                        if (pol != null)
                        {
                            Доп_материал dop = new Доп_материал
                            {
                                Код_материала = pol.Код_материала,
                                Количество = text3.Text
                            };
                            db.Доп_материал.Add(dop);
                            db.SaveChanges();
                            Отчёт otch = new Отчёт
                            {
                                Количество_гот_заяврок = con.ToString(),
                                Время_выполнения = t2.Text,
                                Код_заявки = selectedZayavka.Код_заявки,
                                Код_доп = dop.Код_доп
                            };
                            db.Отчёт.Add(otch);
                            db.SaveChanges();
                            MessageBox.Show("Успех!");
                            t1.Text = string.Empty;
                            t2.Text = string.Empty;
                            text3.Text = string.Empty;
                            text1.Text = string.Empty;
                            text2.Text = string.Empty;
                            // Сбрасываем ComboBox
                            cb1.SelectedIndex = -1;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не указанно количество!");
                }
            }
            else
            {
                MessageBox.Show("Не выбран доп. материал!");
            }
        }
    }
}
