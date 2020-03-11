using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmusLiike : MonoBehaviour
{
    private float nopeus=40;
    
    public int tuhoudu;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward*nopeus;
        Object.Destroy(gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
