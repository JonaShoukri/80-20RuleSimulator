namespace Logic.DayAndNight
{
    public class Day : State
    {
        private static Day instance = new Day();
        private Day(){}
        
        public void change(DayAndNightScript dns){
            dns.state = Night.Instance();
        }
        public static Day Instance(){
            return instance;
        }
    }
}