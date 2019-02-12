using System;
using System.Collections;
using UnityEngine;

public class Rocket : PositionXChanger
{
    public CameraChanger cameraChanger;
    public RotationChanger rotationChanger;

    private float _dependentSpeed;

    private float DependentSpeed
    {
        get { return _dependentSpeed; }
        set
        {
            _dependentSpeed = value;
            speed = value;
            cameraChanger.SetTargetFromStart(value / 2);
        }
    }

    private DirectionType _selfDirection = DirectionType.None;

    public void ChangeSpeedAndDirection(DirectionType initial)
    {
        DirectionCondition(initial, DirectionType.Left, DirectionType.Right);
        DirectionCondition(initial, DirectionType.Right, DirectionType.Left);

        var direction = initial == DirectionType.Right ? -1 : 1;
        var temp = DependentSpeed * direction * 2.5F;
        rotationChanger.SetTargetFromStart(temp);
        Debug.Log(temp.ToString());

        MoveByDirection();
    }

    private void DirectionCondition(DirectionType direction, DirectionType positive, DirectionType negative)
    {
        if (direction != positive) return;
        if (_selfDirection == negative)
            DecreaseSpeed();
        else
            IncreaseSpeed(positive);
    }

    private void DecreaseSpeed()
    {
        DependentSpeed--;
        if (DependentSpeed == 0)
            _selfDirection = DirectionType.None;
    }

    private void IncreaseSpeed(DirectionType direction)
    {
        if (DependentSpeed < 5)
            DependentSpeed++;
        if (_selfDirection == DirectionType.None)
            _selfDirection = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bound")) return;
        if (_selfDirection == DirectionType.Left)
            _selfDirection = DirectionType.Right;
        else if (_selfDirection == DirectionType.Right)
            _selfDirection = DirectionType.Left;

        MoveByDirection();
    }

    private void MoveByDirection()
    {
        var direction = _selfDirection == DirectionType.Right ? 1 : -1;
        SetTarget(100 * direction);
    }
}