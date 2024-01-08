using System.IO;
using System.Text.Json;
namespace Wordle;

public partial class Wordle : ContentPage
{
    //variables
    private string copyNameLogin;
    private string randomWord;
    private List<List<Label>> labels;
    private int currentRow;
    private int currentColumn;
    private string wordPlayer;




    public Wordle(string nameLogin)
	{

        InitializeComponent();

        //check dark theme
        if (controlTheme.changeColor == "change")
        {
            WordleGrid.BackgroundColor = Color.FromRgb(64, 64, 64);

        }
        else
        {
            //set new value
            WordleGrid.BackgroundColor = Color.FromRgb(255, 255, 255);

        }

        //identify a location in a directory
        string filePathS = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "save.json");

        //check if file exists
        if (File.Exists(filePathS))
        {
            LoadGame(); //load saved game
        }
        else
        {
            copyNameLogin = nameLogin;
            

            //identify a location in a directory
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words.txt");

            //store random word
            randomWord = GetRandomWord(filePath);
            GetLabels();
        }
    }

    private void LoadGame()
    {
        //declare labels
        GetLabels();

        //identify a location in a directory
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "save.json");

        //check if file exists
        if (File.Exists(filePath))
        {
            //get values from the file
            string json = File.ReadAllText(filePath);
            var saveData = System.Text.Json.JsonSerializer.Deserialize<SaveData>(json);

            copyNameLogin = saveData.CopyNameLogin;
            randomWord = saveData.RandomWord;
            currentRow = saveData.CurrentRow;
            currentColumn = saveData.CurrentColumn;
            wordPlayer = saveData.WordPlayer;


            labels[0][0].BackgroundColor = Color.FromRgb(211, 211, 211);

            for (int row = 0; row < labels.Count; row++)
            {
                labels[currentRow][currentColumn].BackgroundColor = Color.FromRgb(211, 211, 211);
 
                for (int col = 0; col < labels[row].Count; col++)
                {
                    
                    if (saveData.LabelsText[row][col] != null)
                    {
                        labels[row][col].Text = saveData.LabelsText[row][col]; //upload values

                    }
                    else
                        break; //exit from the loop
                    
                    
                }
                
            }

           
        }
    }

    private string GetRandomWord(string filePath)
    {
        //get all words from file
        string[] words = File.ReadAllLines(filePath);

        //make a random index
        Random random = new Random();
        int randomIndex = random.Next(0, words.Length);

        //get a random word from the list
        string randomWord = words[randomIndex];

        return randomWord;

    }

    private void GetLabels()
    {
        //initialize the list of labels
        labels = new List<List<Label>>
            {
                new List<Label> { First1, Second1, Third1, Fourth1, Fifth1 },
                new List<Label> { First2, Second2, Third2, Fourth2, Fifth2 },
                new List<Label> { First3, Second3, Third3, Fourth3, Fifth3 },
                new List<Label> { First4, Second4, Third4, Fourth4, Fifth4 },
                new List<Label> { First5, Second5, Third5, Fourth5, Fifth5 },
                new List<Label> { First6, Second6, Third6, Fourth6, Fifth6 },
            };
        //set values
        currentRow = 0;
        currentColumn = 0;
    }

    private void UpdateValue(string value)
    {
        int maxColummnValue = 4;
        int oldColumn = currentColumn;
        //check if the current label has a value
        if (string.IsNullOrEmpty(labels[currentRow][currentColumn].Text))
        {
            //update current label 
            labels[currentRow][currentColumn].Text = value;
            wordPlayer += value;
            

            if (currentColumn != maxColummnValue)
            {
                // move to the next column
                if (currentColumn < labels[currentRow].Count - 1)
                {
                    labels[currentRow][currentColumn].BackgroundColor = Color.FromRgb(211, 211, 211);
                    currentColumn++;
                    labels[currentRow][currentColumn].BackgroundColor = Color.FromRgb(128, 128, 128);
                }

            }
        }
    }



    private void BackMenuBtn_Clicked(object sender, EventArgs e)
    {
        SaveGame();

        //change color of LoginBtn when it is clicked
        BackMenuBtn.BackgroundColor = Color.FromRgb(128, 128, 128);
        //return start color
        colorChangeBack();
        //move to next page
        moveMenuPage();

    }
    private async void colorChangeBack()
    {
        //wait some time
        await Task.Delay(100);
        //change color
        BackMenuBtn.BackgroundColor = Color.FromRgb(211, 211, 211);
    }

    private async void moveMenuPage()
    {
        //open 
        await Navigation.PushAsync(new Menu(copyNameLogin));
    }

    private void Q_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("q");
    }

    private void W_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("w");
    }

    private void E_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("e");
    }

    private void R_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("r");
    }

    private void T_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("t");
    }

    private void Y_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("y");
    }

    private void U_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("u");
    }

    private void I_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("i");
    }

    private void O_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("o");
    }

    private void P_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("p");
    }

    private void A_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("a");
    }

    private void S_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("s");
    }

    private void D_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("d");
    }

    private void F_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("f");
    }

    private void G_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("g");
    }

    private void H_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("h");
    }

    private void J_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("j");
    }

    private void K_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("k");
    }

    private void L_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("l");
    }

    private void Z_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("z");
    }

    private void X_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("x");
    }

    private void C_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("c");
    }

    private void V_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("v");
    }

    private void B_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("b");
    }

    private void N_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("n");
    }

    private void M_Clicked(object sender, EventArgs e)
    {
        //send value
        UpdateValue("m");
    }

    private void Enter_Clicked(object sender, EventArgs e)
    {
        //initialize values
        int maxColumnValue = 4;
        int maxRawValue = 5;

        //check for correct position
        if (currentColumn == maxColumnValue)
        {
            //check for correct position
            if ((currentColumn < labels.Count - 1) && (currentRow != maxRawValue))
            {
                //check for win
                if (wordPlayer == randomWord)
                {
                    string message1 = "Well done! You won and the number of your attempts is " + (++currentRow) + "\nCorrect word was " + randomWord;
                    DisplayAlert("Wordle", message1, "OK");
                    //start new game
                    RestartGame();
                }
                //check if value of wordPlayer exists in the file
                else if (CheckWordInFile(wordPlayer))
                {
                    labels[currentRow][currentColumn].BackgroundColor = Color.FromRgb(211, 211, 211);

                    
                    //keep track number of occurrences of each letter in randomWord
                    Dictionary<char, int> letterOccurrencesInAnswer = new Dictionary<char, int>();

                    //fill dictionary for letters in randomWord
                    foreach (char letter in randomWord)
                    {
                        if (letterOccurrencesInAnswer.ContainsKey(letter))
                        {
                            letterOccurrencesInAnswer[letter]++;
                        }
                        else
                        {
                            letterOccurrencesInAnswer[letter] = 1;
                        }
                    }

                    for (int i = 0; i < wordPlayer.Length; i++)
                    {
                        if (wordPlayer[i] == randomWord[i])
                        {
                            //update label color to green
                            labels[currentRow][i].BackgroundColor = Color.FromRgb(0, 255, 0);

                        }
                        else if (randomWord.Contains(wordPlayer[i].ToString()) &&
                                 letterOccurrencesInAnswer.ContainsKey(wordPlayer[i]) &&
                                 letterOccurrencesInAnswer[wordPlayer[i]] > 1)
                        {
                            // Update label color to yellow
                            int index = randomWord.IndexOf(wordPlayer[i]);
                            labels[currentRow][i].BackgroundColor = Color.FromRgb(255, 255, 0);
                            
                        }
                        else
                        {
                            // Update label color to red
                            labels[currentRow][i].BackgroundColor = Color.FromRgb(255, 0, 0);
                         
                        }
                    }

                    //update values
                    currentRow++;
                    currentColumn = 0;
                    labels[currentRow][currentColumn].BackgroundColor = Color.FromRgb(128, 128, 128);
                    wordPlayer = "";
                    }
                else {
                    DisplayAlert("Wordle", "Ooops... Does this word exist?", "I will try again");
                }

            }
            else
            {
                //in case of defear
                string message2 = "Next time will be better\nCorrect word was " + randomWord;
                DisplayAlert("Wordle", message2, "OK");
                //start new game
                RestartGame();
            }
        }


    }

    

    private bool CheckWordInFile(string word)
    {
        //identify location in directory
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words.txt");

        //check if the word exists in the file
        string[] words = File.ReadAllLines(filePath);
        return words.Contains(word);
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        //check if the current label has a value
        if (!string.IsNullOrEmpty(labels[currentRow][currentColumn].Text))
        {
            //delete the value from the current label
            labels[currentRow][currentColumn].Text = "";
            //remove the last character from wordPlayer
            if (!string.IsNullOrEmpty(wordPlayer))
            {
                wordPlayer = wordPlayer.Remove(wordPlayer.Length - 1);
            }
        }
        else
        {
            //move to the previous label
            if (currentColumn > 0)
            {
                labels[currentRow][currentColumn].BackgroundColor = Color.FromRgb(211, 211, 211);
                currentColumn--;
                labels[currentRow][currentColumn].BackgroundColor = Color.FromRgb(128, 128, 128);
            }
        }
    }

    private void RestartGame()
    {
        //clear all labels
        foreach (var row in labels)
        {
            foreach (var label in row)
            {
                label.Text = "";
                label.BackgroundColor = Color.FromRgb(211, 211, 211);
            }
        }

        //set values to zero
        currentRow = 0;
        currentColumn = 0;

        //clear wordPlayer
        wordPlayer = "";

        //get a new random word
        randomWord = GetRandomWord(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words.txt"));

    }

    private void SaveGame()
    {
        //create a SaveData instance
        SaveData saveData = new SaveData
        {
            CopyNameLogin = copyNameLogin,
            RandomWord = randomWord,
            LabelsText = labels.Select(row => row.Select(label => label.Text).ToList()).ToList(),
            CurrentRow = currentRow,
            CurrentColumn = currentColumn,
            WordPlayer = wordPlayer
        };

        //identify a location in a directory
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "save.json");

       //save to the file
        string json = JsonSerializer.Serialize(saveData);
        File.WriteAllText(filePath, json);
    }

}