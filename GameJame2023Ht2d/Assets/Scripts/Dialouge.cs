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
            lines[0] = "BOSS: Hello Mr.Hackerman, you need to hack ASAP";
            lines[1] = "YOU: Yes sir boss sir!";
            LevelManager.level = 1;
        }
        else if (LevelManager.level == 1)
        {
            lines[0] = "BOSS: Gj, next hack plz";
            lines[1] = "YOU: :c";
            LevelManager.level = 2;
        }
        else if(LevelManager.level == 2) 
        {
            lines[0] = "BOSS: blablablabla";
            lines[1] = "YOU: FUCK U";
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
