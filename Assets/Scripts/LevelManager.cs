using System.Collections;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Material humanMaterial;
    public Material badHumanMaterial;
    public Material snakeMaterial;

    public Color[] mainColors;
    public Color[] badColors;

    private int _levelIndex = 0;
    private void Start()
    {
        snakeMaterial.color = mainColors[0];
        humanMaterial.color = mainColors[0];

        badHumanMaterial.color = badColors[0];
    }
    public void ChangeSnakeColor()
    {
        snakeMaterial.color = mainColors[_levelIndex];

        _levelIndex++;
    }
    public void ChangeHumansColor()
    {
        if (_levelIndex >= mainColors.Length)
            return;
        humanMaterial.color = mainColors[_levelIndex];
        badHumanMaterial.color = badColors[_levelIndex];
    }
}
