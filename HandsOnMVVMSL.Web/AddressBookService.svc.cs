using System.Collections.Generic;
using System.Threading;

namespace HandsOnMVVMSL.Web
{
    public class AddressBookService : IAddressBookService
    {
        public List<Person> GetPeople()
        {
            Thread.Sleep(1000);
            return new List<Person>
            {
                new Person
                {
                    FirstName = "Mark",
                    LastName = "Benford",
                    Email = "mark.benford@fbi.gov",
                    Phone = "876 432-8765",
                    DisplayAs = DisplayMethod.LastFirst
                },
                new Person
                {
                    FirstName = "Demitri",
                    LastName = "Noh",
                    Email = "demitri.noh@fbi.gov",
                    Phone = "876 432-8765",
                    DisplayAs = DisplayMethod.LastFirst
                },
                new Person
                {
                    FirstName = "Janis",
                    LastName = "Hawk",
                    Email = "janis.hawk@fbi.gov",
                    Phone = "876 432-8765",
                    DisplayAs = DisplayMethod.LastFirst
                }
            };
        }


        public Person GetPerson()
        {
            Thread.Sleep(1000);
            return new Person
            {
                FirstName = "Mark",
                LastName = "Benford",
                Email = "mark.benford@fbi.gov",
                Phone = "876 432-8765",
                DisplayAs = DisplayMethod.LastFirst
            };
        }
    }
}
