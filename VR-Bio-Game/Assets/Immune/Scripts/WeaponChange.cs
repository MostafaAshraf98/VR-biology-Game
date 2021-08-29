using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public GameObject Gun;
    public GameObject Sword;
    public GameObject Pill;
    public Transform weaponPlace;
    public Transform SwordPlace;
    public Transform GunPlace;
    public Transform PillPlace;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
      ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Press P to summon the pill at the weapon place
        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetPosition();
            GameObject pill;
            for (int i = 0; i < 5; i++)
            {
                pill = Pill.transform.GetChild(i).gameObject;
                if (!pill.activeSelf)
                {
                    pill.SetActive(true);
                    pill.transform.position = weaponPlace.position;
                    pill.transform.rotation = weaponPlace.rotation;
                    pill.GetComponent<Weapons>().Select(true);
                    // Debug.Log("pill is in place");
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ResetPosition();
            Gun.transform.position = weaponPlace.position;
            Gun.transform.rotation = weaponPlace.rotation * Quaternion.Euler(0,180,0);
            Gun.GetComponent<Weapons>().Select(true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ResetPosition();
            Sword.transform.position = weaponPlace.position;
            Sword.transform.rotation = weaponPlace.rotation;
            Sword.GetComponent<Weapons>().Select(true);
        }
    }
    private void ResetPosition()
    {
        Gun.transform.position = GunPlace.position;
        Sword.transform.position = SwordPlace.position;
        Gun.GetComponent<Weapons>().Select(false);
        Sword.GetComponent<Weapons>().Select(false);
        GameObject pill;
        for (int i = 0; i < 5; i++)
        {
            pill=Pill.transform.GetChild(i).gameObject;
            if(pill.activeSelf== false)
            {
                rigidbody=pill.GetComponent<Rigidbody>();
                rigidbody.useGravity = false;
                pill.transform.position = PillPlace.position;
                pill.GetComponent<Weapons>().Select(true);
            }
        }
    }
}