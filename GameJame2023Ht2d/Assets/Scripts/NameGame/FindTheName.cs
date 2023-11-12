using TMPro;
using UnityEngine;
//using static UnityEditor.PlayerSettings;
//using System;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class FindTheName : MonoBehaviour
{
    // Start is called before the first frame update
    System.Random rnd = new System.Random();

    public GameObject square;
    public GameObject[,] buttons;
    public GameObject ParentPanel;
    public GameObject WinText;

    Vector2 buttonSize = new Vector2(100, 100);
    Vector2 spawnPoint = new Vector2(-460f, 250f);
    Vector2 previousButton;
    Vector2 direction = Vector2.zero;
    Vector2 namePos = Vector2.zero;
    Vector2 pos;

    bool firstLetter = true; 
    bool secondLetter = true;
    public bool win;

    int width = 10;
    int height = 7;
    int lettersInName;
    int horizontal = 0;
    int vertical = 1;
   
    char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();


    string name = "TIMMY";
    string clickedLetters; 

    void Start()
    {
        Cursor.visible = true;

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

        RandomizeNamePlacement();
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

    void AddName(int x, int y, int placement)
    {
        for (int i = 0; i < lettersInName; i++)
        {
            if (placement == horizontal)
            {
                buttons[x + i, y].GetComponentInChildren<TMP_Text>().text = name[i].ToString();
                //buttons[x + i, y].GetComponentInChildren<TMP_Text>().color = Color.red;


            }

            if (placement == vertical)
            {
                buttons[x, y + i].GetComponentInChildren<TMP_Text>().text = name[i].ToString();
                //buttons[x, y + i].GetComponentInChildren<TMP_Text>().color = Color.red;

            }

        }


    }

    public void CheckString()
    {
        if(clickedLetters == name)
        {
            win = true;
            WinText.SetActive(true);

            foreach(var obj in buttons)
            {
                obj.SetActive(false);
            }
            //LevelManager.level = 2;
            //SceneManager.LoadScene("Windows");

        }
    }

    void RandomizeNamePlacement()
    {
        int placement = rnd.Next(horizontal, vertical+1);
        int x = 0, y = 0;

        if(placement == horizontal)
        {
            x = rnd.Next(0, width - name.Length);
            y = rnd.Next(0, height);
        }
        else if(placement == vertical)
        {
            x = rnd.Next(0, width);
            y = rnd.Next(0, height - name.Length);
        }

        AddName(x, y, placement);

    }
}