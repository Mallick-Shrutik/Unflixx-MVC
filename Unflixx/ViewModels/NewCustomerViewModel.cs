using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unflixx.Models;

namespace Unflixx.ViewModels
{
    public class NewCustomerViewModel
    {
        //We can use List<MembershipType> and IEnumerable<MembershipType>
        //difference is 'List' class gives options to add remove objects and other
        //IEnumerable is used to iterate the list of data and if in future we change the data list we dont have to update this ViewModel Class
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}