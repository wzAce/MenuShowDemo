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

namespace MenuShow
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
            string XMLPath = ".\\MenuXML.xml";
            MenuList.ItemsSource = MenuOptions.GetStarted(XMLPath);
            MenuList.DisplayMemberPath = "Name";

        }

        private void MenuList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var MenuItem = MenuList.SelectedItem;
            
            if(MenuItem!=null)
            {
                var tmpList = MenuOptions.MenuSelected(MenuItem);
                if(tmpList!=null)
                {
                    MenuList.ItemsSource = tmpList;
                }
            }
            
        }

        private void Btn_UP_Click(object sender, RoutedEventArgs e)
        {
            var tmpList = MenuOptions.MenuUp();
            if (tmpList != null)
            {
                MenuList.ItemsSource = tmpList;
            }
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            MenuList.ItemsSource = MenuOptions.GoToRootMenu();
        }
    }
}
