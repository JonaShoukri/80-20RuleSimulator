using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Logic.DayAndNight
{
    public class State
    {
        public void Change(Controller controller){
            var actors = Controller.Instance().GetActors();
            foreach (Actor actor in actors)
            {
                actor.StatsCard.Bonus(); // bonus raises everyones equity by 2.5%
            }

            foreach (Actor actor in actors)
            {
                // make product price
                float product = (actor.StatsCard.GetValue() / 10) * actor.StatsCard.GetXFactor();
                
                // find 10 closest actors that can afford the product
                var distances = new List<(Actor, float)>();
                foreach (Actor atr in actors)
                {
                    if (atr != actor && atr.StatsCard.GetEquity() >= product)
                    {
                        distances.Add((atr, actor.DistanceTo(atr)));
                    }
                }

                distances.Sort((a, b) => a.Item2.CompareTo(b.Item2));
                var closestActors = distances.Take(10).Select(x => x.Item1).ToList();

                // make exchange of value and money between actor and closest actors to him who can afford his product
                foreach (Actor atr in closestActors)
                {
                    //buyer gives money
                    atr.StatsCard.equity -= product;
                    //buyer gets value
                    atr.StatsCard.value += product;
                    //seller gets money
                    actor.StatsCard.equity += product;
                    //seller gives value
                    actor.StatsCard.value -= (product / actor.StatsCard.GetXFactor());
                }
                
                // scale size of the actor to reflect his equity
                float equityScale = actor.StatsCard.GetEquity() / 10000;
                actor.transform.localScale = new Vector3(1, equityScale, 1);

                Debug.Log($"equity:{actor.StatsCard.GetEquity()}, xFactor:{actor.StatsCard.GetXFactor()}");
            }

            // Change state to day
            controller.SetState(Day.Instance());
        }
    }
}