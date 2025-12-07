using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeMovement : ObjectMovement
{
    [SerializeField] private float rollSpeed = 3f;
    private bool isMoving;
    public Transform camTF;

    void Start()
    {
        canRoll = false;
    }
    void Update()
    {
        //Debug.Log(canRoll);
        if (isMoving) return;

        if (Input.GetKey(KeyCode.W)) Assemble(camTF.forward);
        if (Input.GetKey(KeyCode.A)) Assemble(-camTF.right);
        if (Input.GetKey(KeyCode.S)) Assemble(-camTF.forward);
        if (Input.GetKey(KeyCode.D)) Assemble(camTF.right);
        
        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir) * .5f;
            var axis = Vector3.Cross(Vector3.up, dir);

            if (canRoll == true && isMoving == false)
            {
                transform.RotateAround(anchor, axis, rollSpeed * Time.deltaTime);
                //StartCoroutine(Roll(anchor, axis));
            }
        }
    }

    // IEnumerator Roll(Vector3 anchor, Vector3 axis)
    // {
    //     isMoving = true;

    //     // for (int i = 0; i < (90 / rollSpeed); i++)
    //     // {
    //     //     transform.RotateAround(anchor, axis, rollSpeed);
    //     // }

    //     transform.RotateAround(anchor, axis, rollSpeed);
    //     yield return new WaitForSeconds(.01f);

    //     isMoving = false;
    // }
}
