using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] protected float timer; // the time counter
    [SerializeField] protected float spawningTime; // the time to spawn 

    public GameObject[] monsters;
    public GameObject[] arrSpawningPoint;


    void Start()
    {
        timer = 0;
        CheckDifficulty();
    }

    void Update()
    {
        if (Tutorial._Tutorial.OnTutorialMode)
            return;
        timer += Time.deltaTime;
        int index;
        if (timer > spawningTime)
        {
            index = Random.Range(0, monsters.Length); // random monster
            GameObject monsterParent = monsters[index];
            GameObject monster;
            for (int i = 0; i < 10; i++)
            {
                monster = monsterParent.transform.GetChild(i).gameObject;
                if (!monster.activeSelf)
                {
                    // randomly choose a spawning point and instantiate one of the monsters
                    index = Random.Range(0, arrSpawningPoint.Length); // random spawning point
                    Vector3 position = arrSpawningPoint[index].transform.position;
                    Quaternion rotation = arrSpawningPoint[index].transform.rotation * Quaternion.Euler(0, 180, 0);
                    monster.SetActive(true);
                    monster.transform.position = position;
                    monster.transform.rotation = rotation;
                    break;
                }

            }
            timer = 0;
        }
    }

    private void CheckDifficulty()
    {
        if (EventManager._eventManager.GetCurrentEvent() == Events.TrafficJam)
        {
            switch (EventManager._eventManager.GetEventDifficulty())
            {
                case Difficulty.Easy:
                    spawningTime = 1.5f;
                    break;
                case Difficulty.Normal:
                    spawningTime = 1f;
                    break;
                case Difficulty.Hard:
                    spawningTime = 0.75f;
                    break;
                case Difficulty.Nightmare:
                    spawningTime = 0.5f;
                    break;
            }
        }
    }
}
