using System;
using System.Collections;
using UnityEngine;

public class Rocket : PositionChanger
{
    public FloatCameraChanger cameraChanger;

    private DirectionType _selfDirection = DirectionType.None;

    public void ChangeSpeedAndDirection(DirectionType initial)
    {
        DirectionCondition(initial, DirectionType.Left, DirectionType.Right);
        DirectionCondition(initial, DirectionType.Right, DirectionType.Left);

        SetDirectionBasedOnSelf();
    }

    private void DirectionCondition(DirectionType initial, DirectionType positive, DirectionType negative)
    {
        if (initial != positive) return;
        if (_selfDirection == negative)
            DecreaseSpeed();
        else
            IncreaseSpeed(positive);
    }

    private void DecreaseSpeed()
    {
        speed--;
        cameraChanger.SetTargetFromStart(speed / 2);
        if (speed == 0)
            _selfDirection = DirectionType.None;
    }

    private void IncreaseSpeed(DirectionType defaultDirection)
    {
        if (speed < 5)
            speed++;
        cameraChanger.SetTargetFromStart(speed / 2);
        if (_selfDirection == DirectionType.None)
            _selfDirection = defaultDirection;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bound")) return;
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
        SetTarget(new Vector2(100 * direction, transform.localPosition.y));
    }

    public IEnumerator Fly()
    {
        speed = 3;

        cameraChanger.SetTargetFromStart(-1);
        SetTargetFromCurrent(new Vector2(0, 1.66F));
        yield return new WaitUntil(IsFinished);

        cameraChanger.SetTargetFromStart(0);
        SetTargetFromCurrent(new Vector2(0, -2.32F));
        yield return new WaitUntil(IsFinished);

        speed = 0;
    }
}