public class PlayerController : Poser
{
    public SpawnEvent SpawnEvent;
    public InputReader InputReader;

    public void OnSpawnEvent(Poser target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        // Add Player Poser's moves to input callbacks
        if (InputReader != null)
        {
            InputReader.PressEventA += OnA;
            InputReader.PressEventD += OnD;
            InputReader.PressEventS += OnS;
            InputReader.PressEventW += OnW;
        }

        if (SpawnEvent != null)
        {
            SpawnEvent.OnEventRaised += OnSpawnEvent;
        }
    }

    private void OnDisable()
    {
        // Remove Player Poser's moves to input callbacks
        if (InputReader != null)
        {
            InputReader.PressEventA -= OnA;
            InputReader.PressEventD -= OnD;
            InputReader.PressEventS -= OnS;
            InputReader.PressEventW -= OnW;
        }

        if (SpawnEvent != null)
        {
            SpawnEvent.OnEventRaised -= OnSpawnEvent;
        }
    }
}
