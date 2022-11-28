using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2.0f);
    }
}
