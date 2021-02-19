using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string[] namesScenesOnBuild;
    public void StartGame()
    {
        Debug.Log(DataHolder.indexActiveLocation);
        int index = DataHolder.indexActiveLocation;
        Debug.Log(namesScenesOnBuild[index]);
        SceneManager.LoadScene(namesScenesOnBuild[index]);

    }
}
