using System.Collections.Generic;
using HandsOnMVVMSL.Web;

namespace HandsOnMVVMSL.ViewModels
{
    public class PersonDetailViewModel
    {
        private Person _person;

        public PersonDetailViewModel(Person person)
        {
            _person = person;
        }

        public string FirstName
        {
            get { return _person.FirstName; }
            set { _person.FirstName = value; }
        }

        public string LastName
        {
            get { return _person.LastName; }
            set { _person.LastName = value; }
        }

        public string Email
        {
            get { return _person.Email; }
            set { _person.Email = value; }
        }

        public string Phone
        {
            get { return _person.Phone; }
            set { _person.Phone = value; }
        }

        public IEnumerable<DisplayMethodViewModel> DisplayAsOptions
        {
            get
            {
                yield return new DisplayMethodViewModel(_person, DisplayMethod.FirstLast);
                yield return new DisplayMethodViewModel(_person, DisplayMethod.LastFirst);
                yield return new DisplayMethodViewModel(_person, DisplayMethod.Email);
            }
        }
        public DisplayMethodViewModel DisplayAs
        {
            get { return new DisplayMethodViewModel(_person, _person.DisplayAs); }
            set
            {
                if (value != null)
                    _person.DisplayAs = value.DisplayAs;
            }
        }
    }
}
