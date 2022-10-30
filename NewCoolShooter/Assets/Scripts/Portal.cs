using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeReference] private GameObject _portalToTeleport;
    private Transform _portalToTeleportTransform;

    private void Start()
    {
        _portalToTeleportTransform = _portalToTeleport.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        TeleportEntety(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == TagEnum.Player.ToString())
        {
            other.GetComponent<CharacterController>().enabled = true;
            other.GetComponent<CharMovment>().enabled = true;
        }
    }


    private void TeleportEntety(Collider other)
    {
        if(other.tag == TagEnum.Player.ToString())
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.GetComponent<CharMovment>().enabled = false;
        }
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));       
        other.transform.position = new Vector3(_portalToTeleportTransform.position.x + 4, _portalToTeleportTransform.position.y, _portalToTeleportTransform.position.z);
        Debug.Log("Местоположение партала: " + _portalToTeleportTransform.position + " Сущность: " + other.transform);
    }
}
