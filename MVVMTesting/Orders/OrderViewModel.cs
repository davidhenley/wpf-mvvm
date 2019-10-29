namespace MVVMTesting.Orders
{
    public class OrderViewModel : BaseViewModel
    {
        private int _customerId;

        public int CustomerId
        {
            get { return _customerId; }
            set { Set(ref _customerId, value); }
        }

    }
}
