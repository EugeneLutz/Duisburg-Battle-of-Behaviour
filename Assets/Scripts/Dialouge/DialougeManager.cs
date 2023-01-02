using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Transform Dialouge;
    public TextMeshProUGUI dialougeText;
    public TextMeshProUGUI dialougeName;



    void Start()
    {
        sentences= new Queue<string>();
        Dialouge.position = new Vector3(10000, 10000, 10000);
    }

    public void StartDialouge(Dialouge dialouge)
    {
        dialougeName.text = dialouge.name;
        sentences.Clear();
        Debug.Log(sentences);

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
            
        }

        Dialouge.position = new Vector3(960, 222, 0);
    }



    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        dialougeText.text = sentence;
    }

    void EndDialouge()
    {
        Debug.Log("End of Conversation");
        PlayerCam.inDialouge = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        dialougeText.text = "...";
        Dialouge.position = new Vector3(10000, 10000, 10000);
    }
}
