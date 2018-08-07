namespace Com.Larkintuckerllc.Bounce
{
    public class State
    {

        // UPDATE FOR EACH DUCK
        public Mode.ModeEnum Mode { get; private set; }
        public int TouchX { get; private set; }
        public int TouchY { get; private set; }

        // UPDATE FOR EACH DUCK
        public State(
            Mode.ModeEnum mode,
            int touchX,
            int touchY
        )
        {
            Mode = mode;
            TouchX = touchX;
            TouchY = touchY;
        }
    }
}