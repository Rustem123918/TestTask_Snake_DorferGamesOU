using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Snake snake;
    public GameObject plusOneTextPrefab;
    public Canvas snakeCanvas;

    public GameObject startPanel;

    public bool feverModeAvailable = true;
    public bool invincible = false;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void StartButton()
    {
        Time.timeScale = 1f;
        startPanel.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
    public void PlayPlusOneAnimation()
    {
        var text = Instantiate(plusOneTextPrefab);
        text.transform.SetParent(snakeCanvas.transform, false);
        Destroy(text, 1f);
    }
    public void ChangeFeverMode()
    {
        feverModeAvailable = !feverModeAvailable;
    }
    public void ChangeInvincible()
    {
        invincible = !invincible;
    }
}
