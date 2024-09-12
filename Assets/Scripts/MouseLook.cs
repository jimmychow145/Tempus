using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float xRotation = 0f;
    public Vector2 turn;
    public float sensitivity = 50;
    public Vector3 deltaMove;
    public float speed = 1;
    public GameObject InventoryUI;
    public GameObject PlayerStatUI;

    void Start()
    {
        
       
    }
    void Update()
    {
        if (InventoryUI.activeInHierarchy || PlayerStatUI.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            if(Input.GetKeyDown(KeyCode.Escape) && InventoryUI.activeInHierarchy && !PlayerStatUI.activeInHierarchy)
            {
                InventoryUI.SetActive(!InventoryUI.activeSelf);
                Cursor.lockState = CursorLockMode.Locked;
            }
            if (Input.GetKeyDown(KeyCode.Escape) && !InventoryUI.activeInHierarchy && PlayerStatUI.activeInHierarchy)
            {
                PlayerStatUI.SetActive(!PlayerStatUI.activeSelf);
                Cursor.lockState = CursorLockMode.Locked;
            }
            if (Input.GetKeyDown(KeyCode.Escape) && InventoryUI.activeInHierarchy && PlayerStatUI.activeInHierarchy)
            {
                PlayerStatUI.SetActive(!PlayerStatUI.activeSelf);
                InventoryUI.SetActive(!InventoryUI.activeSelf);
                Cursor.lockState = CursorLockMode.Locked;
            }
            


        }

        

        else
        {

            Cursor.lockState = CursorLockMode.Locked;
            turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(xRotation, turn.x, 0);
        }

        
        //turn.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        //xRotation -= turn.y;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    }
}
