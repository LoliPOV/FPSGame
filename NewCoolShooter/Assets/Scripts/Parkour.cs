using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parkour : MonoBehaviour
{
    [SerializeField] private float _hookDistance;
    [SerializeField] private float _hookForce;

    private Rigidbody _playerRigidbody;
    private bool _haveHoot;   
    private RaycastHit hitData;

    private void Start()
    {
        _playerRigidbody = transform.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        FireRay();
        if (hitData.transform.tag == TagEnum.Connection.ToString() && Input.GetKey(KeyCode.F) && _haveHoot)
        {
            transform.position += (hitData.transform.position - transform.position).normalized * _hookForce /** Time.deltaTime*/;
            Debug.Log(true);
        }
    }

    private void FireRay()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Physics.Raycast(ray, out hitData);

        float x = hitData.transform.position.x - _playerRigidbody.transform.position.x;
        float y = hitData.transform.position.y - _playerRigidbody.transform.position.y;

        if (x <= _hookDistance && y <= _hookDistance)
            _haveHoot = true;
        else
            _haveHoot = false;
    }
}
