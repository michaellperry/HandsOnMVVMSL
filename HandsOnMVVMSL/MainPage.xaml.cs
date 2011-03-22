using System.Windows;
using System.Windows.Controls;
using HandsOnMVVMSL.Models;
using HandsOnMVVMSL.ViewModels;

namespace HandsOnMVVMSL
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            AddressBook addressBook = new AddressBook();
            DataContext = addressBook;

            addressBook.GetPeople(Dispatcher);
        }
    }
}
