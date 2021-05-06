using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Text humanText;
    public Text crystalText;

    private int _humanScore = 0;
    private int _crystalScore = 0;

    private Snake _snake;
    private void Start()
    {
        _snake = GameManager.Instance.snake;
    }
    public void IncreaseHuman()
    {
        _humanScore++;
        humanText.text = "H: " + _humanScore;
        var anim = humanText.GetComponent<Animation>();
        if (anim.isPlaying)
            anim.Stop();
        anim.Play();
    }
    public void IncreaseCrystal()
    {
        if(!_snake.feverMode)
        {
            _crystalScore++;
            crystalText.text = "C: " + _crystalScore;
            var anim = crystalText.GetComponent<Animation>();
            if (anim.isPlaying)
                anim.Stop();
            anim.Play();
        }

        if(GameManager.Instance.feverModeAvailable)
        {
            if (_crystalScore >= 3 && !_snake.feverMode)
            {
                StartCoroutine(_snake.EnableFeverMode());
                _crystalScore = 0;
                crystalText.text = "C: " + _crystalScore;
            }
        }
    }
}
