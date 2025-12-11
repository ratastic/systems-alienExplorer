using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;

public class NotebookManager : MonoBehaviour
{
    public static NotebookManager Instance;

    public string savedNoteText = "";
    public TMP_InputField noteInput;


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
    }

}
/* notebook as a singleton: can access using "NotebookManager.Instance.savedNoteText"
 only needs to exist in the game once, which is in the main scene,
dont need to add to another scene in notebook manager :)
 */
