using app.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace app.ViewModel
{
    public partial class ListViewModel
        : ObservableObject
    {
        public ListViewModel()
        {
            markets = new ObservableCollection<Market>();
            skipMarket = 0;
            LoadMauiAssetAsync();
        }

        [ObservableProperty]
        ObservableCollection<Market> markets;


        [ObservableProperty]
        int skipMarket;

        List<Entities.Market> AllMarkets;
        int range = 10;

        [ObservableProperty]
        int totalResult = 0;

        [ObservableProperty]
        string search;

        [RelayCommand]
        public void NextPage()
        {
            skipMarket = Math.Min(skipMarket + range, totalResult - range);
            markets.Clear();
            AllMarkets.Skip(SkipMarket).Take(10).ToList().ForEach((r) => markets.Add(r));
        }

        [RelayCommand]
        public void PreviousPage()
        {
            skipMarket = Math.Max(0, Math.Min(skipMarket + range, totalResult - range));
            markets.Clear();
            AllMarkets.Skip(SkipMarket).Take(10).ToList().ForEach((r) => markets.Add(r));
        }

        [RelayCommand]
        public void SearchMarket()
        {
            markets.Clear();
            SkipMarket = 0;
            AllMarkets.Where(m => m.LibelleSupport.ToLower().Contains(Search.ToLower())).Take(10).ToList().ForEach((m) => markets.Add(m));
        }

        [RelayCommand]
        public void ResetSearchMarket()
        {
            markets.Clear();
            Search = "";
            AllMarkets.Skip(SkipMarket).Take(10).ToList().ForEach((r) => markets.Add(r));
        }

        private async void LoadMauiAssetAsync()
        {
            try
            {
                var exist = await FileSystem.AppPackageFileExistsAsync("data.json");
                if (!exist)
                {
                    Console.Error.WriteLine("File doesn't exist");
                }

                using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
                var result = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Entities.Market>>(stream);
                totalResult = result.Count;
                result.Skip(SkipMarket).Take(10).ToList().ForEach((r) => markets.Add(r));
                AllMarkets = result;
                //result.ForEach((r) => markets.Add(r));


            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("ex :", ex);
            }

        }
    }


 



}
