using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Instruction : MonoBehaviour
{
    private int _number;
    public Text text;
    public GameObject textObject;
    public GameObject hand;
    public GameObject blackPanel;
    public Building building;
    public GameObject pointer;
    public GameObject firstBoost;
    public GameObject secondBoost;
    public GameObject thirdBoost;
    public GameObject gear;

    void Start()
    {
        _number = 0;
        Time.timeScale = 0;
    }
    
    public void ButtonClick()
    {
        if (_number == 0)
        {
            _number = 1;
            text.text = "When you tap the screen, you move up";
        }
        
        else if (_number == 1)
        {
            blackPanel.SetActive(false);
            textObject.SetActive(false);
            hand.SetActive(true);
            _number++;
        }

        else if (_number == 2 || _number == 3)
        {
            building.MoveDown();
            _number++;
        }
        
        else if (_number == 4)
        {
            textObject.SetActive(true);
            text.text = "Each click you get one point";
            pointer.SetActive(true);
            hand.SetActive(false);
            blackPanel.SetActive(true);
            _number++;
        }
        
        else if (_number == 5 || _number == 6)
        {
            blackPanel.SetActive(false);
            textObject.SetActive(false);
            building.MoveDown();
            _number++;
        }
        
        else if (_number == 7)
        {
            pointer.SetActive(false);
            blackPanel.SetActive(true);
            textObject.SetActive(true);
            text.text = "Your task is not to fly outside the ship";
            _number++;
        }
        
        else if (_number == 8)
        {
            text.text = "Character speed increases with every second ";
            _number++;
        }
        
        else if (_number == 9)
        {
            text.text = "On the way, you can catch objects that will interfere with you";
            firstBoost.SetActive(true);
            secondBoost.SetActive(true);
            thirdBoost.SetActive(true);
            _number++;
        }
        
        else if (_number == 10)
        {
            text.text = "Also on the way you may come across gears";
            firstBoost.SetActive(false);
            secondBoost.SetActive(false);
            thirdBoost.SetActive(false);
            gear.SetActive(true);
            _number++;
        }
        
        else if (_number == 11)
        {
            text.text = "By collecting them you get points that you can spend in the shop";
            _number++;
        }
        
        else if (_number == 12)
        {
            text.text = "That's all, good luck with your game! ";
            gear.SetActive(false);
            _number++;
        }
        
        else if (_number == 13)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
