using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip clip1, clip2;
    private AudioSource _audioSource;
    private GameObject[] _enemiesOnLevel;
    private int _enemies;
    private bool _isPlayed = false;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _enemiesOnLevel = GameObject.FindGameObjectsWithTag(TagEnum.Enemy.ToString());
        _enemies = _enemiesOnLevel.Length;

        if (_enemies == 0 && !_isPlayed)
        {
            _audioSource.clip = clip1;
            _audioSource.Play();
            _isPlayed = true;
        }
        else if(_enemies != 0 && _isPlayed)
        {
            _audioSource.clip = clip2;
            _audioSource.Play();
            _isPlayed = false;
        }
    }
}
