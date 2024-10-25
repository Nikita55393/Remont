using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
using QRCoder;

namespace Remont
{
    /// <summary>
    /// Логика взаимодействия для Zaivka.xaml
    /// </summary>
    public partial class Zaivka : Window
    {
        public ProgramEntities11 db = new ProgramEntities11();
        Пользователь user;
        Оргтехника orgt;
        List<Вид> vidor;
        
        public Zaivka(Пользователь user)
        {
            this.user = user;
            InitializeComponent();
            fio.Text = user.ФИО;
            tel.Text = user.Телефон;
            vidor = db.Вид.ToList();
            for(int i = 0; i <vidor.Count; i++)
            {
                cb1.Items.Add(vidor[i].Наименование);
            }
            string textToEncode = "https://docs.google.com/forms/d/e/1FAIpQLSdhZcExx6LSIXxk0ub55mSu-\r\nWIh23WYdGG9HY5EZhLDo7P8eA/viewform?usp=sf_link";

            // Генерация QR-кода
            GenerateQRCode(textToEncode, "qrcode.png");

            Console.WriteLine("QR-код сгенерирован и сохранён в qrcode.png");
        }
        static void GenerateQRCode(string text, string filePath)
        {
            // Инициализация QR-кодера
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap bitmap = qrCode.GetGraphic(20))
                    {
                        // Сохранение QR-кода в файл
                        bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Welcome wel = new Welcome(user);
            wel.Show(); this.Hide();
        }

        private void SozZaiv_Click(object sender, RoutedEventArgs e)
        {
            if(cb1.Text != "" && model.Text != "" && fio.Text != "" && tel.Text != "" && opis.Text != "")
            {
                Random rnd = new Random();
                int num = rnd.Next(1000, 9999);
                DateTime dat = DateTime.Now;
                Вид vo = db.Вид.FirstOrDefault(x => x.Наименование == cb1.Text);
				Оргтехника org = new Оргтехника
                {
                    Модель = model.Text,
                    Код_вида = vo.Код_вида
                };
                db.Оргтехника.Add(org);
                db.SaveChanges();
                Заявка1 zaiv = new Заявка1
                {
                    Дата = dat,
                    Описание = opis.Text,
                    Код_пользователя = user.Код_пользователя,
                    ФИО_клиента = fio.Text,
                    Телефон = tel.Text,
                    Номер_заявки = Convert.ToString(num),
                    Код_оргтехники = org.Код_оргтехники,
                };
                db.Заявка1.Add(zaiv);
                db.SaveChanges();
                
                MessageBox.Show("Заявка успешно создана!");
            }
            else
            {
                MessageBox.Show("Вы оставили пустые поля!");
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
