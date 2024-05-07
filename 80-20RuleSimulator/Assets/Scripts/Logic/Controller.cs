using System.Collections.Generic;
using Logic.DayAndNight;
using UnityEngine;

namespace Logic
{
    public class Controller
    {
        //FIELDS
        private static Controller instance = new Controller();
        private List<Actor> _actors;
        private State _dayNightState;

        //CONSTRUCTOR
        private Controller()
        {
            _actors = new List<Actor>();
            _dayNightState = Night.Instance();
        }
        
        //GETTERS
        public static Controller Instance(){
            return instance;
        }
        public List<Actor> GetActors()
        {
            return _actors;
        }
        public State GetState()
        {
            return _dayNightState;
        }
        
        //SETTERS   
        public void ChangeState()
        {
            _dayNightState.Change(this);
        }
        public void SetState(State state)
        {
            _dayNightState = state;
        }
        public void AddActor(Actor actor)
        {
            _actors.Add(actor);
            _actors.Sort((a, b) => 
            {
                float sumA = a.StatsCard.GetEquity() + a.StatsCard.GetValue();
                float sumB = b.StatsCard.GetEquity() + b.StatsCard.GetValue();
                return sumA.CompareTo(sumB);
            });
        }
    }
}