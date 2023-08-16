using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public float weaponLength = 1f;

    private void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, -transform.up, out hit, weaponLength))
        {
            if (hit.transform.gameObject.name=="Enemy")
            {
                Debug.Log("hit");
            }
        }
    }
}
