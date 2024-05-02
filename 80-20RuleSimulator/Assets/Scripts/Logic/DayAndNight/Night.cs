namespace Logic.DayAndNight
{
    public class Night : State
    {
        private static Night instance = new Night();
        private Night(){}
        public static Night Instance(){
            return instance;
        }
    }
}