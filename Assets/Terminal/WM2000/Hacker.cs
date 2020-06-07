using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration Data
    string[,] passwords = {
        {"borrego","tec21", "eiad", "garza"},
        {"spaceship", "moon", "interstelar", "armstrong"},
        {"robot", "secret", "president", "hacker"}
    };


    const string BOOK = @"
       __...--~~~-._ _.-~~~--..._
    //           ` V'           \\ 
   //              |             \\ 
  //__...--~~~~-._ |  _.-~~~--...__\\ 
 //__.....----~~._\| /_.~~~~--....__\\
 ================\\|//=================
                 `---`
    ",
    SPACESHIP = @"
       ^
     /___\
    |=   =|
    |     |
   /|##!##|\
 /  |##!##|  \
|  /       \  |
|/           \|
",
ROBOT = @"
         __
 _(\    |@@|
(__/\__ \--/ __
   \___|----|  |   __
       \ }{ /\ )_ / _\
       /\__/\ \__O (__
      (--/\--)    \__/
      _)(  )(_
";


    //Game State
    int level;

    enum Screen {MainMenu, Password, Win}
    Screen currentScreen;
    string password;

    void Start() {
        InventoryManager.INSTANCE.DisableAll();
        ShowMainMenu();
    }

    
    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Alpha Hacker\n");
        Terminal.WriteLine("What place would you like to HACK:");
        Terminal.WriteLine("[1] Tec de Monterrey");
        Terminal.WriteLine("[2] NASA");
        Terminal.WriteLine("[3] Pentagon\n");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input) {
        if (input == "menu") {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input) {
        if (input == "1" || input == "2" || input == "3") {
            level = int.Parse(input);
            SetRandomPassword();
            AskForPassword();
        }
        else if (input == "007") {
            Terminal.WriteLine("Please select a level Mr. Bond");
        }
        else {
            Terminal.WriteLine("Please enter a valid option");
        }
    }

    void SetRandomPassword() { 
        print(passwords.GetLength(0));
        int randomIndex = Random.Range(0, passwords.GetLength(0));
        print(randomIndex);
        password = passwords[level-1, randomIndex];
    }

    void AskForPassword() {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You hace chosen level "+level);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void CheckPassword(string input) {
        if (input == password) {
            //Terminal.WriteLine("Well Done!");
            DisplayWinScreen();
        }
        else {
            AskForPassword();
        }
    }

    void DisplayWinScreen() {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Destroy(gameObject.GetComponent<Camera>());
        gameObject.SetActive(false);
        InventoryManager.INSTANCE.EnableAll();
    }

    void ShowLevelReward() {
        switch (level) {
            case 1:
                Terminal.WriteLine("Have a book ...");
                Terminal.WriteLine(BOOK);
                break;
            case 2:
                Terminal.WriteLine("Have a Rocket");
                Terminal.WriteLine(SPACESHIP);
                break;
            case 3:
                Terminal.WriteLine("You got a Robot");
                Terminal.WriteLine(ROBOT);
                break;
        }   

    }

}
