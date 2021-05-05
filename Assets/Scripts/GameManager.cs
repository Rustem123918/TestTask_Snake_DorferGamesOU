using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Snake snake;
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
