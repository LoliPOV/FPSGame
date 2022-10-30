using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _turretGear, _turretHead;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _turretGear.LookAt(new Vector3(transform.position.x, _player.transform.position.y, _player.position.z));
    }
}
