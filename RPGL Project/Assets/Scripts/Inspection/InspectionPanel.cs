using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    [SerializeField] Image _progressBarFilledImage;
    [SerializeField] GameObject _progressBar;
    [SerializeField] TMP_Text _completedInspectionText;
    [SerializeField] float _completedTextTime = 2f;

    void OnEnable()
    {
        _hintText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;

        Inspectable.AnyInspectionComplete += HandleAnyInspectionComplete;
    }

    private void HandleAnyInspectionComplete(Inspectable inspectable, string completedInspectionMessage)
    {
       _completedInspectionText.SetText(completedInspectionMessage);
        _completedInspectionText.enabled = true;

        StartCoroutine(FadeCompletedText());
    }

    private IEnumerator FadeCompletedText()
    {
        _completedInspectionText.alpha = 1f;
       while (_completedInspectionText.alpha > 0)
        {
            yield return new WaitForSeconds(_completedTextTime);
            _completedInspectionText.alpha -= Time.deltaTime;
        }
        _completedInspectionText.enabled = false;
    }

    void OnDisable()
    {
        Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;
        Inspectable.AnyInspectionComplete -= HandleAnyInspectionComplete;
    }

    private void UpdateHintTextState(bool enableHint)
    {
        _hintText.enabled = enableHint;
    }

    private void Update()
    {
        if (InspectionManager.Inspecting)
        {
            _progressBarFilledImage.fillAmount = InspectionManager.InspectionProgress;
            _progressBar.SetActive(true);
        }
        else if (_progressBar.activeSelf)
        {
            _progressBar.SetActive(false);
        }
            
    }
}
