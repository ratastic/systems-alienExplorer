using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabletInfoDisplay : MonoBehaviour
{
    public Image images;
    public TMP_InputField notes;

    public Vector2 imagesPosition = new Vector2(213.4f, 88.1f);
    public Vector2 notesPosition = new Vector2(101.7f, 92.1f);

    private void Awake()
    {
        MoveContents();
    }

    private void MoveContents()
    {
        GameObject imagesObj = GameObject.FindGameObjectWithTag("pictureDisplay");
        if (imagesObj != null)
        {
            images = imagesObj.GetComponent<Image>();
            imagesObj.transform.GetChild(0).gameObject.SetActive(true);

            RectTransform imgRect = images.GetComponent<RectTransform>();
            imgRect.anchoredPosition = imagesPosition;
        }

        GameObject notesObj = GameObject.FindGameObjectWithTag("notesDisplay");
        if (notesObj != null)
        {
            notes = notesObj.GetComponent<TMP_InputField>();

            RectTransform notesRect = notes.GetComponent<RectTransform>();
            notesRect.anchoredPosition = notesPosition;
        }
    }
}