using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StampManager : MonoBehaviour
{
    public GameObject reject;
    public GameObject approve;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageRegistry.Instance.savedImages.Count >= 30)
        {
            Debug.Log("enough");
            approve.SetActive(true);
        }

        if (ImageRegistry.Instance.savedImages.Count <= 30)
        {
            Debug.Log("not enough");
            reject.SetActive(true);
        }
    }
}
