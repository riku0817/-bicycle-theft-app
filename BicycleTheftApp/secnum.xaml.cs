using System.Diagnostics;


namespace BicycleTheftApp;

public partial class secnum : ContentPage
{
    string count;
    public secnum()
	{
        InitializeComponent();
        hello.Text = Preferences.Get("count", "まだ防犯登録番号が登録されていません");
    }

    private async void OnClicked(object sender, EventArgs e)
    {
        // メインページへ移動
        await Shell.Current.GoToAsync("//MenuPage");
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (name1.Text == "")
        {
            await DisplayAlert("何も入力されていません", "\n" + "番号を入力してください", "OK");
        }
        else
        {



            bool ans = await DisplayAlert("確認", "防犯登録番号は\n" + "\n【    " + name1.Text + "    】" + "\n\nで間違いありませんか？", "いいえ", "はい");

            Debug.WriteLine($"{ans}");


            if (ans == false)
            {


                count = Preferences.Get("count", ""); // 第二引数はデフォルト値
                                                      // ADD END

                count = name1.Text;



                SemanticScreenReader.Announce(kaku.Text);

                // ADD START
                Preferences.Default.Set("count", count);
                // ADD END

                hello.Text = Preferences.Get("count", count);
                name1.Text = "";
            }
        }
    }

    //private void OnCounterClicked(object sender, EventArgs e)
    //{

    // ADD START
    //count = Preferences.Get("count", ""); // 第二引数はデフォルト値
    // ADD END

    //count = name1.Text;



    //SemanticScreenReader.Announce(kaku.Text);

    // ADD START
    //Preferences.Default.Set("count", count);
    // ADD END

    //hello.Text = Preferences.Get("count", count);
}
//}
