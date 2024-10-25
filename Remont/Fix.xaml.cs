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
    /// Логика взаимодействия для Fix.xaml
    /// </summary>
    public partial class Fix : Window
    {
        public ProgramEntities11 db = new ProgramEntities11();
        List<Отчёт> ot = new List<Отчёт>();
        Пользователь user;
        public Fix(Пользователь user)
        {
            this.user = user;
            InitializeComponent();
            ot = db.Отчёт.ToList();
            list2.ItemsSource = ot;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Welcome wel = new Welcome(user);    
            wel.Show(); this.Hide();
        }

        private void list2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (list2.SelectedItem != null)
            {
                // Приведение типа для полученного элемента
                Отчёт selectedOtch = (Отчёт)list2.SelectedItem;

                // Получение данных из БД по выбранной заявке
                var statcode = db.Отчёт.FirstOrDefault(x => x.Код_отчёта == selectedOtch.Код_отчёта);
                Заявка1 zai = db.Заявка1.Where(x => x.Код_заявки == selectedOtch.Код_отчёта).FirstOrDefault();
                Доп_материал dop = db.Доп_материал.Where(x => x.Код_материала == selectedOtch.Код_отчёта).FirstOrDefault();
                Материал mater = db.Материал.Where(x => x.Код_материала == dop.Код_доп).FirstOrDefault();

                // Проверяем, что объект был найден
                if (statcode != null)
                {
                    // Заполнение текстовых полей данными
                    t1.Text = statcode.Количество_гот_заяврок;
                    t2.Text = statcode.Время_выполнения;
                    t3.Text = Convert.ToString(zai.Номер_заявки);
                    t4.Text = mater.Наименование;
                    t5.Text = dop.Количество;
                }
                else
                {
                    MessageBox.Show("Отчёт не найден.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите отчёт.");
            }
        }
    }
}
