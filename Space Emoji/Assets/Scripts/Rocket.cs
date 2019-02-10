using System;
using UnityEngine;

public class Rocket : PositionChanger
{
    public float xBound;

    private DirectionType _selfDirection = DirectionType.None;

    public void ChangeSpeedAndDirection(DirectionType directionType)
    {
        if (directionType == DirectionType.Left)
        {
            if (_selfDirection == DirectionType.Right)
            {
                speed--;
                if (speed == 0)
                    _selfDirection = DirectionType.None;
            }
            else
            {
                if (_selfDirection == DirectionType.None)
                    _selfDirection = DirectionType.Left;

                if (speed < 4)
                    speed++;
            }
        }

        if (directionType == DirectionType.Right)
        {
            if (_selfDirection == DirectionType.Left)
            {
                speed--;
                if (speed == 0)
                    _selfDirection = DirectionType.None;
            }
            else
            {
                if (_selfDirection == DirectionType.None)
                    _selfDirection = DirectionType.Right;

                if (speed < 4)
                    speed++;
            }
        }

        SetDirectionBasedOnSelf();
    }

    protected override void OnEnd()
    {
        if (_selfDirection == DirectionType.Left)
            _selfDirection = DirectionType.Right;
        else if (_selfDirection == DirectionType.Right)
            _selfDirection = DirectionType.Left;

        SetDirectionBasedOnSelf();
    }


    private void SetDirectionBasedOnSelf()
    {
        if (_selfDirection == DirectionType.Left)
            SetDirection(-1);
        else if (_selfDirection == DirectionType.Right)
            SetDirection(1);
    }

    private void SetDirection(int direction)
    {
        StartChanging();
        SetTarget(new Vector2(xBound * direction, transform.localPosition.y));
    }
}