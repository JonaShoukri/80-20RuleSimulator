namespace Logic.DayAndNight
{
    public class State
    {
        public void change(DayAndNightScript dns){
            dns.state = Day.Instance();
        }
    }
}