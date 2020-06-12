using UnityEngine;

public class Hacker : MonoBehaviour
{
    private Inventory playerInventory;

    [SerializeField] string computerName = "computer";

    [SerializeField] Item[] prizes; 

    //Game configuration Data
    string[,] passwords = {
        {"borrego","tec21", "eiad", "garza"},
        {"spaceship", "moon", "interstelar", "armstrong"},
        {"robot", "secret", "president", "hacker"}
    };

    //Game State
    int level;

    enum Screen { MainMenu, Password, Win, Loser }
    Screen currentScreen;
    string password;

    int attempts = 3;

    bool guessedPassword = false;

    void Start()
    {
        playerInventory = InventoryManager.INSTANCE.GetPlayerInventory();
        ShowMainMenu();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (guessedPassword || attempts == 0)
            {
                CloseTerminal();
                this.gameObject.GetComponentInParent<Computer>().ComputerHasBeenUsed();
            }

        }
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("\n");
        Terminal.WriteLine("Seleccione el nivel de dificultad:");
        Terminal.WriteLine("[1] Facil");
        Terminal.WriteLine("[2] Normal");
        Terminal.WriteLine("[3] Dificil\n");
        Terminal.WriteLine("Ingrese su seleccion: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {

        Debug.Log("Inputttttttttttttt : " + input);

        if (input == "1" || input == "2" || input == "3")
        {
            level = int.Parse(input);
            SetRandomPassword();
            AskForPassword();
        }

        else
        {
            Terminal.WriteLine("Ingrese una opcion valida");
        }
    }

    void SetRandomPassword()
    {
        print(passwords.GetLength(0));
        int randomIndex = Random.Range(0, passwords.GetLength(0));
        print(randomIndex);
        password = passwords[level - 1, randomIndex];
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("Haz escogido el nivel: " + level);
        Terminal.WriteLine("Ingrese la clave secreta. \nPista: " + password.Anagram());
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Has acertado!\n");
            DisplayWinScreen();
        }
        else
        {
            attempts--;

            if (attempts > 0) AskForPassword();
            else DisplayLoserScreen();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("\nPresione [ESC] para salir\n");
        guessedPassword = true;
    }

   

    void DisplayLoserScreen()
    {
        currentScreen = Screen.Loser;
        Terminal.ClearScreen();
        Terminal.WriteLine("Haz perdido! \nMejor suerte para la proxima");
        Terminal.WriteLine("\nPresione [ESC] para salir\n");
    }

    void ShowLevelReward()
    {
        Terminal.WriteLine("Haz ganado: ");

        for (int i=0; i<level; i++)
		{
            string prize_name = prizes[i].ItemName;
            Terminal.WriteLine("- 1 x "+prize_name+"\n");
            playerInventory.addItem(new ItemStack(prizes[i], 1));
            InventoryManager.INSTANCE.openContainer(new ContainerPlayerHotbar(null, playerInventory));
            InventoryManager.INSTANCE.resetInventoryStatus();
        }

    }



    void CloseTerminal()
    {
        gameObject.GetComponent<Camera>().enabled = false;
        gameObject.SetActive(false);
        InventoryManager.INSTANCE.EnableAll();
    }

    public void Reset()
    {
        OnUserInput("menu");
    }

}
