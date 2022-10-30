using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExploision : MonoBehaviour
{
    [SerializeField] private float radius = 5.0F;
    [SerializeField] private GameObject _damageCollider;

    private void Start()
    {
        _damageCollider.GetComponent<SphereCollider>().radius = radius;
    }
    private void OnTriggerEnter(Collider other)
    {
        _damageCollider.SetActive(true);
    }
}
