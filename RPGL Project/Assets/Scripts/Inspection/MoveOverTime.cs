using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOverTime : MonoBehaviour
{
   [SerializeField] float duration = 1f;
   [SerializeField] Vector3 _magnitude = Vector3.down;
   [SerializeField] AnimationCurve _curve = AnimationCurve.Linear(0f, 0f, 1, 1);

    Vector3 _startingPosition;
    Vector3 _endingPosition;
    float _elapsed;

    void Awake()
    {
        _startingPosition = transform.position;
        _endingPosition = _startingPosition + _magnitude;
    }

    private void OnEnable()
    {
        _elapsed = 0f;
        _endingPosition = _startingPosition + _magnitude;
    }

    private void OnDisable()
    {
        transform.position = _startingPosition;
    }

    private void Update()
    {
        _elapsed += Time.deltaTime;
        float pctElapsed = _elapsed / duration;
        float pctOnCurve = _curve.Evaluate(pctElapsed);
        transform.position = Vector3.Lerp(_startingPosition, _endingPosition, pctOnCurve);
    }
}
