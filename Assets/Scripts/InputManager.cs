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
        if (Input.GetKey(KeyCode.A))
        {
            if (_snake.transform.position.x <= -_snake.rightBord)
                return;
            _snake.Move(Vector3.left, false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (_snake.transform.position.x >= _snake.rightBord)
                return;
            _snake.Move(Vector3.right, false);
        }
    }
    private void MobileInput()
    {
        if (Input.touches.Length > 0)
        {
            var touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                var ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit raycastHit;
                if(Physics.Raycast(ray, out raycastHit))
                {
                    var currentX = _snake.transform.position.x;
                    var targetX = raycastHit.point.x;
                    targetX = Mathf.Clamp(targetX, -_snake.rightBord, _snake.rightBord);

                    var translation = new Vector3(targetX - currentX, 0, 0);
                    if(Mathf.Abs(targetX - currentX) < 0.2f)
                    {
                        _snake.Move(translation, true);
                    }
                    else
                    {
                        _snake.Move(translation, false);
                    }
                }
            }
        }
    }
}
