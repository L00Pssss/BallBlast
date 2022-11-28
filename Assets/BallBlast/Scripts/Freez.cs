using UnityEngine;
using UnityEngine.Events;

public class Freez : MonoBehaviour
{
    [HideInInspector] public UnityEvent FreezEvent;
    public void S()
    {
        FreezEvent.Invoke();
    }
}
