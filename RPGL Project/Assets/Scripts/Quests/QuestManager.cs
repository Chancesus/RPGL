using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]  QuestPanel _questPanel;
    [SerializeField] List<Quest> _allQuests;

    List<Quest> _activeQuests = new List<Quest>();
    
    public static QuestManager Instance { get; private set; }

    private void Awake() => Instance = this;

    public void AddQuest(Quest quest)
    {
        _activeQuests.Add(quest);
        _questPanel.SelectQuest(quest);
    }

    [ContextMenu("Progress Quest")]
    public void ProgressQuests()
    {
        foreach(var quest in _activeQuests)
        {
            quest.TryProgress();
        }
    }
}
