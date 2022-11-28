using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    public int MaxHitPoint;

    [HideInInspector] public UnityEvent Die;
    [HideInInspector] public UnityEvent ChengeHitPoints;

    private int hitPoint;

    private bool isDie = false;

    private void Start()
    {
        hitPoint = MaxHitPoint;
        ChengeHitPoints.Invoke();
    }
    public void ApplyDamage(int damage)
    {
        hitPoint -= damage;

        ChengeHitPoints.Invoke();

        if (hitPoint <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (isDie == true) return;

        hitPoint = 0;
        isDie = true;

        ChengeHitPoints.Invoke();
        Die.Invoke();
    }

    public int GetHitPoints()
    {
        return hitPoint;

    }

    public int Health
    {
        set => hitPoint = value;

    }
}
