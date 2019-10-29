using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMTesting.Customers
{
    public class AddEditCustomerViewModel : BaseViewModel
    {
        private bool _editMode;
        private Customer _customer;

        public bool EditMode
        {
            get { return _editMode; }
            set { Set(ref _editMode, value); }
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
        }
    }
}
