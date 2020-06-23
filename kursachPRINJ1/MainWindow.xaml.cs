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
using Controls;
using System.Text.Json;
using System.IO;
using System.Threading;
using ClassLibrary1;
using System.Windows.Forms;

namespace kursachPRINJ1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List <Suchestvo> bestiariy;
        public MainWindow()
        {
            InitializeComponent();


            //string put1 = @"Image\1.png";
            //string put2 = @"Image\2.png";
            //string put3 = @"Image\Troll.png";

            //string p1 = "Виверна";
            //string p2 = "Вилохвост";
            //string p3 = "Троль";

            //string c1 = "Являются частью естественной экосистемы мира. Легко поддаются приручению у друидов. Территориальные животные. Они живут и охотятся в одиночку, хотя бывают периоды, когда они спариваются. Нападают на любого нарушителя их территорий, кроме тех, кто гораздо тяжелее их самих, те же драконы, например. Они питаются в основном мясом животных, которых легко хватать с воздуха, — вот почему они так любят питаться овцами.";
            //string c2 = "Вилохвост (ориг. Forktail) — ящер из семейства драконидов. " +
            //    "Название получил из - за вилообразного окончания хвоста.Существо в обычной среде обитания безвредное, питающееся исключительно рыбой и мелкими зверями. " +
            //    "Обычно не нападает на человека. Имеется одна интересная особенность: там, где поселилось это серо-зеленое, драконовидное существо, нет других монстров.";
            //string c3 = "Внешний вид и повадки этих чудовищ могут различаться в зависимости от вида. Общими являются следующие особенности: " +
            //    "тролли — крупные примитивные создания, обладающие огромной силой и крепкой кожей, однако они медлительны и туповаты. " +
            //    "Несмотря на существующие суеверия, тролли не боятся солнца и не превращаются в камень от его лучей, наоборот предпочитая день ночи. " +
            //    "Тролли разумны и способны говорить, однако сильно коверкают слова и говорят простейшими односложными или безличными предложениями. " +
            //    "Имеют привычку чесать затылок, когда думают. Способны на чувства и ценят доброту, проявленную к ним. Любят играть в загадки.";

            //ClassdRAKONID su1 = new ClassdRAKONID(p1, put1, c1);
            //ClassdRAKONID su2 = new ClassdRAKONID(p2, put2, c2);
            //ClassOgr su3 = new ClassOgr(p3, put3, c3);
            //List<Suchestvo> suchestvos = new List<Suchestvo>();
            //suchestvos.Add(su1);
            //suchestvos.Add(su2);
            //suchestvos.Add(su3);

            //var bitI = new BitmapImage();
            //bitI.BeginInit();
            //bitI.UriSource = new Uri(put);
            //bitI.CacheOption = BitmapCacheOption.OnLoad;
            //bitI.EndInit();
            //Image im = new Image();
            //im.Source = bitI;
            //string p = "Пизда";
            //Priv.Items.Add(im);

            //for (int i = 0; i < 15; i++)
            //{
            //    UserControl1 user = new UserControl1(put, p);
            //    list1.Items.Add(user);
            //}
            //UserControl1 user = new UserControl1(put, p);
            //Priv.Items.Add(user);
            //list1.Items.Add(user);
            //list1.Items.Add(user);
            //UserControl1 user = new UserControl1(put, p);
            //list1.Items.Add(user);


            //Dispatcher.Invoke(()

            //JsonManager.Serialize(suchestvos);

            bestiariy = JsonManager.Deserialize();

            for (int i = 0; i < bestiariy.Count; i++)
            {
                UserControl1 user = new UserControl1(bestiariy[i].PictSush, bestiariy[i].NameSush);
                list1.Items.Add(user);
            }
        }
        private void list1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list1.SelectedIndex != -1)
            {
                int id = list1.SelectedIndex;
                var bitI = new BitmapImage();
                bitI.BeginInit();
                bitI.UriSource = new Uri(bestiariy[id].PictSush, UriKind.Relative);
                bitI.CacheOption = BitmapCacheOption.OnLoad;
                bitI.EndInit();
                Im.Source = bitI;
                name12.Text = bestiariy[id].NameSush;
                info1.Text = bestiariy[id].InfoSuch;
                klasssushestva.Text = bestiariy[id].getKlass();
                if (bestiariy[id].DopFightMet != "")  FightMet.Text = bestiariy[id].fighting_methods() + " (Дополнительно: " + bestiariy[id].DopFightMet + ").";
                else FightMet.Text = bestiariy[id].fighting_methods();
                immun.Text = bestiariy[id].immunity();
                List<string> fr = bestiariy[id].getfriend();
                List<string> en = bestiariy[id].getenemy();
                friend.Items.Clear();
                enemy.Items.Clear();
                if (fr.Count != 0)
                {
                    for (int i = 0; i < fr.Count; i++)
                    {
                        friend.Items.Add(fr[i]);
                    }
                }
                if (en.Count != 0)
                {
                    for (int i = 0; i < en.Count; i++)
                    {
                        enemy.Items.Add(en[i]);
                    }
                }
                //Console.WriteLine(bestiariy[id].DopFightMet);
            }
        }
        private void addzap_Click(object sender, RoutedEventArgs e)
        {
            ADD a = new ADD(bestiariy);
            a.ShowDialog();
            //list1.SelectedIndex = -1;
            list1.Items.Clear();
            bestiariy = JsonManager.Deserialize();
            for (int i = 0; i < bestiariy.Count; i++)
            {
                UserControl1 user = new UserControl1(bestiariy[i].PictSush, bestiariy[i].NameSush);
                list1.Items.Add(user);
            }
        }

        private void dellzap_Click(object sender, RoutedEventArgs e)
        {
            if (list1.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Запись не выбрана", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("Вы точно хотите удалить запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int id_ = list1.SelectedIndex;
                    list1.Items.RemoveAt(id_);
                    File.Delete(bestiariy[id_].PictSush);
                    bestiariy.RemoveAt(id_);
                    Im.Source = null;
                    name12.Clear();
                    info1.Clear();
                    klasssushestva.Clear();
                    FightMet.Clear();
                    immun.Clear();
                    JsonManager.Serialize(bestiariy);
                }  
            }
        }
    }
}
    
