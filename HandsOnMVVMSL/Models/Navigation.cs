using HandsOnMVVMSL.Web;

namespace HandsOnMVVMSL.Models
{
    public class Navigation
    {
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; }
        }
    }
}
