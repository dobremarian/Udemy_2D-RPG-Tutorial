using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public string[] lines;
    public string[] questCompleteLines;

    private bool canActivate;

    public bool isPerson = true;

    public bool shouldActivateQuest;
    public string questToMark;
    public bool markComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = QuestManager.instance.GetQuestNumber(questToMark);
        if (QuestManager.instance.questMarkersComplete[i])
        {
            markComplete = true;
        }
        

        if (canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy)
        {
            if(markComplete)
            {
                DialogManager.instance.ShowDialog(questCompleteLines, isPerson);
                shouldActivateQuest = false;

            }
            else
            {
                DialogManager.instance.ShowDialog(lines, isPerson);
                DialogManager.instance.ShouldActivateQuestAtEnd(questToMark, markComplete);
                if (shouldActivateQuest)
                {
                    QuestManager.instance.questObjectsMarker[i] = true;
                }
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
