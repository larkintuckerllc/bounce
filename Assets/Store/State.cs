namespace Com.Larkintuckerllc.Bounce
{
    public class State
    {

        // UPDATE FOR EACH DUCK
        public Mode.ModeEnum Mode { get; private set; }
        public int MZPositionX { get; private set; }
        public int MZPositionZ { get; private set; }
        public int MZScaleX { get; private set; }
        public int MZScaleZ { get; private set; }
        public int TouchX { get; private set; }
        public int TouchY { get; private set; }

        // UPDATE FOR EACH DUCK
        public State(
            Mode.ModeEnum mode,
            int mZPositionX,
            int mZPositionZ,
            int mZScaleX,
            int mZScaleZ,
            int touchX,
            int touchY
        )
        {
            Mode = mode;
            MZPositionX = mZPositionX;
            MZPositionZ = mZPositionZ;
            MZScaleX = mZScaleX;
            MZScaleZ = mZScaleZ;
            TouchX = touchX;
            TouchY = touchY;
        }
    }
}