using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField]
    private GameObject _bloodDecal;
    
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

        if(Physics.Raycast(ray, out hit,Mathf.Infinity, 1 << 7))
        {
            Debug.Log(hit.collider.name);
           
         Health health = hit.transform.GetComponent<Health>();
            if(health != null)
            {
                Instantiate(_bloodDecal, hit.point, Quaternion.LookRotation(hit.normal));
                health.DamageHealth(10);
            }
             
              
            
        }
    }
}
