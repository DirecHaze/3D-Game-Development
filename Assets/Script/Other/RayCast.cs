using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
   
    
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.F))
        {
            shoot();
        }
    }
    private void shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3 (0.5f,0.5f,0));
       
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);
           
            hit.transform.GetComponent<Health>().DamageHealth(10);
             
              
            
        }
    }
}
