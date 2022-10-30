using UnityEngine;

public class EndStage : MonoBehaviour
{
    [SerializeField] private StartStage _startStage;
    [SerializeField] private Animator _openDoorAnimation;
    private bool _status;

    private void Update()
    {
        _status = _startStage.IsTriggered;
        if (_openDoorAnimation != null)
        {
            PlayAnimation();
        }
    }

    private void PlayAnimation()
    {
        _openDoorAnimation.SetBool("isTriggerd", _startStage.IsTriggered);
        _openDoorAnimation.SetInteger("noEnemies", _startStage.NoEnemies);
    }
}
