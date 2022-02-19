using BaiThi.Database;
using BaiThi.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BaiThi.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        private DatabaseInitialize database = new DatabaseInitialize();
        public ListPage()
        {
            this.InitializeComponent();
            this.Loaded += ListPage_Loaded;
        }

        private void ListPage_Loaded(object sender, RoutedEventArgs e)
        {
            ListData.ItemsSource = database.ListData();
        }

        private void Handle_Create(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.CreatePage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Contact> listContactByName = database.FindByName(searchName.Text);
            ListData.ItemsSource = listContactByName;
        }
    }
}
