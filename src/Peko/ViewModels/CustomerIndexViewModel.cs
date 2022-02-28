using Peko.Models.Identity.Data;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Peko.ViewModels
{
    public class CustomerIndexViewModel : RoutableViewModelBase
    {
        private readonly PekoDbContext _pekoDbContext;

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => this.RaiseAndSetIfChanged(ref _customers, value);
        }


        public override string UrlPathSegment => GetSegmentName(nameof(CustomerIndexViewModel));

        public ICommand ViewInitializedCommand { get; set; }

        public CustomerIndexViewModel(IScreen screen, PekoDbContext pekoDbContext) : base(screen)
        {
            _pekoDbContext = pekoDbContext;
            ViewInitializedCommand = ReactiveCommand.Create(OnViewInitializedCommand);
        }

        private void OnViewInitializedCommand()
        {
            Customers = new ObservableCollection<Customer>(_pekoDbContext.Customers);

            // TODO: Remove hardcoded entry, use fixtures on development db
            Customers.Add(new Customer
            {
                Id = 1,
                FirstName = "Lorem",
                SecondName = "Ipsum",
                LastName1 = "Quisque",
                LastName2 = "Suspendisse",
                Email = "pede@dictum.eu",
                Address = "Vivamus placerat lacus vel vehicula scelerisque, dui enim adipiscing lacus sit amet sagittis, libero enim vitae mi.",
                MobilePhone = "+1 651 5156651",
                DNI = "1 1111 11111",
                Phone = "+1 651 5156651"
            });
        }
    }
}
