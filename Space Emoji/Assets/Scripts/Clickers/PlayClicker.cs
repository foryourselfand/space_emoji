public class PlayClicker : Clicker
{
    public GameCycle GameCycle;

    protected override void Click()
    {
        GameCycle.HideMenuButtons();
        GameCycle.OffGround();
    }
}