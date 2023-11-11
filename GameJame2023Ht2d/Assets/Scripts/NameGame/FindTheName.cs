using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class FindTheName : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject square;
    public GameObject[,] buttons;
    public GameObject ParentPanel;

    Vector2 buttonSize = new Vector2(100, 100);
    Vector2 spawnPoint = new Vector2(-500f, 300f);
    Vector2 previousButton;
    Vector2 direction = Vector2.zero;
    Vector2 namePos = Vector2.zero;
    Vector2 pos;

    bool firstLetter = true; 
    bool secondLetter = true;
    bool win;

    int width = 10;
    int height = 7;
    int lettersInName;
    char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    string clickedLetters; 

    System.Random rnd = new System.Random();

    string name = "TIMMY";

    void Start()
    {
        buttons = new GameObject[width, height];

        lettersInName = name.Length;


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int nr = rnd.Next(0, alphabet.Length);

                pos = new Vector2(spawnPoint.x + i * buttonSize.x, spawnPoint.y - j * buttonSize.y);
                buttons[i, j] = Instantiate(square, pos, Quaternion.identity, ParentPanel.transform);
                buttons[i, j].transform.localPosition = new Vector3(pos.x, pos.y, 0);
                buttons[i, j].GetComponent<ButtonScript>().pos = new Vector2(i, j);
                buttons[i, j].GetComponent<ButtonScript>().owner = this;
                buttons[i, j].GetComponentInChildren<TMP_Text>().text = alphabet[nr].ToString();
            }
        }
        AddName();
    }

    public void Check(ButtonScript obj)
    {
        clickedLetters += obj.GetComponentInChildren<TMP_Text>().text;
        CheckString();

        if (win)
        {
            Debug.Log("You win!");
        }

        if (firstLetter)
        {
            firstLetter = false;
            previousButton = obj.pos;
        }
        else if (secondLetter)
        {
            secondLetter = false;

            direction = new Vector2(obj.pos.x - previousButton.x, obj.pos.y - previousButton.y);

            if (direction.x > 1 || direction.x < -1) { ResetLetters(); }

            if (direction.y > 1 || direction.y < -1) { ResetLetters(); }

            previousButton = obj.pos;
        }
        else
        {
            if (obj.pos == new Vector2(previousButton.x + direction.x, previousButton.y + direction.y)) { }
            else
            {
                ResetLetters();
            }

            previousButton = obj.pos;
        }


    }
    void ResetLetters()
    {
        firstLetter = true;
        secondLetter = true;

        foreach (var obj in buttons)
        {
            obj.GetComponent<ButtonScript>().ResetButton();
        }

        clickedLetters = "";
    }

    void AddName()
    {
        for (int i = 0; i < lettersInName; i++)
        {
            buttons[(int)namePos.x + i, (int)namePos.y].GetComponentInChildren<TMP_Text>().text = name[i].ToString();
        }
    }

    public void CheckString()
    {
        if(clickedLetters == name)
        {
            win = true;
            LevelManager.level = 2;
            SceneManager.LoadScene("Windows");

        }
    }
}