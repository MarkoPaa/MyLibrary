using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class AlusControls : MonoBehaviour
{
    // Atribuutit
    public float nopeus;
    public float tilt;
    public Boundary boundary;

    public GameObject ammus;
    public Transform ammusSpawn;
    public float fireRate=0.25f;

    private float nextFire;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Ammu();
        }
    }

    void FixedUpdate() // Aluksen liikkuminen
    {
        transform.Translate(Vector3.forward * nopeus * Time.deltaTime);


        float moveHorizontal = Input.GetAxis("Horizontal");
       // float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * nopeus;

        GetComponent<Rigidbody>().position = new Vector3
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

    }



	// Use this for initialization
	void Start ()
    {
       
    }
	
	
    // Metodit
    void Ammu()
    {
        nextFire = Time.time + fireRate;
        Instantiate(ammus, ammusSpawn.position, ammusSpawn.rotation);
    }

}
