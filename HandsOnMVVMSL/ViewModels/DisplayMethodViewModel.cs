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
    }
}
