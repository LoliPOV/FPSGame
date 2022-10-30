using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDammage : MonoBehaviour
{
    [SerializeField] private float _damageToDeal = 10.0F;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == TagEnum.Enemy.ToString())
            other.transform.GetComponent<EnemyHealt>().ApplyDamage(_damageToDeal);
    }
}
