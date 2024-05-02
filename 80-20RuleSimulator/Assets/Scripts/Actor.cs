using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;

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
}
