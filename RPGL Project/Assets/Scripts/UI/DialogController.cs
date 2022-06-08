using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System;
using System.Text;

public class DialogController : MonoBehaviour
{
    
    [SerializeField] TMP_Text _storytText;
    [SerializeField] Button[] _choiceButtons;
    
    

    Story _story;

    CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ToggleCanvasOff();
    }

    [ContextMenu("Start Dialog")]
    public void StartDialog(TextAsset dialog)
    {
        ToggleCanvasOn();
        _story = new Story(dialog.text);
        RefreshView();
    }

    void ToggleCanvasOn()
    {
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
    void ToggleCanvasOff()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    void RefreshView()
    {
        StringBuilder storyTextBuilder = new StringBuilder();
        while (_story.canContinue)
        {
            storyTextBuilder.AppendLine(_story.Continue());
            HandleTags();
        }

            _storytText.SetText(storyTextBuilder);
        if (_story.currentChoices.Count == 0)
            ToggleCanvasOff();
        else
            ShowChoiceButttons();

    }

    private void ShowChoiceButttons()
    {
        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            var button = _choiceButtons[i];
            //Turns on and off choices 
            button.gameObject.SetActive(i < _story.currentChoices.Count);
            button.onClick.RemoveAllListeners();

            if (i < _story.currentChoices.Count)
            {
                var choice = _story.currentChoices[i];
                button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                button.onClick.AddListener(() =>
                {
                    _story.ChooseChoiceIndex(choice.index);
                    RefreshView();
                });
            }
        }
    }

    void HandleTags()
    {
        foreach (var tag in _story.currentTags)
        {
            Debug.Log(tag);
            if (tag.StartsWith("E."))
            {
                string eventName = tag.Remove(0, 2);
                GameEvent.RaiseEvent(eventName);
            }
               
        }
    }
}
