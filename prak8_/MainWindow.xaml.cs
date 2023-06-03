using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using function;
using doing;

namespace prak8_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int count = 0;
        public static string text = "";
        private static List<User> us = new List<User>();
        private static List<User> uses = new List<User>();
        public static List<string> naz = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            language(use.read("language.txt"));
            us = Jsonka.Des<List<User>>("us.json") ?? new List<User>();
            count = Jsonka.Read();
            Use.naz = Jsonka.Des<List<string>>("naz.json") ?? new List<string>();
            if (Use.naz.Count > 0)
                cb2.ItemsSource = Use.naz;
            cena.Content = count.ToString();
            if (us.Count != 0)
            {
                Vib((DateTime)datka.SelectedDate);
                dg.ItemsSource = uses;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(tb3.Text) > 0)
                {
                    us.Add(new User(datka.SelectedDate, tb1.Text.ToString(), cb2.SelectedItem.ToString(), Convert.ToInt32(tb3.Text), true));
                    uses.Add(new User(datka.SelectedDate, tb1.Text.ToString(), cb2.SelectedItem.ToString(), Convert.ToInt32(tb3.Text), true));
                }
                else
                {
                    us.Add(new User(datka.SelectedDate, tb1.Text.ToString(), cb2.SelectedItem.ToString(), Convert.ToInt32(tb3.Text), false));
                    uses.Add(new User(datka.SelectedDate, tb1.Text.ToString(), cb2.SelectedItem.ToString(), Convert.ToInt32(tb3.Text), false));
                }
                count += Convert.ToInt32(tb3.Text);
                dg.ItemsSource = null;
                dg.ItemsSource = uses;
                cena.Content = count.ToString();
                Jsonka.Ser("us.json", us);
                Jsonka.Write(count);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка ввода");
            }
        }

        void Vib(DateTime time)
        {
            uses.Clear();
            foreach (User user in us)
            {
                if (time == user.data)
                    uses.Add(user);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new dialog().Show();
            Close();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((dg.SelectedItem) != null)
            {
                tb1.Text = ((User)dg.SelectedItem).Name.ToString();
                cb2.SelectedItem = ((User)dg.SelectedItem).Type;
                tb3.Text = ((User)dg.SelectedItem).money.ToString();
            }
        }

        private void datka_CalendarClosed(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = null;
            tb1.Text = null;
            cb2.SelectedIndex = -1;
            tb3.Text = null;
            Vib((DateTime)datka.SelectedDate);
            dg.ItemsSource = uses;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            count -= Convert.ToInt32(((User)dg.SelectedItem).money);
            uses.Remove((User)dg.SelectedItem);
            us.Remove((User)dg.SelectedItem);
            Jsonka.Ser("us.json", us);
            Jsonka.Write(count);
            dg.ItemsSource = null;
            dg.ItemsSource = uses;
            cena.Content = count.ToString();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int j = 0;
            foreach (User s in us)
            {
                if (s == dg.SelectedItem)
                {
                    j = Convert.ToInt32(((User)dg.SelectedItem).money);
                    foreach (User w in uses)
                    {
                        if (w == s)
                        {
                            w.Name = tb1.Text.ToString();
                            w.Type = cb2.SelectedItem.ToString();
                            w.money = Convert.ToInt32(tb3.Text);
                            break;
                        }
                    }
                    s.Name = tb1.Text.ToString();
                    s.Type = cb2.SelectedItem.ToString();
                    s.money = Convert.ToInt32(tb3.Text);
                    break;
                }
            }
            count += -(j - Convert.ToInt32(tb3.Text));
            Jsonka.Ser("us.json", us);
            Jsonka.Write(count);
            dg.ItemsSource = null;
            dg.ItemsSource = uses;
            cena.Content = count.ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            use.write("them.txt", "default");
            set(use.read("them.txt"));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            use.write("them.txt", "light");
            set(use.read("them.txt"));
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            use.write("them.txt", "dark");
            set(use.read("them.txt"));
        }
        void set(string a)
        {
            MessageBox.Show(Application.Current.Resources.MergedDictionaries[0].Source.ToString());
            if (a == "")
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                use.write("them.txt", "default");
                return;
            }/*
            MessageBox.Show(Application.Current.Resources.MergedDictionaries[1].Source.ToString());*/
            switch (a)
            {
                case "default":
                    Application.Current.Resources.MergedDictionaries.Clear();
                    Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/ru-eng;component/ru.xaml") });
                    break;
                case "dark":
                    Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/dark_;component/lou.xaml") });
                    break;
                case "light":
                    Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/dark_;component/full.xaml") });
                    break;
            }
        }
        void language(string a)
        {
            if (a == "")
            {
                Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/ru-eng;component/eng.xaml") });
                use.write("language.txt", "eng");
                return;
            }
            switch (a)
            {
                case "ru":
                    Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/ru-eng;component/ru.xaml") });
                    List<string> title = new List<string>()
                            {
                                "Сбросить темы",
                                "Поставить темную тему",
                                "Поставить светлую тему",
                                "Поставить русский язык",
                                "Поставить английский язык"
                            };
                    for (int i = 0; i < cm.Items.Count; i++)
                    {
                        (cm.Items[i] as MenuItem).Header = title[i];
                    }
                    break;
                case "eng":
                    Application.Current.Resources.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri("pack://application:,,,/ru-eng;component/eng.xaml") });
                    List<string> titles = new List<string>()
                            {
                                "Set a deafault thems",
                                "Set the dark them",
                                "Set the light them",
                                "Set russian language",
                                "Set english language"
                            };
                    for (int i = 0; i < cm.Items.Count; i++)
                    {
                        (cm.Items[i] as MenuItem).Header = titles[i];
                    }
                    break;
            }
        }

        private void Set_language_ru(object sender, RoutedEventArgs e)
        {
            use.write("language.txt", "ru");
            language(use.read("language.txt"));
        }

        private void Set_language_eng(object sender, RoutedEventArgs e)
        {
            use.write("language.txt", "eng");
            language(use.read("language.txt"));
        }
    }
    class User
    {
        public string Name { get; set; }
        public string Type { get; set; }
        private int Money;
        public int money
        {
            get { return Money; }
            set
            {
                Money = Math.Abs(value);
            }
        }
        public bool isincome { get; set; }
        public DateTime? data;

        public User(DateTime? selectedDate, string text1, string v, int text2, bool isin)
        {
            data = selectedDate;
            Name = text1;
            Type = v;
            money = text2;
            isincome = isin;
        }
    }
    class Use
    {
        public static List<string> naz = new List<string>();
    }
}

