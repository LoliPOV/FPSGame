using UnityEngine;

public class PickUpBottle : MonoBehaviour
{
    [SerializeField] private HealPills healPills;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == TagEnum.Player.ToString())
        {
            healPills.enabled = true;
            healPills.PillsPickUp(true);
            Destroy(gameObject);
        }
    }
}
