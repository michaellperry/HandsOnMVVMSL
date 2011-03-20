using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using HandsOnMVVMSL.Models;
using HandsOnMVVMSL.Utilities;
using HandsOnMVVMSL.Web;

namespace HandsOnMVVMSL.ViewModels
{
    public class AddressBookViewModel : INotifyPropertyChanged
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

            _navigation.PropertyChanged += NavigationPropertyChanged;
        }

        private void NavigationPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedPerson")
            {
                FirePropertyChanged("SelectedSummary");
                FirePropertyChanged("PersonDetail");
            }
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
            set
            {
            	_navigation.SelectedPerson = value == null ? null : value.Person;
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
