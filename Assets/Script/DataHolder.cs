using JetBrains.Annotations;
using UnityEngine;

public static class DataHolder
{
    public static int money;
    public static int recordPoints;
    public static int indexActiveLocation = 0;
    public static int indexActiveSkin = 0;

    public static bool firstStart;
    public static bool[] activeSkins = new bool[3];
    public static bool[] activeLocations = new bool[3];

    public static void AddMoney(int value)
    {
        money += value;
    }
    public static bool TrySpendMoney(int value)
    {
        if (money < value)
            return false;
        money -= value;
        return true;
    }
    public static void LoadData(Save save)
    {
        money = save.money;

        indexActiveLocation = save.indexLocation;
        indexActiveSkin = save.indexSkin;

        activeSkins = save.SkinActiveItems;
        activeLocations = save.LocationActiveItems;

        recordPoints = save.recordPoints;
    }
}
