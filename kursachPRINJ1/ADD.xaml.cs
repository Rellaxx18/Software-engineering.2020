using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using ClassLibrary1;
using System.Linq;

namespace kursachPRINJ1
{
    /// <summary>
    /// Логика взаимодействия для ADD.xaml
    /// </summary>
    public partial class ADD : Window
    {
        List <string> link1 = new List<string>();
        List <string> link2 = new List<string>();
        public string filesourse = "";
        public string filename = "";
        public List<Suchestvo> MainList;
        public ADD(List <Suchestvo> ML)
        {
            InitializeComponent();
            MainList = ML;
            nazv.Visibility = System.Windows.Visibility.Hidden;
            klass12.Visibility = System.Windows.Visibility.Hidden;
            metborb.Visibility = System.Windows.Visibility.Hidden;
            nazv_Copy.Visibility = System.Windows.Visibility.Hidden;
            imuntext.Visibility = System.Windows.Visibility.Hidden;
            imun.Visibility = System.Windows.Visibility.Hidden;
            for (int i = 0; i < ML.Count; i++)
            {
                linkFriend.Items.Add(ML[i].NameSush);
            }
            for (int i = 0; i < ML.Count; i++)
            {
                linkEnemy.Items.Add(ML[i].NameSush);
            }
        }

        private void Image_Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true) {
                filesourse = openFileDialog.FileName;
                filename = System.IO.Path.GetFileName(filesourse);
            }
            var bitI = new BitmapImage();
            bitI.BeginInit();
            bitI.UriSource = new Uri(filesourse, UriKind.Relative);
            bitI.CacheOption = BitmapCacheOption.OnLoad;
            bitI.EndInit();
            foto.Source = bitI;
        }

        private void addzap_Click(object sender, RoutedEventArgs e)
        {
            if ((foto.Source == null) || (NameSush.Text == "") || (klass1.SelectedIndex == -1) || (info.Text == ""))
            {
                MessageBox.Show("Не все данные введены", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            { 
                if (klass1.SelectedIndex == 0)
                {
                    string targetPath = @"Image";
                    string destFile = System.IO.Path.Combine(targetPath, filename);
                    System.IO.Directory.CreateDirectory(targetPath);
                    System.IO.File.Copy(filesourse, destFile, true);
                    string FILESOURSE = @"Image\" + filename;
                    ClassdRAKONID DR = new ClassdRAKONID(NameSush.Text, FILESOURSE, info.Text);
                    if (dopmetb.Text != "") DR.DopFightMet = dopmetb.Text;
                    DR.addlinkfriend(link1);
                    DR.addlinkenemy(link2);
                    MainList.Add(DR);
                }
                if (klass1.SelectedIndex == 1)
                {
                    string targetPath = @"Image";
                    string destFile = System.IO.Path.Combine(targetPath, filename);
                    System.IO.Directory.CreateDirectory(targetPath);
                    System.IO.File.Copy(filesourse, destFile, true);
                    string FILESOURSE = @"Image\" + filename;
                    ClassGibrid G = new ClassGibrid(NameSush.Text, FILESOURSE, info.Text);
                    if (dopmetb.Text != "") G.DopFightMet = dopmetb.Text;
                    G.addlinkfriend(link1);
                    G.addlinkenemy(link2);
                    MainList.Add(G);
                }
                if (klass1.SelectedIndex == 2)
                {
                    string targetPath = @"Image";
                    string destFile = System.IO.Path.Combine(targetPath, filename);
                    System.IO.Directory.CreateDirectory(targetPath);
                    System.IO.File.Copy(filesourse, destFile, true);
                    string FILESOURSE = @"Image\" + filename;
                    ClassOgr ogr = new ClassOgr(NameSush.Text, FILESOURSE, info.Text);
                    if (dopmetb.Text != "") ogr.DopFightMet = dopmetb.Text;
                    ogr.addlinkfriend(link1);
                    ogr.addlinkenemy(link2);
                    MainList.Add(ogr);
                }
                if (klass1.SelectedIndex == 3)
                {
                    if ((metborb.Text == "") || (imun.Text == ""))
                    {
                        MessageBox.Show("Не все данные введены", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        string targetPath = @"Image";
                        string destFile = System.IO.Path.Combine(targetPath, filename);
                        System.IO.Directory.CreateDirectory(targetPath);
                        System.IO.File.Copy(filesourse, destFile, true);
                        string FILESOURSE = @"Image\" + filename;
                        ClassNEW New = new ClassNEW(NameSush.Text, FILESOURSE, info.Text);
                        New.setklass(klass12.Text);
                        New.Fighting_metods = metborb.Text;
                        New.immunity1 = imun.Text;
                        if (dopmetb.Text != "") New.DopFightMet = dopmetb.Text;
                        New.addlinkfriend(link1);
                        New.addlinkenemy(link2);
                        MainList.Add(New);
                    }
                }
                JsonManager.Serialize(MainList);
            }
        }

        private void klass1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (klass1.SelectedIndex == 3)
            {
                nazv.Visibility = System.Windows.Visibility.Visible;
                klass12.Visibility = System.Windows.Visibility.Visible;
                metborb.Visibility = System.Windows.Visibility.Visible;
                nazv_Copy.Visibility = System.Windows.Visibility.Visible;
                imuntext.Visibility = System.Windows.Visibility.Visible;
                imun.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                nazv.Visibility = System.Windows.Visibility.Hidden;
                klass12.Visibility = System.Windows.Visibility.Hidden;
                metborb.Visibility = System.Windows.Visibility.Hidden;
                nazv_Copy.Visibility = System.Windows.Visibility.Hidden;
                imuntext.Visibility = System.Windows.Visibility.Hidden;
                imun.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void linkFriend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (linkFriend.SelectedIndex != -1)
            {
                int id = linkFriend.SelectedIndex;
                string ind = linkFriend.SelectedItem.ToString();
                link1.Add(ind);
                linkFriend.Items.Remove(ind);
                linkEnemy.Items.Remove(ind);
            }
        }

        private void linkEnemy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (linkEnemy.SelectedIndex != -1)
            {
                int id = linkEnemy.SelectedIndex;
                string ind = linkEnemy.SelectedItem.ToString();
                link2.Add(ind);
                linkEnemy.Items.Remove(ind);
                linkFriend.Items.Remove(ind);
            }
        }
    }
}
  