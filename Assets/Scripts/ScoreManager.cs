using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Text humanText;
    public Text crystalText;

    private int _humanScore = 0;
    private int _crystalScore = 0;

    public void IncreaseHuman()
    {
        _humanScore++;
        humanText.text = "H: " + _humanScore;
    }
    public void IncreaseCrystal()
    {
        _crystalScore++;
        crystalText.text = "C: " + _crystalScore;
    }
}
