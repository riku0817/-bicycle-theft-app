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
        // �T�u�y�[�W�ֈړ�
        await Shell.Current.GoToAsync("//MainPage");
    }
}