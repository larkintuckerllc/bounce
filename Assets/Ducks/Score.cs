namespace Com.Larkintuckerllc.Bounce
{
    public class Score : Singleton<Score>
    {
        public static int InitialState = 0;

        public static int Reducer(int state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.SCORE_INCREMENT:
                    return state + 1;
                default:
                    return state;
            }
        }

        public static int ScoreGet(State state)
        {
            return state.Score;
        }

        protected Score() { }

        public Action ScoreIncrement()
        {
            return new Action(Provider.Actions.SCORE_INCREMENT);
        }
    }
}
