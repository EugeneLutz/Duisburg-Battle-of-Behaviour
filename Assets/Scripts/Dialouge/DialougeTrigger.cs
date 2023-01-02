using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouge;
    public Transform alert;

    private void Start()
    {
        alert.position = new Vector3(950,1200,0);
    }

    private void OnTriggerStay(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {

            alert.position = new Vector3(950, 950, 0);
        }

        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            Debug.Log("Starte Konversation");
            TriggerDialouge();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlayerCam.inDialouge = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        alert.position = new Vector3(950, 1200, 0);
    }

    void TriggerDialouge()
    {
        FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
    }
    
}
