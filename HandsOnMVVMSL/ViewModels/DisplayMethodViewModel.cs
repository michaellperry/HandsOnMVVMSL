using HandsOnMVVMSL.Web;

namespace HandsOnMVVMSL.ViewModels
{
    public class DisplayMethodViewModel
    {
        private readonly Person _person;
        private readonly DisplayMethod _displayAs;

        public DisplayMethodViewModel(Person person, DisplayMethod displayAs)
        {
            _person = person;
            _displayAs = displayAs;
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
    }
}
