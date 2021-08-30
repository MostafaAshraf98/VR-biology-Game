using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0; //Temporary until merging with game manager
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "OxygenatedBlood")
        {
            score++;
        }
        else if(collider.gameObject.tag=="CarbonizedBlood")
        {
            score--;
        }
        Destroy(collider.gameObject);
    }
}
