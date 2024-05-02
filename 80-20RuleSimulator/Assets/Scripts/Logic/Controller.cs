using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class Controller
    {
        private static Controller instance = new Controller();
        private List<Actor> _actors;
        private Controller(){}
        public static Controller Instance(){
            return instance;
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