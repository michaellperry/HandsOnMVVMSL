using HandsOnMVVMSL.Web;

namespace HandsOnMVVMSL.ViewModels
{
    public class PersonSummaryViewModel
    {
        private Person _person;

        public PersonSummaryViewModel(Person person)
        {
            _person = person;
        }

        public Person Person
        {
            get { return _person; }
        }

        public string Display
        {
            get { return _person.DisplayUsingMethod(_person.DisplayAs); }
        }
    }
}
