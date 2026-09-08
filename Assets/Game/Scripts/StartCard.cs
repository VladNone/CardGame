public class StartCard : Card
{
    public Tutorial tutorial;
    public override void CardUse()
    {
        IsReverted = false;
        
        PlayerMovement player = ServiceLocator.GetService<PlayerMovement>();

        player.gameObject.SetActive(true);

        tutorial.StartTutorial();

        Kill();
    }
}
