using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    [SerializeField] Image _progressBarFilledImage;
    [SerializeField] GameObject _progressBar;
  

    void OnEnable()
    {
        _hintText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
    }

    void OnDisable()
    {
        Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;
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
