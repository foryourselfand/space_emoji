public class ArrowClicker : Clicker
{
    public DirectionType directionType;
    public Rocket rocket;
    public GameCycle gameCycle;

    protected override void Click()
    {
        rocket.ChangeSpeedAndDirection(directionType);
        gameCycle.FirstClickOnInstructions();
    }
}