using UnityEngine.UI;
using UnityEngine;

public class RocetLauncher : MonoBehaviour
{
    [SerializeField] private Slider _fireSlider;
    [SerializeField] private float timeBtwShots;
    [SerializeField] private float startTimeBtwShots;
    [SerializeField] private Transform _firePlacePosition;
    [SerializeField] private GameObject _rocket;
    [SerializeField] private float _power;
    [SerializeField] private float _toDestroy = 1.5f;

    void Update()
    {
        _fireSlider.maxValue = startTimeBtwShots;
        _fireSlider.value = timeBtwShots;
        if (timeBtwShots <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                MissileFire();
                timeBtwShots = startTimeBtwShots; //Темп стрельбы
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime; //Темп стрельбы
        }
    }

    private void MissileFire()
    {
        GameObject bullet = Instantiate(_rocket, _firePlacePosition.position, _rocket.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(_firePlacePosition.forward * _power, ForceMode.Impulse);
        Destroy(bullet, _toDestroy);
    }
}
