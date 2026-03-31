using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpaner;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject gameUi;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseGameMenu;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private GameObject red;



    private bool bossCalled = false;
    void Start()
    {

        boss.SetActive(false);
        UpdateEnergyBar();
        currentEnergy = 0;
        MainMenu();
        audioManager.StopAudioGame();
        red.SetActive(false);
        
    }
    public void AddEnergy()
    {
        if (bossCalled)
        {
            return;
        }
        currentEnergy += 1;
        UpdateEnergyBar();
        if (currentEnergy == energyThreshold)
        {
            CallBoss();

        }
    }
    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpaner.SetActive(false);
        gameUi.SetActive(false);
        audioManager.PlayBossAudio();
        red.SetActive(true);
    }
    private void UpdateEnergyBar()
    {

        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }

    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;

    }
    public void PauseGameMenu()
    {
        pauseGameMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultAudio();
    }

    public void ResumeGame()
    {

        mainMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GameWin()
    {
        mainMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayerInstruction()
    {
        mainMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        audioManager.PlayDefaultAudio();
        audioManager.PlayDefaultAudio();
        Time.timeScale = 0f;

    }
    public void TypeEnemy()
    {
        mainMenu.SetActive(false);
        pauseGameMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;
        audioManager.PlayDefaultAudio();

    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        pauseGameMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f;
        audioManager.PlayDefaultAudio();
    }
    
   
}
