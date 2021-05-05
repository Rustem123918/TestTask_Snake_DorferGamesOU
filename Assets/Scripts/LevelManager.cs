using System.Collections;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public float timeDelay = 6f;

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
    public void ChangeColor()
    {
        StartCoroutine(ChangeColorRoutine());
    }
    private IEnumerator ChangeColorRoutine()
    {
        snakeMaterial.color = mainColors[_levelIndex];
        yield return new WaitForSeconds(timeDelay);
        if (_levelIndex >= mainColors.Length - 1)
            yield break;
        humanMaterial.color = mainColors[_levelIndex + 1];
        badHumanMaterial.color = badColors[_levelIndex + 1];
        
        _levelIndex++;
    }
}
