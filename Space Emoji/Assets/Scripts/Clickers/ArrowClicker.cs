public class ArrowClicker : Clicker
{
    public DirectionType directionType;
    public Rocket rocket;
    public ButtonsManager buttonsManager;

    protected override void Click()
    {
        rocket.ChangeSpeedAndDirection(directionType);
        buttonsManager.HideInstructionsIfNeed();
    }
}