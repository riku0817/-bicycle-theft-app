using System.Diagnostics;


namespace BicycleTheftApp;

public partial class secnum : ContentPage
{
    string count;
    public secnum()
	{
        InitializeComponent();
        hello.Text = Preferences.Get("count", "�܂��h�Ɠo�^�ԍ����o�^����Ă��܂���");
    }

    private async void OnClicked(object sender, EventArgs e)
    {
        // ���C���y�[�W�ֈړ�
        await Shell.Current.GoToAsync("//MenuPage");
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (name1.Text == "")
        {
            await DisplayAlert("�������͂���Ă��܂���", "\n" + "�ԍ�����͂��Ă�������", "OK");
        }
        else
        {



            bool ans = await DisplayAlert("�m�F", "�h�Ɠo�^�ԍ���\n" + "\n�y    " + name1.Text + "    �z" + "\n\n�ŊԈႢ����܂��񂩁H", "������", "�͂�");

            Debug.WriteLine($"{ans}");


            if (ans == false)
            {


                count = Preferences.Get("count", ""); // �������̓f�t�H���g�l
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
    //count = Preferences.Get("count", ""); // �������̓f�t�H���g�l
    // ADD END

    //count = name1.Text;



    //SemanticScreenReader.Announce(kaku.Text);

    // ADD START
    //Preferences.Default.Set("count", count);
    // ADD END

    //hello.Text = Preferences.Get("count", count);
}
//}
