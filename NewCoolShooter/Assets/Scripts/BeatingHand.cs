using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatingHand : MonoBehaviour
{
    [SerializeField] private GameObject _hand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == TagEnum.Big_Bullet.ToString() /*&& _nowTime*/)
        {
            var bullet = other.transform.GetComponent<Rigidbody>();
            bullet.transform.tag = TagEnum.DeflectedBullet.ToString();
            bullet.velocity = Vector3.zero;
            bullet.AddForce(_hand.GetComponent<Transform>().forward * 100, ForceMode.Impulse);
            //_hand.SetActive(false);
        }
    }
}
