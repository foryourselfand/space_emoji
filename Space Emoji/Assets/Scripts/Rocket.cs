using UnityEngine;

public class Rocket : PositionChanger
{
    public float xBound;

    private bool _directionToLeft;

    public void ChangeSpeed(int speedBy)
    {
        speed += speedBy;
        _directionToLeft = speedBy < 0;
        ChangeDirection(_directionToLeft ? -1 : 1);
    }

    private void ChangeDirection(int direction)
    {
        SetTarget(new Vector2(xBound * direction, -2.32F));
    }
}