using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogScript : MonoBehaviour
{
    public static DialogScript Instance;
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public string[] dialogLines;
    public int currentLine;
    private bool justStarted;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if(GameManager.Instance.dialogActive)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(!justStarted)
                {
                currentLine++;

                if(currentLine >= dialogLines.Length)
                {
                    dialogBox.SetActive(false);

                    GameManager.Instance.dialogActive = false;
                    return;
                }
                else
                {
                    dialogText.text = dialogLines[currentLine];
                }
                }
            }
            else
            {
                justStarted = false;
            }
        }
    }
    public void ShowDialog(string[] newLines, bool shouldWaitForNextClick)
    {
        dialogLines = newLines;

        currentLine = 0;

        dialogText.text = dialogLines[currentLine];

        dialogBox.SetActive(true);

        justStarted = shouldWaitForNextClick;

        GameManager.Instance.dialogActive = true;
    }
}

