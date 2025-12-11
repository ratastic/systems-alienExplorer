using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class NotebookManager : MonoBehaviour
{
    public static NotebookManager Instance;

    public string savedNoteText = "";
    public TMP_InputField noteInput;

    public List<int> capturedPhotoIDs = new List<int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "End")
        {
            noteInput.readOnly = true;
        }
        else
        {
            noteInput.readOnly = false;
        }

        if (SceneManager.GetActiveScene().name == "Instructions")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "TitlePage")
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}