using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private GameObject[] _gunPosition;
    [SerializeField] private Transform[] _pointToSpawn;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fiteRate;
    [SerializeField] private float _power;
    [SerializeField] private float _toDestroy = 1.5f;
    [SerializeField] private bool _isFire = true;


    void Start()
    {
        StartCoroutine(ShootCorutine());
        _player = GameObject.FindGameObjectWithTag(TagEnum.Player.ToString()).GetComponent<Transform>();
    }

    private void Update()
    {
        LoockAtPlayer();
    }

    private void EnemyShoot()
    {
        if (_isFire)
        {
            for (int i = 0; i < _pointToSpawn.Length; i++)
            {
                GameObject bullet = Instantiate(_bullet, new Vector3(_pointToSpawn[i].position.x, _pointToSpawn[i].position.y, _pointToSpawn[i].position.z), transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(_pointToSpawn[i].forward * _power, ForceMode.Impulse);
                Destroy(bullet, _toDestroy);
            }
        }
    }

    private void LoockAtPlayer()
    {
        for (int i = 0; i < _gunPosition.Length; i++)
        {
            if(_gunPosition.Length != 0)
                _gunPosition[i].transform.LookAt(_player);
        }
    }

    IEnumerator ShootCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_fiteRate);
            EnemyShoot();
        }         
    }
}
