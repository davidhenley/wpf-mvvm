using System;
using System.Collections.ObjectModel;

namespace MVVMTesting.Customers
{
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> _customers;

        public CustomerViewModel()
        {
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
            AddCustomerCommand = new RelayCommand(OnAddCustomer);

            LoadCustomers();
        }

        private void OnEditCustomer(Customer customer)
        {
            EditCustomerRequested(customer);
        }

        private void OnAddCustomer()
        {
            var id = Customers.Count + 1;

            var customer = new Customer() { Id = id };

            AddCustomerRequested(customer);
        }

        private void OnPlaceOrder(Customer customer)
        {
            PlaceOrderRequested(customer.Id);
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { Set(ref _customers, value); }
        }

        public void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>()
            {
                new Customer { Id = 1, FullName = "Test Customer 1" },
                new Customer { Id = 2, FullName = "Test Customer 2" },
            };
        }

        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand<Customer> EditCustomerCommand { get; private set; }

        public event Action<int> PlaceOrderRequested = delegate { };
        public event Action<Customer> AddCustomerRequested = delegate { };
        public event Action<Customer> EditCustomerRequested = delegate { };
    }
}
