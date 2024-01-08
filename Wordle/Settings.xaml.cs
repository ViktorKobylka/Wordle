namespace Wordle;

public partial class Settings : ContentPage
{
    //variable for name login
    private string copyNameLogin;
    public Settings(string nameLogin)
	{
		InitializeComponent();
        copyNameLogin = nameLogin; //copy value

        //check after return from Menu
        if (controlTheme.changeColor == "change")
        {
            SettingsGrid.BackgroundColor = Color.FromRgb(64, 64, 64);
            controlTheme.themeName = "Dark theme";
            ThemeBtn.Text = controlTheme.themeName;
            Settingslbl.BackgroundColor = Color.FromRgb(64, 64, 64);
            Settingslbl.TextColor = Color.FromRgb(255, 255, 255);

        }
        else
        {
            //set new value
            SettingsGrid.BackgroundColor = Color.FromRgb(255, 255, 255);
            controlTheme.themeName = "Light theme";
            ThemeBtn.Text = controlTheme.themeName;
            Settingslbl.BackgroundColor = Color.FromRgb(255, 255, 255);
            Settingslbl.TextColor = Color.FromRgb(0, 0, 0);
            controlTheme.count = 1;
        }
    }


    private void ThemeBtn_Clicked(object sender, EventArgs e)
    {
        //change color of LoginBtn when it is clicked
        ThemeBtn.BackgroundColor = Color.FromRgb(128, 128, 128);
        //return start color
        colorChangeTheme();
        //send the appropriate message

        if (controlTheme.count == 1)
        {

            //set value
            controlTheme.changeColor = "change";
            controlTheme.count = 0;
        }
        else {
            controlTheme.changeColor = "Notchange";
        }

        if (controlTheme.changeColor == "change")
        {
            SettingsGrid.BackgroundColor = Color.FromRgb(64, 64, 64);
            controlTheme.themeName = "Dark theme";
            ThemeBtn.Text = controlTheme.themeName;
            Settingslbl.BackgroundColor = Color.FromRgb(64, 64, 64);
            Settingslbl.TextColor = Color.FromRgb(255, 255, 255);
        }
        else
        {
            //set new value
            SettingsGrid.BackgroundColor = Color.FromRgb(255, 255, 255);
            controlTheme.count = 1;
            controlTheme.themeName = "Light theme";
            ThemeBtn.Text = controlTheme.themeName;
            Settingslbl.BackgroundColor = Color.FromRgb(255, 255, 255);
            Settingslbl.TextColor = Color.FromRgb(0, 0, 0);
        }



    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        //change color of LoginBtn when it is clicked
        BackBtn.BackgroundColor = Color.FromRgb(128, 128, 128);
        //return start color
        colorChangeBack();
        //move to next page
        moveMenuPage();

    }

    private async void colorChangeTheme()
    {
        //wait some time
        await Task.Delay(100);
        //change color
        ThemeBtn.BackgroundColor = Color.FromRgb(211, 211, 211);
       
    }

    private async void colorChangeBack()
    {
        //wait some time
        await Task.Delay(100);
        //change color
        BackBtn.BackgroundColor = Color.FromRgb(211, 211, 211);
    }

    private async void moveMenuPage()
    {
        //open 
        await Navigation.PushAsync(new Menu(copyNameLogin));
    }


}