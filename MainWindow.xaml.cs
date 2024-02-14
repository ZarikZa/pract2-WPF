using System;
using System.Collections.Generic;
using System.IO;
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

namespace paraAdaptivnayaverstka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logic Logic = new Logic();
        public MainWindow()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Directory.CreateDirectory(desktop + "\\practa2");
            DateTime date = DateTime.Now;
            InitializeComponent();
            Kalendar.Text = date.ToString();
        }
        private void Kalendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Obnovlenie();
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameTBox.Text != "")
            {
                string name = NameTBox.Text;
                string description = DescriptionTBox.Text;
                DateTime date = Convert.ToDateTime(Kalendar.Text);

                Logic.Create(name, description, date);
            }
            Obnovlenie();
        }
        private void SafeButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTBox.Text;
            string description = DescriptionTBox.Text;
            var selected = ListZametok.SelectedItems;
            Zapiska zap = (Zapiska)selected[0];
            string oldname = zap.Name;
            Logic.Update(name, description, oldname);
            Obnovlenie();
        }
        private void ListZametok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NameTBox.Text = null;
            DescriptionTBox.Text = null;
            var data = Convert.ToDateTime(Kalendar.Text);
            var zapis = Logic.Read(data);
            var select = ListZametok.SelectedItems;
            try
            {
                Zapiska zap = (Zapiska)select[0];
                foreach( var zametok in zapis)
                {
                    if (zametok.Name == zap.Name)
                    {
                        NameTBox.Text = zametok.Name;
                        DescriptionTBox.Text = zametok.Description;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var select = ListZametok.SelectedItem as Zapiska;
            Logic.Delete(select);
            NameTBox.Text = null;
            DescriptionTBox.Text = null;
            Obnovlenie();
        }
        private void Obnovlenie()
        {
            var data = Convert.ToDateTime(Kalendar.Text);
            var zapis = Logic.Read(data);
            ListZametok.ItemsSource = zapis;
            ListZametok.DisplayMemberPath = "Name";
            NameTBox.Text = null;
            DescriptionTBox.Text = null;
        }
    }
}
