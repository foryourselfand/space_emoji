public class PlayClicker : Clicker
{
    public GameCycle gameCycle;

    protected override void Click()
    {
        gameCycle.GroundOff();
    }
}