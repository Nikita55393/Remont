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
    /// Логика взаимодействия для Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        Пользователь user;
        public Welcome(Пользователь user)
        {
            this.user = user;   
            InitializeComponent();
            if(user.Код_типа_пользователя == 3)
            {
                bt1.Visibility = Visibility.Visible;
                bt3.Visibility = Visibility.Visible;
            }
			if (user.Код_типа_пользователя == 2)
			{
                bt2.Visibility = Visibility.Visible;
                bt6.Visibility = Visibility.Visible;
			}
			if (user.Код_типа_пользователя == 1)
			{
				bt2.Visibility = Visibility.Visible;
                bt5.Visibility = Visibility.Visible;
			}

		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show(); this.Hide();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            Zaivka za = new Zaivka(user);
            za.Show(); this.Hide();
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            Redact re = new Redact(user);
            re.Show(); this.Hide();
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            Sledit sl = new Sledit(user);
            sl.Show(); this.Hide();
        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            Master mas = new Master(user);
            mas.Show(); this.Hide();
        }

        private void bt5_Click(object sender, RoutedEventArgs e)
        {
            Fix fi = new Fix(user);
            fi.Show(); this.Hide();
        }
        private void bt6_Click(object sender, RoutedEventArgs e)
        {
            Raschet ras = new Raschet(user);
            ras.Show(); this.Hide();
        }
    }
}
