using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Snake snake;
    public GameObject plusOneTextPrefab;
    public Canvas snakeCanvas;
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
}
