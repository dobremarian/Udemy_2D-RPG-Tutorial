using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public GameObject questObjectBlock, questObjectMove;
    public string quest;

    // Start is called before the first frame update
    void Start()
    {
        questObjectBlock.SetActive(true);
        questObjectMove.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int i = QuestManager.instance.GetQuestNumber(quest);
        if(QuestManager.instance.questObjectsMarker[i])
        {
            questObjectBlock.SetActive(false);
            questObjectMove.SetActive(true);
        }
    }
}
