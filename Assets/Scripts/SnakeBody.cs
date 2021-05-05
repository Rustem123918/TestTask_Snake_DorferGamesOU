using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public GameObject bodyPartPrefab;
    public int maxBodyLength = 10;
    public int startBodyLength = 3;
    public float decreaseScale = 1.05f;

    public float eatingSpeed = 0.1f;
    public float eatingBodyPartSizeScale = 1.7f;

    private List<GameObject> _body;
    private List<Vector3> _bodyPartsOriginalScale;
    private void Start()
    {
        _body = new List<GameObject>();
        _bodyPartsOriginalScale = new List<Vector3>();
        for(int i = 0; i < startBodyLength; i++)
        {
            IncreaseBodyLength();
        }
    }
    public void IncreaseBodyLength()
    {
        if (_body.Count == maxBodyLength)
            return;

        Vector3 position;
        if (_body.Count == 0)
            position = transform.position + Vector3.back;
        else
            position = _body[_body.Count - 1].transform.position + Vector3.back;

        var bodyPart = Instantiate(bodyPartPrefab, position, Quaternion.identity);
        
        var smoothFollow = bodyPart.AddComponent<SmoothFollow>();
        if(_body.Count == 0)
        {
            smoothFollow.target = this.transform;
        }
        else
        {
            smoothFollow.target = _body[_body.Count - 1].transform;
        }

        if(_body.Count != 0)
            bodyPart.transform.localScale = _body[_body.Count - 1].transform.localScale / decreaseScale;
        _body.Add(bodyPart);
        _bodyPartsOriginalScale.Add(bodyPart.transform.localScale);
    }
    public IEnumerator Eating()
    {
        for (int i = 0; i < _body.Count; i++)
        {
            var bodyPart = _body[i];
            bodyPart.transform.localScale = _bodyPartsOriginalScale[i];
            bodyPart.transform.localScale *= eatingBodyPartSizeScale;
            yield return new WaitForSeconds(eatingSpeed);
            bodyPart.transform.localScale = _bodyPartsOriginalScale[i];
        }
        IncreaseBodyLength();
    }
}
