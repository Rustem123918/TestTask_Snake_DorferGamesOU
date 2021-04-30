using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Snake _snake;
    private void Update()
    {
        if (_snake == null)
            return;
        PCInput();
        MobileInput();
    }
    public void Restart()
    {
        //_snake = GameManager.Instance.snake;
    }
    private void PCInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_snake.transform.position.x <= -_snake.rightBord)
                return;
            var currentX = _snake.transform.position.x;
            var targetX = -1f;
            var translation = targetX - currentX;
            _snake.Move(new Vector3(translation, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_snake.transform.position.x >= _snake.rightBord)
                return;
            var currentX = _snake.transform.position.x;
            var targetX = 1f;
            var translation = targetX - currentX;
            _snake.Move(new Vector3(translation, 0, 0));
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            var currentX = _snake.transform.position.x;
            var targetX = 0f;
            var translation = targetX - currentX;
            _snake.Move(new Vector3(translation, 0, 0));
        }
    }
    private void MobileInput()
    {

    }
}
