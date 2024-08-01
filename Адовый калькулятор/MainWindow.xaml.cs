using System;
using System.Data;
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

namespace Адовый_калькулятор
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in Бульбулятор.Children) //Перебор объектов
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click; //Обращение к батонам
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Обработка нажатий на батоны
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "AC")
                textLabel.Text = ""; //Бинд на кнопку AC, очистка строки
            else if (str == "=")
            {
                string value = new DataTable().Compute(textLabel.Text, null).ToString(); textLabel.Text = value; //Вычисление при действии "="
            }
            else textLabel.Text += str; //Добавление к текущей цифре соседа по жилплощади
        }
    }
}
