using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using ThreadNetwork;

namespace Wordle
{    public partial class MainPage : ContentPage
    {
        //variable for login name
        String nameLogin = "";
        public MainPage()
        {
            InitializeComponent();


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //identify a location in a directory
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words.txt");

            if (File.Exists(filePath) == false)
            {
                //download the file when the page appears
                await DownloadFileAsync("https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt");
            }

           
            
        }

        private async Task DownloadFileAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //save file as a string
                    string fileContent = await client.GetStringAsync(url);
                    //identify a location in a directory
                    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words.txt");
                    //create file with all words
                    File.WriteAllText(filePath, fileContent);
                }
            }
            catch (Exception) //check for exception
            {
                
                LoginBtn.IsEnabled = false;
                errorlbl.IsEnabled = true;
                errorlbl.Text = "Connection required for first time running. Try again!";

            }
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //check if the LoginBox has text
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                //enable LoginBtn if the LoginBox has text
                LoginBtn.IsEnabled = true;
            }
            else
            {
                //disable the LoginBtn if LoginBox has not text
                LoginBtn.IsEnabled = false;
            }
        }


        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            //change color of LoginBtn when it is clicked
            LoginBtn.BackgroundColor = Color.FromRgb(128, 128, 128);
            //return start color
            colorChange();
            //save value
            nameLogin = loginBox.Text;
            //move to next page
            movePage();

        }

        private async void colorChange()
        { 
            //wait some time
            await Task.Delay(100);
            //change color
            LoginBtn.BackgroundColor = Color.FromRgb(211, 211, 211);
        }

        private async void movePage()
        {
            //open 
            await Navigation.PushAsync(new Menu(nameLogin));
        }

    }
}

