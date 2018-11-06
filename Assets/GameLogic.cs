using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
    private Dropdown difficulty;
    private List<Dropdown.OptionData> difOptions;
    private string currentOption;
    private Button restartGame;
    private Button startGame;
    private Button stopGame;

    private int cannonHealth = 3;

    // Initializes buttons and dropdown value
    void Start () {
        difficulty = GameObject.Find("DifficultyDropdown").GetComponent<Dropdown>();
        difOptions = difficulty.options;
        currentOption = difOptions[difficulty.value].text;

        switch (currentOption)
        {
            case "Easy":
                GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().spawnTime = 2f;
                break;
            case "Medium":
                GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().spawnTime = 0.8f;
                break;
            case "Hard":
                GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().spawnTime = 0.3f;
                break;
            default: break;
        }

        restartGame = GameObject.Find("RestartButton").GetComponent<Button>();
        restartGame.onClick.AddListener(RestartGame);

        startGame = GameObject.Find("StartButton").GetComponent<Button>();
        startGame.onClick.AddListener(StartGame);

        stopGame = GameObject.Find("StopButton").GetComponent<Button>();
        stopGame.onClick.AddListener(StopGame);
    }

    // Updates game difficulty according to dropdown value
    void Update() {
        if (currentOption != difOptions[difficulty.value].text)
        {
            GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().enabled = false;
            GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().activeSpawner = false;

            currentOption = difOptions[difficulty.value].text;
            switch (currentOption)
            {
                case "Easy":
                    GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().spawnTime = 2f;
                    break;
                case "Medium":
                    GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().spawnTime = 0.8f;
                    break;
                case "Hard":
                    GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().spawnTime = 0.3f;
                    break;
                default: break;
            }

            GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().enabled = true;
            GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().activeSpawner = true;
        }
    }

    // Restarts game, stopping the game and setting the scoreboard to 0
    void RestartGame()
    {
        GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().activeSpawner = false;
        GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().ResetGame();
        GameObject.Find("Scoreboard").GetComponent<Text>().text = "0";
    }

    // Starts the game with the difficulty according to the dropdown value
    void StartGame()
    {
        GameObject.Find("GameStateLabel").GetComponent<Text>().text = "Now playing";
        GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().enabled = true;
        GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().StartGame();
    }

    // Stops the running game
    void StopGame()
    {
        GameObject.Find("GameStateLabel").GetComponent<Text>().text = "Game stopped";
        GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().StopGame();
    }

    // Returns the cannon health
    public int getCannonHealth()
    {
        return cannonHealth;
    }

    // Sets the cannon health
    public void setCannonHealth(int c)
    {
        cannonHealth = c;
    }

    // Recuces cannon health
    public void reduceCannonHealth()
    {
        cannonHealth--;
    }
}
