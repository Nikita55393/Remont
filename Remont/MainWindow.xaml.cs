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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Remont
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ProgramEntities11 db = new ProgramEntities11();
        Пользователь user;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = db.Пользователь.FirstOrDefault(x => x.Логин == t1.Text && x.Пароль == t2.Text);
            if(user != null)
            {
                if(user.Код_типа_пользователя == 1)
                {
                    MessageBox.Show("Вы успешно авторизовались!");
                    Welcome wel = new Welcome(user);
                    wel.Show(); this.Hide();
                }
                else if(user.Код_типа_пользователя == 2)
                {
                    MessageBox.Show("Вы успешно авторизовались!");
                    Welcome wel = new Welcome(user);
                    wel.Show(); this.Hide();
                }
                else if(user.Код_типа_пользователя== 3)
                {
                    MessageBox.Show("Вы успешно авторизовались!");
                    Welcome wel = new Welcome(user);
                    wel.Show(); this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }
    }
}
