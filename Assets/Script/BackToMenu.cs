using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
