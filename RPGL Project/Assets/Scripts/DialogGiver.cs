using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGiver : MonoBehaviour
{
    //[SerializeField] GameObject canvasGroup;
    [SerializeField] TextAsset _dialog;

    private void OnTriggerEnter(Collider other)
    {
       var player = other.GetComponent<ThirdPersonMover>();
       if (player != null)
        {
            //canvasGroup.SetActive(true);
            FindObjectOfType<DialogController>().StartDialog(_dialog);
            transform.LookAt(player.transform);
        }
    }

    /*private void OnTriggerExit(Collider other) My solution for turning canvas on/off
    {
        var player = other.GetComponent<ThirdPersonMover>();
        if (player != null)
        {
            canvasGroup.SetActive(false);
        }
    }*/
}
