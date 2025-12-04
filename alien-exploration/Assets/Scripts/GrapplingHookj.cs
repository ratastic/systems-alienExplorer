using UnityEngine;

public class GrapplingHookj : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private Transform grapplingHook;
    [SerializeField] private Transform handPos;
    [SerializeField] private Transform playerBody;

    [SerializeField] private LayerMask grapplingLayer;
    [SerializeField] private float maxGrappleDist;
    [SerializeField] private float hookSpeed;
    [SerializeField] private Vector3 offset;

    private bool isShooting, isGrappling;
    private Vector3 hookPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        isShooting = false;
        isGrappling = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("grappling");
            ShootHook();
        }
        if (isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, hookPoint, hookSpeed * Time.deltaTime);
            if (Vector3.Distance(grapplingHook.position, hookPoint) < 0.5f)
            {
                controller.enabled = false;
                playerBody.position = Vector3.Lerp(playerBody.position, hookPoint - offset, hookSpeed * Time.deltaTime);
                if (Vector3.Distance(playerBody.position, hookPoint - offset) < 0.5f)
                {
                    controller.enabled = true;
                    isGrappling = false;
                    grapplingHook.SetParent(handPos);

                }
            }

        }
    }

    private void ShootHook()
    {
        if (isShooting || isGrappling) return;

        isShooting = true;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, maxGrappleDist, grapplingLayer))
        {
            hookPoint = hit.point;
            isGrappling = true;
            grapplingHook.parent = null;
            grapplingHook.LookAt(hookPoint);
            print("GRAPPLING HOOK HIT");
        }


        isShooting = false;
    }
}
