using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateMole : MonoBehaviour
{
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Active_Mole")
        {
            //Debug.Log("bam!");
            collision.gameObject.tag = "Inactive_Mole";
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Inactive_Mole")
        {
            //Debug.Log("bam!");
            collision.gameObject.tag = "Active_Mole";
        }
    }
}
