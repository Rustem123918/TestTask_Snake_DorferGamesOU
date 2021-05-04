using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public float timeDelay = 6f;

    public Material humanMaterial;
    public Material badHumanMaterial;
    public Material snakeMaterial;

    public Color[] mainColors;
    public Color[] badColors;

    private int levelIndex = 0;
    private void Start()
    {
        snakeMaterial.color = mainColors[0];
        humanMaterial.color = mainColors[0];

        badHumanMaterial.color = badColors[0];
    }
    //public void Restart()
    //{
    //    levelIndex = 0;
    //}
    public void ChangeColor()
    {
        StartCoroutine(ChangeColorRoutine());
    }
    private IEnumerator ChangeColorRoutine()
    {
        snakeMaterial.color = mainColors[levelIndex];
        yield return new WaitForSeconds(timeDelay);
        if (levelIndex >= mainColors.Length - 1)
            yield break;
        humanMaterial.color = mainColors[levelIndex + 1];
        badHumanMaterial.color = badColors[levelIndex + 1];
        
        levelIndex++;
    }
}
