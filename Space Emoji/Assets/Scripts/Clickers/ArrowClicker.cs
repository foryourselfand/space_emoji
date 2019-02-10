public class ArrowClicker : Clicker
{
    public int speedBy;
    public Rocket rocket;
    public ButtonsManager buttonsManager;

    protected override void Click()
    {
        rocket.ChangeSpeed(speedBy);
        buttonsManager.HideInstructionsIfNeed();
    }
}