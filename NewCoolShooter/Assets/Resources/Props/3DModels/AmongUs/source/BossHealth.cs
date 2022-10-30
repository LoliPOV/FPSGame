using UnityEngine.UI;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] GameObject _bossHealth;
    [SerializeField] private float _enemyGetHealth;

    private void Start()
    {
        _bossHealth.SetActive(true);
    }

    public void ApplyDamage(float damage)
    {
        _bossHealth.GetComponent<Slider>().value -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagEnum.DeflectedBullet.ToString())
        {
            _bossHealth.GetComponent<Slider>().value = 30;
        }
    }

    private void Update()
    {
        if (Death())
        {
            gameObject.SetActive(false);
            PlayerHealt playerHealt = GameObject.FindGameObjectWithTag(TagEnum.Player.ToString()).GetComponent<PlayerHealt>();
            playerHealt.AddHealth(_enemyGetHealth);
            Destroy(gameObject, 1f);
        }
    }

    public bool Death()
    {
        if (_bossHealth.GetComponent<Slider>().value <= 0)
        {
            _bossHealth.GetComponent<Slider>().value = 0;
            return true;
        }
        return false;
    }
}
