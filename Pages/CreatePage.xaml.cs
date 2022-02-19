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
    public sealed partial class CreatePage : Page
    {
        public CreatePage()
        {
            this.InitializeComponent();
        }

        private async void Handle_Create(object sender, RoutedEventArgs e)
        {
            var contacts = new Contact()
            {
                Name = Name.Text,
                PhoneNumber = PhoneNumber.Text
            };

            var database = new DatabaseInitialize();
            var result = database.InsertData(contacts);
            var dialog = new ContentDialog();
            if (result)
            {
                dialog.Title = "Success";
                dialog.Content = "Insert data success !!";
                dialog.PrimaryButtonText = "Close";
                await dialog.ShowAsync();
            }
            else
            {
                dialog.Title = "Failed";
                dialog.Content = "Insert data failed !!";
                dialog.PrimaryButtonText = "Close";
                await dialog.ShowAsync();
            }
        }

        private void Redirect_List(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.ListPage));
        }
    }
}
