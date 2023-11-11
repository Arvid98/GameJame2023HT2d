using UnityEngine;

public class FindTheName : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject square;
    Vector2 buttonSize = new Vector2(100, 100);
    Vector2 spawnPoint = new Vector2(-500f, 300f);
    public GameObject[,] buttons;
    bool firstLetter = true;
    bool secondLetter = true;
    public int letterSelected = 0;
    public GameObject ParentPanel;
    Vector2 previousButton;
    Vector2 direction = Vector2.zero;
    int width = 5;
    int height = 5;

    void Start()
    {
        buttons = new GameObject[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 pos = new Vector2(spawnPoint.x + i * buttonSize.x, spawnPoint.y - j * buttonSize.y);
                buttons[i, j] = Instantiate(square, pos, Quaternion.identity, ParentPanel.transform);
                buttons[i, j].transform.localPosition = new Vector3(pos.x, pos.y, 0);
                buttons[i, j].GetComponent<ButtonScript>().pos = new Vector2(i, j);
                buttons[i, j].GetComponent<ButtonScript>().owner = this;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Check(ButtonScript obj)
    {
        if (firstLetter)
        {
            firstLetter = false;
            previousButton = obj.pos;
        }
        else if (secondLetter)
        {
            secondLetter = false;

            direction = new Vector2(obj.pos.x - previousButton.x,obj.pos.y - previousButton.y);

            if (direction.x > 1 || direction.x < -1) { ResetLetters(); }

            if (direction.y > 1 || direction.y < -1) { ResetLetters(); }

            previousButton = obj.pos;
        }
        else
        {
            if (obj.pos == new Vector2(previousButton.x+direction.x , previousButton.y + direction.y)) { }
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
    }
}