using System.Linq;
using UnityEngine;

public class GunSwap : MonoBehaviour
{
    [SerializeField] private float timeBtwSlap;
    [SerializeField] private float startTimeBtwSlap;
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private GameObject _hand;

    private GameObject _currentGun;

    private void Update()
    {
        SwapGun();

        if (timeBtwSlap <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hand.SetActive(true);
                timeBtwSlap = startTimeBtwSlap; //Темп стрельбы
            }          
        }
        else
        {
            timeBtwSlap -= Time.deltaTime; //Темп стрельбы
        }

        if(timeBtwSlap <= 0)
        {
            _hand.SetActive(false);
        }
    }

    private void SwapGun()
    {
        var allKeys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
        foreach (var key in allKeys)
        {
            if (Input.GetKeyDown(key))
            {
                switch (((byte)key))
                {
                    case 49:
                        _currentGun = GameObject.FindGameObjectWithTag(TagEnum.Weapon.ToString());
                        _currentGun.SetActive(false);
                        _weapons[0].SetActive(true);                        
                        break;
                    case 50:
                        if(key != KeyCode.LeftControl)
                        {
                            _currentGun = GameObject.FindGameObjectWithTag(TagEnum.Weapon.ToString());
                            _currentGun.SetActive(false);
                            _weapons[1].SetActive(true);
                        }
                        break;
                    case 51:
                        if (key != KeyCode.LeftControl)
                        {
                            _currentGun = GameObject.FindGameObjectWithTag(TagEnum.Weapon.ToString());
                            _currentGun.SetActive(false);
                            _weapons[2].SetActive(true);
                        }
                        break;
                }
            }
        }
    }
}
