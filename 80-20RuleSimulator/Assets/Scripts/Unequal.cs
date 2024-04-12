using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unequal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Generate a random number between 0 and 99
        int randomNumber = Random.Range(0, 100);

        // Check if the random number is 0 (1/100 chance)
        if (randomNumber == 0)
        {
            // Self-destruct the object
            Destroy(gameObject);
        }
    }
}
