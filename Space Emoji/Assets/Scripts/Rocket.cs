using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : PositionXChanger
{
    public CameraManager cameraManager;
    public DependentsParent dependentsParent;

    private DirectionType _selfDirection = DirectionType.None;
    private DirectionType _lastDirection = DirectionType.None;

    private DirectionType SelfDirection
    {
        get { return _selfDirection; }
        set
        {
            _lastDirection = _selfDirection;
            _selfDirection = value;
            DependentsAction();
        }
    }

//    private int _clickCount;

    private float DependentSpeed
    {
        get { return Speed; }
        set
        {
            Speed = value;
            DependentsAction();
        }
    }

    private bool _canLeft = true, _canRight = true;

    private void DependentsAction()
    {
        dependentsParent.AllDependentsAction(SelfDirection, DependentSpeed);
//        dependentsParent.AllDependentsAction(SelfDirection, _clickCount);
    }

    public void ChangeSpeedAndDirection(DirectionType initial)
    {
        if (initial == DirectionType.Left)
        {
            if (_canLeft)
            {
                if (SelfDirection == DirectionType.Right)
                    DecreaseSpeed();
                else
                    IncreaseSpeed(DirectionType.Left);
            }
        }
        else if (initial == DirectionType.Right)
        {
            if (_canRight)
            {
                if (SelfDirection == DirectionType.Left)
                    DecreaseSpeed();
                else
                    IncreaseSpeed(DirectionType.Right);
            }
        }

        MoveByDirection();
    }

    private void DecreaseSpeed()
    {
        if (DependentSpeed - 1 == 0)
//        if (_clickCount == 0)
            SelfDirection = DirectionType.None;

        DependentSpeed--;

//        _clickCount--;
//        if (Math.Abs(DependentSpeed - 1) < 0.01F)
//            DependentSpeed = 0;
//        else
//            DependentSpeed /= 1.6F;
    }

    private void IncreaseSpeed(DirectionType direction)
    {
        if (SelfDirection == DirectionType.None)
            SelfDirection = direction;

        if (DependentSpeed < 5)
            DependentSpeed++;

//        if (_clickCount < 4)
//        {
//            _clickCount++;
//            if (Math.Abs(DependentSpeed) < 0.01F)
//                DependentSpeed = 1;
//            else
//                DependentSpeed *= 1.6F;
//        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bound"))
        {
            switch (SelfDirection)
            {
                case DirectionType.Left:
                    cameraManager.ShakeLittle(SelfDirection);
                    _canLeft = false;
                    SelfDirection = DirectionType.Right;
                    break;
                case DirectionType.Right:
                    cameraManager.ShakeLittle(SelfDirection);
                    _canRight = false;
                    SelfDirection = DirectionType.Left;
                    break;
                case DirectionType.None:
                {
                    switch (_lastDirection)
                    {
                        case DirectionType.Left:
                            _canRight = false;
                            break;
                        case DirectionType.Right:
                            _canLeft = false;
                            break;
                    }
                    IncreaseSpeed(_lastDirection);
                    cameraManager.ShakeLittle(_lastDirection);
                    
                    break;
                }
            }

            MoveByDirection();
        }

        if (other.CompareTag("Enemy"))
        {
//            Debug.Log("Dead");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bound"))
        {
            if (_canLeft == false)
                _canLeft = true;
            if (_canRight == false)
                _canRight = true;
        }
    }

    private void MoveByDirection()
    {
        var direction = SelfDirection == DirectionType.Right ? 1 : -1;
        SetTarget(100 * direction);
    }
}