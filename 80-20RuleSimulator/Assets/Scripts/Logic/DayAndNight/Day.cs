using UnityEngine;

namespace Logic.DayAndNight
{
    public class Day : State
    {
        private static Day instance = new Day();
        private Day(){}
        
        new public void Change( Controller controller){
            Debug.Log("Changing to Night");
            
            // Change state to night
            controller.SetState(Night.Instance());
        }
        public static Day Instance(){
            return instance;
        }
    }
}