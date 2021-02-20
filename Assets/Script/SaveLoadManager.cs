using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public Save sv = new Save();
    public static SaveLoadManager instance;

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
            Debug.Log(PlayerPrefs.GetString("Save"));

            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));

            DataHolder.firstStart = false;
            LoadGame();

            Debug.Log("save was loaded " + sv.money);
        }
    }
    public void SaveGame()
    {
        Debug.Log("Begin saving");

        sv.money = DataHolder.money;
        sv.indexLocation = DataHolder.indexActiveLocation;
        sv.indexSkin = DataHolder.indexActiveSkin;
        sv.LocationActiveItems = DataHolder.activeLocations;
        sv.SkinActiveItems = DataHolder.activeSkins;
        sv.recordPoints = DataHolder.recordPoints;

        PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
        PlayerPrefs.Save();

        Debug.Log("End saving " + sv.money);
    }


    public void LoadGame()
    {
        DataHolder.LoadData(sv);
    }


#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveGame();
        }
    }
#endif
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
