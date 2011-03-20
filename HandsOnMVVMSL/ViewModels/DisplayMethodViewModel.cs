using HandsOnMVVMSL.Web;
using System.ComponentModel;

namespace HandsOnMVVMSL.ViewModels
{
    public class DisplayMethodViewModel : INotifyPropertyChanged
    {
        private readonly Person _person;
        private readonly DisplayMethod _displayAs;

        public DisplayMethodViewModel(Person person, DisplayMethod displayAs)
        {
            _person = person;
            _displayAs = displayAs;

            _person.PropertyChanged += new PropertyChangedEventHandler(PersonPropertyChanged);
        }

        private void PersonPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FirstName" || e.PropertyName == "LastName" || e.PropertyName == "Email")
                FirePropertyChanged("Display");
        }

        public DisplayMethod DisplayAs
        {
            get { return _displayAs; }
        }

        public string Display
        {
            get { return _person.DisplayUsingMethod(_displayAs); }
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            DisplayMethodViewModel that = obj as DisplayMethodViewModel;
            if (that == null)
                return false;
            return _displayAs == that._displayAs;
        }

        public override int GetHashCode()
        {
            return (int)_displayAs;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
