using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Freez : MonoBehaviour
{
   // private Stone stone;

    [HideInInspector] public UnityEvent FreezEvent;
    public void S()
    {
        FreezEvent.Invoke();
    }






}
