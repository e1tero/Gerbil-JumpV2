using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public Save sv = new Save();
    public SaveLoadManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Save"))
        {
            DataHolder.firstStart = true;
            return;
        }
        else
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));
            DataHolder.firstStart = false;
            Debug.Log("save was loaded");
            LoadGame();
        }
    }
    public void SaveGame()
    {
        sv.money = DataHolder.money;
        sv.indexLocation = DataHolder.indexActiveLocation;
        sv.indexSkin = DataHolder.indexActiveSkin;
        sv.LocationActiveItems = DataHolder.activeLocations;
        sv.SkinActiveItems = DataHolder.activeSkins;
        sv.recordPoints = DataHolder.recordPoints;
    }


    public void LoadGame()
    {
        DataHolder.LoadData(sv);
    }


#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        SaveGame();
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        SaveGame();
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
    }
}

[System.Serializable]
public class Save
{
    public int money;

    public int indexLocation;
    public int indexSkin;

    public bool[] LocationActiveItems;
    public bool[] SkinActiveItems;
    public int recordPoints;
}
