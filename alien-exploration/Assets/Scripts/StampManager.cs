using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StampManager : MonoBehaviour
{
    public Animator rejectAnim;
    public Animator approveAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageRegistry.Instance.savedImages.Count >= 30)
        {
            Debug.Log("enough");
            approveAnim.SetBool("isApproved", true);
        }

        if (ImageRegistry.Instance.savedImages.Count <= 30)
        {
            Debug.Log("not enough");
            rejectAnim.SetBool("isRejected", true);
        }
    }
}
