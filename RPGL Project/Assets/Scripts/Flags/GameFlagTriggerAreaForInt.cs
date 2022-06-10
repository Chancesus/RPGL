using UnityEngine;

public class GameFlagTriggerAreaForInt : MonoBehaviour
{
    [SerializeField] IntGameFlag _intGameFlag;
    [SerializeField] int _amount;

    private void OnTriggerEnter(Collider other)
    {
        _intGameFlag.Modify(_amount);
    }
}
