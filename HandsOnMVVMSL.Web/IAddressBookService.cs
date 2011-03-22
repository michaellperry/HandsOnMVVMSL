using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace HandsOnMVVMSL.Web
{
    [DataContract]
    public enum DisplayMethod
    {
    	[EnumMember]
        FirstLast,

        [EnumMember]
        LastFirst,

        [EnumMember]
        Email
    }
    [DataContract]
    public class Person
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public DisplayMethod DisplayAs { get; set; }
    }
    [ServiceContract]
    public interface IAddressBookService
    {
        [OperationContract]
        List<Person> GetPeople();

        [OperationContract]
        Person GetPerson();
    }
}
