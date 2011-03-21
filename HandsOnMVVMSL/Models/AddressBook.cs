using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using HandsOnMVVMSL.Web;

namespace HandsOnMVVMSL.Models
{
    public class AddressBook
    {
        private ObservableCollection<Person> _people = new ObservableCollection<Person>();

        public ObservableCollection<Person> People
        {
            get { return _people; }
        }

        public Person NewPerson()
        {
            Person person = new Person();
            _people.Add(person);
            return person;
        }

        public void DeletePerson(Person person)
        {
            _people.Remove(person);
        }

        public void GetPeople(Dispatcher dispatcher)
        {
            IAddressBookService service = new AddressBookServiceClient();
            service.BeginGetPeople(delegate(IAsyncResult result)
            {
                ObservableCollection<Person> people = service.EndGetPeople(result);
                dispatcher.BeginInvoke(delegate
                {
                    _people.Clear();
                    foreach (Person person in people)
                    {
                        _people.Add(person);
                    }
                });
            }, null);
        }
    }
}
