using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    public GameObject dialogBox;
    public GameObject nameBox;
    public int currentLine;
    public string[] dialogLines;
    public static DialogManager Instance;
    private bool justStarted;
    void Start()
    {
        dialogText.text = dialogLines[currentLine];
        Instance = this;
    }

    void Update()
    {
        if(dialogBox.activeInHierarchy)
        {
            if(Input.GetButtonUp("Fire1"))
            {
                if(!justStarted)
                {
                    currentLine++;

                    if(currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        GameManager.Instance.dialogActive = false;
                    }
                    else
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }

                } 
                else
                {
                    justStarted = false;
                }
            }
        }
    }
    public void showDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        justStarted = true;
        nameBox.SetActive(isPerson);

        GameManager.Instance.dialogActive = true;
    }
    public void CheckIfName()
    {
        if(dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
