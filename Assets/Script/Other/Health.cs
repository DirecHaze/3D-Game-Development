using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _health;

    public void DamageHealth(int Damage)
    {
        Debug.Log("Hit");
        _health -= Damage;
        if(_health == 0)
        {
            
            Destroy(this.gameObject);
        }
    }
}
