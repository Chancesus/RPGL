using UnityEngine;

public class GameFlagTriggerArea : MonoBehaviour
{
    [SerializeField] GameFlag _gameFlag;
    //[SerializeField] GameFlag _gameFlagobjective2;
    

    private void OnTriggerEnter(Collider other)
    {
        _gameFlag.Set(true);
        //_gameFlagobjective2.Set(true);
    }
}
