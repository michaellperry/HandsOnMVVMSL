using System.Collections.ObjectModel;
using System.Linq;
using HandsOnMVVMSL.Models;
using HandsOnMVVMSL.Utilities;
using HandsOnMVVMSL.Web;

namespace HandsOnMVVMSL.ViewModels
{
    public class AddressBookViewModel
    {
        private readonly AddressBook _addressBook;
        private readonly Navigation _navigation;

        private MappedObservableCollection<Person, PersonSummaryViewModel> _summaries;
        
        public AddressBookViewModel(AddressBook addressBook, Navigation navigation)
        {
            _addressBook = addressBook;
            _navigation = navigation;

            _summaries = new MappedObservableCollection<Person, PersonSummaryViewModel>(
                person => new PersonSummaryViewModel(person),
                _addressBook.People);
        }

        public ObservableCollection<PersonSummaryViewModel> Summaries
        {
            get { return _summaries.TargetCollection; }
        }

        public PersonSummaryViewModel SelectedSummary
        {
            get
            {
                return _summaries.TargetCollection
                    .FirstOrDefault(summary => summary.Person == _navigation.SelectedPerson);
            }
        }

        public PersonDetailViewModel PersonDetail
        {
            get
            {
                return _navigation.SelectedPerson == null ? null :
                    new PersonDetailViewModel(_navigation.SelectedPerson);
            }
        }
    }
}
