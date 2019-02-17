using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : PositionXChanger
{
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

    private float DependentSpeed
    {
        get { return Speed; }
        set
        {
            Speed = value;
            DependentsAction();
        }
    }

    private void DependentsAction()
    {
        dependentsParent.AllDependentsAction(SelfDirection, DependentSpeed);
    }

    public void ChangeSpeedAndDirection(DirectionType initial)
    {
        if (initial == DirectionType.Left)
        {
            if (SelfDirection == DirectionType.Right)
                DecreaseSpeed();
            else
                IncreaseSpeed(DirectionType.Left);
        }
        else if (initial == DirectionType.Right)
        {
            if (SelfDirection == DirectionType.Left)
                DecreaseSpeed();
            else
                IncreaseSpeed(DirectionType.Right);
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
        switch (SelfDirection)
        {
            case DirectionType.Left:
                SelfDirection = DirectionType.Right;
                break;
            case DirectionType.Right:
                SelfDirection = DirectionType.Left;
                break;
            case DirectionType.None:
            {
                if (_lastDirection == DirectionType.Left)
                {
                    IncreaseSpeed(DirectionType.Right);
                }
                else if (_lastDirection == DirectionType.Right)
                {
                    IncreaseSpeed(DirectionType.Left);
                }

                break;
            }
        }

        MoveByDirection();
    }

    private void MoveByDirection()
    {
        var direction = SelfDirection == DirectionType.Right ? 1 : -1;
        SetTarget(100 * direction);
    }
}