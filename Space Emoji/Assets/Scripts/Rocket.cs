using System;
using System.Collections;
using UnityEngine;

public class Rocket : PositionXChanger
{
    public CameraChanger cameraChanger;
    public RotationManager rotationManager;

    private DirectionType _selfDirection = DirectionType.None;

    private DirectionType SelfDirection
    {
        get { return _selfDirection; }
        set
        {
            _selfDirection = value;
            rotationManager.Action(_selfDirection, DependentSpeed);
        }
    }

    private float DependentSpeed
    {
        get { return speed; }
        set
        {
            speed = value;
            cameraChanger.SetTargetFromStart(value / 2);
            rotationManager.Action(_selfDirection, DependentSpeed);
        }
    }

    private bool _canLeft = true, _canRight = true;

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
            SelfDirection = DirectionType.None;
        DependentSpeed--;
    }

    private void IncreaseSpeed(DirectionType direction)
    {
        if (SelfDirection == DirectionType.None)
            SelfDirection = direction;
        if (DependentSpeed < 5)
            DependentSpeed++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bound")) return;
        if (SelfDirection == DirectionType.Left)
            SelfDirection = DirectionType.Right;
        else if (SelfDirection == DirectionType.Right)
            SelfDirection = DirectionType.Left;

        MoveByDirection();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Bound")) return;
        if (!_canLeft)
            _canLeft = true;
        if (!_canRight)
            _canRight = true;
    }

    private void MoveByDirection()
    {
        var direction = SelfDirection == DirectionType.Right ? 1 : -1;
        SetTarget(100 * direction);
    }
}