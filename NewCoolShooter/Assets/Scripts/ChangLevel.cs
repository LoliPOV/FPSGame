using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangLevel : MonoBehaviour
{
    [SerializeField] private string _sceneToChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagEnum.Player.ToString())
            SceneManager.LoadSceneAsync(_sceneToChange);
    }
}
