using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealt : MonoBehaviour
{
    [SerializeField] private float _playerHelth;
    [SerializeField] private float _bulletDamage;
    [SerializeField] private float _meleeAtack;
    [SerializeField] private float _bigBullet;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private int _levelToLoade;
    [SerializeField] private GameObject _videoPanel;
    [SerializeField] private GameObject _music;
    private void Start()
    {
        _hpSlider.maxValue = _playerHelth;
        _hpSlider.value = _playerHelth;
    }

    private void Update()
    {
        if(_hpSlider.value <= 0)
        {
            Death();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        float damage = other.tag == TagEnum.Bullet.ToString() ? _bulletDamage : (other.tag == TagEnum.Big_Bullet.ToString() ? _bigBullet : 0);
        ReduceHealth(damage);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == TagEnum.MeleeAtack.ToString())
        {
            ReduceHealth(_meleeAtack);
        }
    }

    private void Death()
    {
        _videoPanel.SetActive(true);
        _music.SetActive(false);
        var charMovment = GetComponent<CharMovment>();
        charMovment.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(_levelToLoade);
    }

    private void ReduceHealth(float damage)
    {
        _hpSlider.value -= damage;
    }

    public void AddHealth(float health)
    {
        _hpSlider.value += health;
    }
}
