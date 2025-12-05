using UnityEngine;

public class NotebookManager : MonoBehaviour
{
    public static NotebookManager Instance;

    public string savedNoteText = "";

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
}
/* notebook as a singleton: can access using "NotebookManager.Instance.savedNoteText"
 only needs to exist in the game once, which is in the main scene,
dont need to add to another scene in notebook manager :)
 */
