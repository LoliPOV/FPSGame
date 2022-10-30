using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStage : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private GameObject[] _firstEnemyWave;
    [SerializeField] private StartLvlTrigger _startLvlTrigger;

    private bool _isTriggered;
    private int _enemies;
    private bool _stageEnds;

    private void Update()
    {
        _isTriggered = _startLvlTrigger.TriggerReturn;
        _enemies = _startLvlTrigger.Enemies;

        if (_isTriggered)
        {
            SpawnEnemyWaves();
        }

        if (_doorAnimator != null)
        {
            PlayAnimation();
        }

    }
    private void PlayAnimation()
    {
        _doorAnimator.SetBool("isTriggerd", _isTriggered);
        _doorAnimator.SetInteger("noEnemies", _enemies);
    }

    private void SpawnEnemyWaves()
    {
        for (int i = 0; i < _firstEnemyWave.Length; i++)
            _firstEnemyWave[i].SetActive(true); 
    }

    public bool IsTriggered => _isTriggered;
    public int NoEnemies => _enemies;
    public bool StageSatus => _stageEnds;
}
