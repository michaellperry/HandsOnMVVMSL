using HandsOnMVVMSL.Web;
using System.ComponentModel;

namespace HandsOnMVVMSL.ViewModels
{
    public class PersonSummaryViewModel : INotifyPropertyChanged
    {
        private Person _person;

        public PersonSummaryViewModel(Person person)
        {
            _person = person;

            _person.PropertyChanged += PersonPropertyChanged;
        }

        private void PersonPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FirstName" || e.PropertyName == "LastName" || e.PropertyName == "Email" || e.PropertyName == "DisplayAs")
                FirePropertyChanged("Display");
        }

        public Person Person
        {
            get { return _person; }
        }

        public string Display
        {
            get { return _person.DisplayUsingMethod(_person.DisplayAs); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
