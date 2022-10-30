using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private bool _mainMenu;



    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (_mainMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            ExitToMenu();
        }

    }

    public void ExitToMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadSceneAsync(0);
    }
}
