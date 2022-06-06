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
    [ContextMenu("Start Dialog")]
    public void StartDialog(TextAsset dialog)
    {
        _story = new Story(dialog.text);
        RefreshView();
    }

     void RefreshView()
    {
        StringBuilder storyTextBuilder = new StringBuilder();
        while (_story.canContinue)
        {
            storyTextBuilder.AppendLine(_story.Continue());

            _storytText.SetText(storyTextBuilder);

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
    }
}
