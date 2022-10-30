using UnityEngine;

public class FlyBot : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _forceToUp;
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;

    private float _forceToUpToRemeber;
    private float _speedToRemember;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(TagEnum.Player.ToString()).GetComponent<Transform>();
        _forceToUpToRemeber = _forceToUp;
        _speedToRemember = _speed;
    }

    void Update()
    {
        Fly();
        MoveBot();
    }

    private void Fly()
    {
        if (transform.position.y > _player.position.y)
        {
            _forceToUp = 0;
        }
        else
        {
            _forceToUp = _forceToUpToRemeber;
            transform.Translate(Vector3.up * _forceToUp * Time.deltaTime);
        }

        if ((transform.position.y - _player.position.y) > _player.position.y)
        {
            _forceToUp = _forceToUpToRemeber;
            transform.Translate(Vector3.down * _forceToUp * Time.deltaTime);
        }

        Vector3 relativePos = _player.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

    private void MoveBot()
    {       
        float vectorX = _player.position.x - transform.position.x;
        float vectorZ = _player.position.z - transform.position.z;
        bool negativeX = vectorX < -_stopDistance;
        bool negativeZ = vectorZ < -_stopDistance;

        if ((vectorX <= _stopDistance && !negativeX) && (vectorZ <= _stopDistance && !negativeZ))
        {
            _speed = 0;
        }
        else
        {
            _speed = _speedToRemember;
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
