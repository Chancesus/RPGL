using System.Collections;
using TMPro;
using UnityEngine;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    [SerializeField] TMP_Text _progressText;

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
            _progressText.SetText(InspectionManager.InspectionProgress.ToString());
    }
}
