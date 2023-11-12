using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }
    private void OnEnable()
    {
        textComponent.text = string.Empty;
        lines = new string[10];
        if (LevelManager.level == 0)
        {
            lines[0] = "BOSS: Hello Mr.Hackerman, you need to hack ASAP. Open up NSM and hack the good guy Timmy Burch! >:)";
            lines[1] = "YOU: Yes sir boss sir!";
            LevelManager.level = 1;
        }
        else if (LevelManager.level == 2)
        {
            lines[0] = "BOSS: Gj, now go to the World Wide Web and collect all the data from this poor little guy";
            lines[1] = "YOU: Muhahahahha!";
            LevelManager.level = 3;
        }
        else if(LevelManager.level == 4) 
        {
            lines[0] = "BOSS: Nice job Mr.Hackerman! You are done now, but just to be a little more devious and evil, lets install some nasty viruses on his computer.";
            lines[1] = "YOU: Sounds like a plan B)";
            LevelManager.level = 5;
        }
        else if(LevelManager.level == 6)
        {
            lines[0] = "BOSS: Good job today Mr.Hackerman, you can turn off the computer now and collect your pay at the reception :)";
            lines[1] = "YOU: Najs";
        }
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                //StopAllCoroutines();
                //textComponent.text = lines[index];
            }
        
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Append a newline character to the existing text

        
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text += "\n";
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
