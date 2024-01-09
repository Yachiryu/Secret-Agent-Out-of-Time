using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogos_Scrip : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed = 1.0f;
    int index;


    void Start()
    {
        dialogueText.text = string.Empty;
        //StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray()) 
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }

    }
    public void NextLine()
    {
        if(index < lines.Length - 1) 
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}