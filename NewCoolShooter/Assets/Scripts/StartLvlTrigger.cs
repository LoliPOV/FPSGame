using UnityEngine;

public class StartLvlTrigger : MonoBehaviour
{
    private bool _triggered;
    private GameObject[] _enemiesOnLevel;
    private int _enemies;  

    private void Update()
    {
        _enemiesOnLevel = GameObject.FindGameObjectsWithTag(TagEnum.Enemy.ToString());
        _enemies = _enemiesOnLevel.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagEnum.Player.ToString())
            _triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == TagEnum.Player.ToString())
            _triggered = false;
    }
    public bool TriggerReturn => _triggered;
    public int Enemies => _enemies;
}
