using TMPro;
using UnityEngine;

public class UltraKill : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMP;
    private EnemyHealt[] _enemyHealt;

    private float _enemeDeadCounter;
    private double _sColor;
    private float _time = 8f;
    private float _timer = 0f;
    private double _alpha = 1;
    private void Start()
    {
        _timer = _time;
    }
    private void Update()
    {
        if (TryFind(FindObjectsOfType<EnemyHealt>()))
        {
            for (int i = 0; i < _enemyHealt.Length; i++)
            {
                if (_enemyHealt[i].Death())
                {
                    _enemeDeadCounter++;
                    Debug.Log("ß ÁËßÒÜ ÑÄÎÕ: " + _enemeDeadCounter);
                }
            }
        }
        StartTimer();
        CoolTexts();
    }

    private bool TryFind(EnemyHealt[] enemyHealt)
    {

        if (enemyHealt == null) { return false; }
        else { _enemyHealt = enemyHealt; return true; }

    }

    private void CoolTexts()
    {
        var currentTimer = _time;
        if (_enemeDeadCounter >= 2)
        {
            _textMP.text = "À òû õàðîø";
            _timer = currentTimer;
        }
        if (_enemeDeadCounter >= 4)
        {
            _textMP.text = "Óëüòðà ìåãà õàðîø";
            if (_sColor != 1)
            {
                _sColor += 0.3 * Time.deltaTime;
            }
            else if (_sColor >= 1)
            {
                _sColor = 1;
            }
            _timer = currentTimer;
            _textMP.color = Color.HSVToRGB(1, (float)_sColor, (float)_sColor);
        }
        if (_timer <= 0)
        {
            _timer = 0;
            _alpha -= 0.3 * Time.deltaTime;
            _textMP.alpha -= (float)_alpha;
        }
        else
        {
            _textMP.alpha = 1;
        }
    }
    private void StartTimer()
    {

        _timer -= Time.deltaTime;
    }
}
