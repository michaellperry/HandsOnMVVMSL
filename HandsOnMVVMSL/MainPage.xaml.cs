using System.Windows;
using System.Windows.Controls;
using HandsOnMVVMSL.Web;
using System;

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
            IAddressBookService service = new AddressBookServiceClient();
            service.BeginGetPerson(delegate(IAsyncResult result)
            {
                Person person = service.EndGetPerson(result);
                Dispatcher.BeginInvoke(delegate
                {
                    DataContext = person;
                });
            }, null);
        }
    }
}
