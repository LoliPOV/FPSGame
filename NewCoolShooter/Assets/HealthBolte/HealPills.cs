using UnityEngine;

public class HealPills : MonoBehaviour
{
    private bool _isRaised;
    [SerializeField] private GameObject _pillsUI;
    [SerializeField] private float _heatlhToGet = 500;
    private PlayerHealt playerHealt;
    private bool _isUsed = false;
    private void Start()
    {
        playerHealt = GetComponent<PlayerHealt>();
    }

    private void Update()
    {
        if (_isRaised)
        {
            _pillsUI.SetActive(false);
        }
        if (!_isUsed && _isRaised)
        {
            if (Input.GetKey(KeyCode.R))
            {
                playerHealt.AddHealth(_heatlhToGet);
                _pillsUI.SetActive(true);
                _isUsed = true;
                _isRaised = false;
            }
        }
    }

    public void PillsPickUp(bool isRaised)
    {
        _isRaised = isRaised;
    }
}
