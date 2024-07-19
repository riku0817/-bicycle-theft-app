using System.Text;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace BicycleTheftApp;



public partial class MenuPage : ContentPage
{

    public MenuPage()
    {
        InitializeComponent();
    }

    private async void OnClicked(object sender, EventArgs e)
    {
        // サブページへ移動
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void num_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//secnum");
    }

    private async void ImageButton_Pressed(object sender, EventArgs e)
    {
        bunpuzu.Scale -= 0.1;
        await Task.Delay(120);
        bunpuzu.Scale += 0.1;
    }

    private async void secu_Pressed(object sender, EventArgs e)
    {
        secu.Scale -= 0.1;
        await Task.Delay(120);
        secu.Scale += 0.1;
    }
}