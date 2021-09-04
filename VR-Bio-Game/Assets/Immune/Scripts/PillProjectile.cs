using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float m_Thurst = 10;
    Rigidbody rigidbody;
    AudioSource pillAudioSource;
    Weapons wep;


    public GameObject pillInitialPosition;
    public GameObject explosionEffect;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        wep = GetComponent<Weapons>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        pillAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Press A to throw the pill farward and activate the gravity
        if (Input.GetKeyDown(KeyCode.A) && gameObject.GetComponent<Weapons>().isSelected() == true)
        {
            rigidbody.AddForce(0, m_Thurst, m_Thurst * 2, ForceMode.Impulse);
            rigidbody.useGravity = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if ( wep.isSelected() && (collision.gameObject.layer == 6 || collision.gameObject.layer == 7))
        {
            collisionLogic();
            resetPill();
        }

    }
    private void resetPill()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        //FOR 3D GAMING
        //this.transform.position = pillInitialPosition.transform.position;
        //this.transform.rotation = pillInitialPosition.transform.rotation;

        //FOR VR
        this.transform.position = new Vector3(0, 1, 0);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        rigidbody.isKinematic = true ;
        rigidbody.useGravity = false;
        GetComponent<Weapons>().Select(false);
    }
    private void collisionLogic()
    {
        pillAudioSource.Play();
        GameObject explosion;
        explosion = explosionEffect.gameObject;
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        explosion.SetActive(true);
        explosion.transform.position = position;
        explosion.transform.rotation = rotation;
    }
}
