using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != TagEnum.Player.ToString() && other.tag != TagEnum.Enemy.ToString() && other.tag != TagEnum.Hand.ToString())
        {
            Destroy(gameObject);
        }
    }
}
