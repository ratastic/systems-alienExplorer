using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Notebook : MonoBehaviour
{

    public GameObject noteCanvas;
    public TMP_InputField noteInput;
    public Button closeButton;

    public bool noteOpen = false;
    //private bool canCloseTablet = true;
    private string savedNoteText = "";
    public GameObject playerController;
    private MonoBehaviour[] playerScripts;
    public CamController cc;
    public GameObject frameButton;
    public Animator nbAnim;

    void Start()
    {
        //noteCanvas.SetActive(false);
        closeButton.onClick.AddListener(CloseNote);
        playerScripts = playerController.GetComponents<MonoBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) // to toggle note on, 
        {
            if (!noteOpen)
                OpenNote();
        }
    }

    void OpenNote()
    {
        nbAnim.SetBool("slideIn", true);
        frameButton.SetActive(false);

        //noteCanvas.SetActive(true);
        noteOpen = true;

        cc.imageCanvas.SetActive(false);
        cc.textBox.SetActive(true);

        //cursor on when opened note since goldplayercontroller turns it off
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //additional scripts turned off in case pam or vega wanna put in ******
        foreach (var script in playerScripts)
        {
            script.enabled = false;
        }


        noteInput.text = savedNoteText;
        noteInput.ActivateInputField();
    }

    void CloseNote()
    {
        StartCoroutine(ClosingNoteAnim());
        //nbAnim.SetBool("slideOut", true);
        frameButton.SetActive(true);
        //noteCanvas.SetActive(false);
        noteOpen = false;

        //Save the note text
        savedNoteText = noteInput.text;

        //Restore cursor state to off goldplayercontroller
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Re-enable player scripts **** We can take this off but i wasnt sure
        foreach (var script in playerScripts)
        {
            script.enabled = true;
        }
    }

    private IEnumerator ClosingNoteAnim()
    {
        while (true)
        {
            nbAnim.SetBool("slideOut", true);
            nbAnim.SetBool("isIdle", true);
            nbAnim.SetBool("slideIn", false);
        }
    }
}
