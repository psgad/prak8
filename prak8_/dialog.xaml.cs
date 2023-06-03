﻿using doing;
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
            MainWindow.set_them_and_language(use.read("them.txt"), use.read("language.txt"));
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
            MainWindow.set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }

        private void Click_2(object sender, RoutedEventArgs e)
        {
            use.write("them.txt", "dark");
            MainWindow.set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }

        private void Click_3(object sender, RoutedEventArgs e)
        {
            use.write("them.txt", "light");
            MainWindow.set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }

        private void Click_4(object sender, RoutedEventArgs e)
        {
            use.write("language.txt", "ru");
            MainWindow.set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }

        private void Click_5(object sender, RoutedEventArgs e)
        {
            use.write("language.txt", "eng");
            MainWindow.set_them_and_language(use.read("them.txt"), use.read("language.txt"));
        }
    }
}
