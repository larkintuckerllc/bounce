namespace Com.Larkintuckerllc.Bounce
{
    public class State
    {

        // UPDATE FOR EACH DUCK
        public Mode.ModeEnum Mode { get; private set; }
        public Triplet Placement { get; private set; }
        public bool PlacementValid { get; private set; }
        public int TouchX { get; private set; }
        public int TouchY { get; private set; }

        // UPDATE FOR EACH DUCK
        public State(
            Mode.ModeEnum mode,
            Triplet placement,
            bool placementValid,
            int touchX,
            int touchY
        )
        {
            Mode = mode;
            Placement = placement;
            PlacementValid = placementValid;
            TouchX = touchX;
            TouchY = touchY;
        }
    }
}