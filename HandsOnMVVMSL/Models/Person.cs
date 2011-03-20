using System;

namespace HandsOnMVVMSL.Web
{
    public partial class Person
    {
        public string DisplayUsingMethod(DisplayMethod method)
        {
            if (method == DisplayMethod.LastFirst)
                return string.Format("{0}, {1}", LastName, FirstName);
            else if (method == DisplayMethod.FirstLast)
                return string.Format("{0} {1}", FirstName, LastName);
            else if (method == DisplayMethod.Email)
                return Email;
            else
                return string.Format("Unknown display method {0}", method);
        }
    }
}
