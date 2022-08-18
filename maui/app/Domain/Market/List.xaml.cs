using app.ViewModel;

namespace app.Domain.Market;

public partial class List
    : ContentView
{

    public List()
    {
        InitializeComponent();
        BindingContext = new ListViewModel();
    }
}