using doing;
using function;
using prak8_;
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

namespace prak8_
{
    /// <summary>
    /// Логика взаимодействия для dialog.xaml
    /// </summary>
    public partial class dialog : Window
    {
        public dialog()
        {
            InitializeComponent();
            set_them_and_language(use.read("them.txt"), use.read("language.txt"));
            tb.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text == "")
            {
                MessageBox.Show("Поле не заполнено");
                return;
            }
            if (Use.naz.Contains(tb.Text.ToString()))
            {
                MessageBox.Show("Такой тип уже есть");
                return;
            }
            Use.naz.Add(tb.Text);
            Jsonka.Ser("naz.json", Use.naz);
            Hide();
            new MainWindow().Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new MainWindow().Show();
        }

        private void Click_1(object sender, RoutedEventArgs e)
        {
            use.write("them.txt", "default");
            set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }

        private void Click_2(object sender, RoutedEventArgs e)
        {
            use.write("them.txt", "dark");
            set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }

        private void Click_3(object sender, RoutedEventArgs e)
        {
            use.write("them.txt", "light");
            set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }

        private void Click_4(object sender, RoutedEventArgs e)
        {
            use.write("language.txt", "ru");
            set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }

        private void Click_5(object sender, RoutedEventArgs e)
        {
            use.write("language.txt", "eng");
            set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }
        void set_them_and_language(string them, string lang)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            if (them == "" || lang == "")
            {
                Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/ru-eng;component/eng.xaml") });
                use.write("language.txt", "eng");
                use.write("them.txt", "default");
                return;
            }
            List<string> title = new List<string>()
                            {
                                "Сбросить темы",
                                "Поставить темную тему",
                                "Поставить светлую тему",
                                "Поставить русский язык",
                                "Поставить английский язык",
                                "Set a deafault thems",
                                "Set the dark them",
                                "Set the light them",
                                "Set russian language",
                                "Set english language"
                            };
            if (lang == "eng")
                for (int i = title.Count / 2; i < title.Count; i++)
                    (cm.Items[i - 5] as MenuItem).Header = title[i];
            if (lang == "ru")
                for (int i = 0; i < title.Count / 2; i++)
                    (cm.Items[i] as MenuItem).Header = title[i];
            if (them == "dark")
                Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/dark_;component/lou.xaml") });
            if (them == "light")
                Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/dark_;component/full.xaml") });
            if (them != "default")
                Application.Current.Resources.MergedDictionaries.Insert(1, new ResourceDictionary { Source = new Uri($"pack://application:,,,/ru-eng;component/{lang}.xaml") });
            else
                Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri($"pack://application:,,,/ru-eng;component/{lang}.xaml") });
        }
    }
}
