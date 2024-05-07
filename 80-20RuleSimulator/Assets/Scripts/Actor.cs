using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;
using UnityEngine.AI;

public class Actor : MonoBehaviour
{
    public StatsCard StatsCard;
    // Start is called before the first frame update
    void Start()
    {
        StatsCard = new StatsCard();
        Controller.Instance().AddActor(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float DistanceTo(Actor other)
    {
        return Mathf.Sqrt(Mathf.Pow(this.transform.position.x - other.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - other.transform.position.y, 2));
    }
}
