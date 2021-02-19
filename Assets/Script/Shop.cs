using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct ShopItem
{
    public TMP_Text textOnButton;
    public Button button;
    public int price;
    public bool isBought;
}
public class Shop : MonoBehaviour
{
    [SerializeField] private TMP_Text balanceText;
    [SerializeField] private ShopItem[] Locations;
    [SerializeField] private ShopItem[] Skins;

    private string BoughtItemText = "Choose";

    private void Awake()
    {

        if (DataHolder.firstStart != true)
        {
            for (int i = 0; i < Locations.Length; i++)
            {
                Locations[i].isBought = DataHolder.activeLocations[i];
            }
            for (int i = 0; i < Skins.Length; i++)
            {
                Skins[i].isBought = DataHolder.activeSkins[i];
            }
        }
        DataHolder.activeLocations[0] = true;
        DataHolder.activeSkins[0] = true;

        UpdateBalance();
        UpdateLocationItems();
        UpdateSkinItems();
    }

    private void UpdateBalance()
    {
        balanceText.text = "Balance:" + DataHolder.money + "$";
    }

    public void SkinButtonClick(int indexSkin)
    {
        if (DataHolder.activeSkins[indexSkin] == true)
        {
            DataHolder.indexActiveSkin = indexSkin;
            UpdateSkinItems();
            return;
        }
        if (DataHolder.activeSkins[indexSkin] != true && DataHolder.TrySpendMoney(Skins[indexSkin].price))
        {
            DataHolder.indexActiveSkin = indexSkin;
            Skins[indexSkin].isBought = true;
            DataHolder.activeSkins[indexSkin] = true;
            UpdateSkinItems();
            UpdateBalance();
        }
        else
        {
            Debug.Log("нет денег");
        }
    }
    public void LocationButtonClick(int indexLocation)
    {
        if (DataHolder.activeLocations[indexLocation] == true)
        {
            DataHolder.indexActiveLocation = indexLocation;
            UpdateLocationItems();
            return;
        }
        if (DataHolder.activeLocations[indexLocation] != true && DataHolder.TrySpendMoney(Locations[indexLocation].price))
        {
            DataHolder.indexActiveLocation = indexLocation;
            Locations[indexLocation].isBought = true;
            DataHolder.activeLocations[indexLocation] = true;
            UpdateLocationItems();
            UpdateBalance();
        }
        else
        {
            Debug.Log("нет денег");
        }
    }

    private void UpdateSkinItems()
    {
        for (int i = 0; i < Skins.Length; i++)
        {

            if (DataHolder.activeSkins[i] == true)
                Skins[i].textOnButton.text = BoughtItemText;
            else
                Skins[i].textOnButton.text = Skins[i].price + "$";

            if (DataHolder.indexActiveSkin == i || (DataHolder.money < Skins[i].price && !Skins[i].isBought))
                Skins[i].button.interactable = false;
            else /*if (!Skins[i].isBought && DataHolder.money >= Skins[i].price)*/
                Skins[i].button.interactable = true;

        }
    }



    private void UpdateLocationItems()
    {
        for (int i = 0; i < Locations.Length; i++)
        {
            if (DataHolder.activeLocations[i] == true)
                Locations[i].textOnButton.text = BoughtItemText;
            else
                Locations[i].textOnButton.text = Locations[i].price + "$";

            if (DataHolder.indexActiveLocation == i || (DataHolder.money < Locations[i].price && !Locations[i].isBought))
                Locations[i].button.interactable = false;
            else /*if (Locations[i].isBought)*/
                Locations[i].button.interactable = true;

        }
    }

}