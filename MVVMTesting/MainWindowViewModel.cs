using System;
using MVVMTesting.Customers;
using MVVMTesting.OrderPrep;
using MVVMTesting.Orders;

namespace MVVMTesting
{
    public class MainWindowViewModel : BaseViewModel
    {
        private CustomerViewModel _customerViewModel = new CustomerViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private AddEditCustomerViewModel _addEditCustomerViewModel = new AddEditCustomerViewModel();

        private BaseViewModel _currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            _customerViewModel.PlaceOrderRequested += NavToOrder;
            _customerViewModel.AddCustomerRequested += NavToAddCustomer;
            _customerViewModel.EditCustomerRequested += NavToEditCustomer;
        }

        private void NavToEditCustomer(Customer customer)
        {
            _addEditCustomerViewModel.EditMode = false;
            _addEditCustomerViewModel.SetCustomer(customer);
            CurrentViewModel = _addEditCustomerViewModel;
        }

        private void NavToAddCustomer(Customer customer)
        {
            _addEditCustomerViewModel.EditMode = true;
            _addEditCustomerViewModel.SetCustomer(customer);
            CurrentViewModel = _addEditCustomerViewModel;
        }

        private void NavToOrder(int id)
        {
            _orderViewModel.CustomerId = id;
            CurrentViewModel = _orderViewModel;
        }

        public BaseViewModel CurrentViewModel 
        {
            get { return _currentViewModel; }
            set { Set(ref _currentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            CurrentViewModel = destination switch
            {
                "orderPrep" => _orderPrepViewModel,
                _ => _customerViewModel
            };
        }
    }
}
