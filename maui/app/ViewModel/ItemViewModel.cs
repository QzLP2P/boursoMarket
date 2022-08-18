using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModel
{
    public partial class ItemViewModel
        : ObservableObject
    {
        [ObservableProperty]
        Entities.Market market;

        public ItemViewModel()
        {

        }
    }
}
