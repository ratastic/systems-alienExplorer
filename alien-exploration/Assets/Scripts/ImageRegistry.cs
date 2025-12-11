using System.Collections.Generic;
using UnityEngine;

public class ImageRegistry : MonoBehaviour
{
    public static ImageRegistry Instance;

    public List<Texture2D> savedImages = new List<Texture2D>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Save an image and return its ID
    public int RegisterImage(Texture2D tex)
    {
        savedImages.Add(tex);
        return savedImages.Count - 1; // ID of added image
    }

    // Retrieve a saved image by ID
    public Texture2D GetImage(int id)
    {
        return savedImages[id];
    }
}