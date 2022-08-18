using app.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json.Serialization;

namespace app.Domain.Market;

public partial class Item
	: ContentView
{


    public Item()
	{
		InitializeComponent();
	}

	private async void OnLoaded(object sender, EventArgs e)
	{
        var value = "var d = $($(\".c-instrument--last\")[0]).text()";
        var info = "var content = $(\"div.c-faceplate\")[0]";
        var chart = "var chart = $(\"div.c-quote-chart\")[0]";
        var resetBody = "$(\"body\")[0].innerHTML = ''";
        var setDetailBody = "$(\"body\")[0].appendChild(content)";
        var setChartBody = "$(\"body\")[0].appendChild(chart)";

        var setStyle = "$(\"body\")[0].setAttribute('style', 'width: 1500; padding: 0px !important')";

        // Init
        await webView.EvaluateJavaScriptAsync(value);
        await webView.EvaluateJavaScriptAsync(info);
        await webView.EvaluateJavaScriptAsync(chart);

        // Clear
        await webView.EvaluateJavaScriptAsync(resetBody);

        // Set
        await webView.EvaluateJavaScriptAsync(setDetailBody);
        await webView.EvaluateJavaScriptAsync(setChartBody);
        await webView.EvaluateJavaScriptAsync(setStyle);


        var result = await webView.EvaluateJavaScriptAsync("d");

        Console.WriteLine(result);
    }
}