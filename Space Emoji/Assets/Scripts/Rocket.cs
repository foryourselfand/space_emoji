using System;
using UnityEngine;

public class Rocket : PositionChanger
{
    public float xBound;

    private bool _directionToLeft;

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
                {
                    _selfDirection = DirectionType.Left;
                }

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
                {
                    _selfDirection = DirectionType.Right;
                }

                if (speed < 4)
                    speed++;
            }
        }

        if (_selfDirection == DirectionType.Left)
            ChangeDirection(-1);
        else if (_selfDirection == DirectionType.Right)
            ChangeDirection(1);
    }

    private void ChangeDirection(int direction)
    {
        SetTarget(new Vector2(xBound * direction, transform.localPosition.y));
    }
}