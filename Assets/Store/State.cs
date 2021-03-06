﻿namespace Com.Larkintuckerllc.Bounce
{
    public class State
    {

        // UPDATE FOR EACH DUCK
        public Mode.ModeEnum Mode { get; private set; }
        public bool PlacementValid { get; private set; }
        public int Score { get; private set; }

        // UPDATE FOR EACH DUCK
        public State(
            Mode.ModeEnum mode,
            bool placementValid,
            int score
        )
        {
            Mode = mode;
            PlacementValid = placementValid;
            Score = score;
        }
    }
}