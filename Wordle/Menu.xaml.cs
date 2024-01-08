namespace Wordle;

public partial class Menu : ContentPage
{
    //variable for name login
    private string copyNameLogin;
   
	public Menu(string nameLogin)
	{
		InitializeComponent();
        copyNameLogin = nameLogin; // save value
        userName.Text = "Welcome, " + nameLogin;

        //check dark theme
        if (controlTheme.changeColor == "change")
        {
            MenuGrid.BackgroundColor = Color.FromRgb(64, 64, 64);
            userName.BackgroundColor = Color.FromRgb(64, 64, 64);
            userName.TextColor = Color.FromRgb(255, 255, 255);
        }
        else
        {
            //set new value
            MenuGrid.BackgroundColor = Color.FromRgb(255, 255, 255);
            userName.BackgroundColor = Color.FromRgb(255, 255, 255);
            userName.TextColor = Color.FromRgb(0, 0, 0);
        }
    }


    private void PlayBtn_Clicked(object sender, EventArgs e)
    {
        //change color of LoginBtn when it is clicked
        PlayBtn.BackgroundColor = Color.FromRgb(128, 128, 128);
        //return start color
        colorChangePlay();
        //move to next page
        movePlayPage();

    }

    private void SettingsBtn_Clicked(object sender, EventArgs e)
    {
        //change color of LoginBtn when it is clicked
        SettingsBtn.BackgroundColor = Color.FromRgb(128, 128, 128);
        //return start color
        colorChangeSettings();
        //
        //move to next page
        moveSettingsPage();

    }


    private void ExitBtn_Clicked(object sender, EventArgs e)
    {
        //change color of LoginBtn when it is clicked
        ExitBtn.BackgroundColor = Color.FromRgb(128, 128, 128);
        //return start color
        colorChangeExit();

        //exit
        Environment.Exit(0);


    }

    private async void colorChangePlay()
    {
        //wait some time
        await Task.Delay(100);
        //change color
        PlayBtn.BackgroundColor = Color.FromRgb(211, 211, 211);
    }


    private async void colorChangeSettings()
    {
        //wait some time
        await Task.Delay(100);
        //change color
        SettingsBtn.BackgroundColor = Color.FromRgb(211, 211, 211);
    }

    private async void colorChangeExit()
    {
        //wait some time
        await Task.Delay(100);
        //change color
        ExitBtn.BackgroundColor = Color.FromRgb(211, 211, 211);
    }

    private async void movePlayPage()
    {
        //open 
        await Navigation.PushAsync(new Wordle(copyNameLogin));
    }


    private async void moveSettingsPage()
    {
        //open 
        await Navigation.PushAsync(new Settings(copyNameLogin));
    }
}