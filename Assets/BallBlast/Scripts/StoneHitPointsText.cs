using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Destructible))]
public class StoneHitPointsText : MonoBehaviour
{
    [SerializeField] private Text hitpointText; // ������ �� �����

    private Destructible destructible; // ������ ������ �� destructible

    private void Awake()
    {
        destructible = GetComponent<Destructible>();

        destructible.ChengeHitPoints.AddListener(OnChangeHitPoint);
    }

    private void OnDestroy()
    {
        destructible.ChengeHitPoints.RemoveListener(OnChangeHitPoint);
    }
    private void OnChangeHitPoint()
    {
        int hitPoints = destructible.GetHitPoints();

        if (hitPoints >= 1000)
            hitpointText.text = hitPoints / 1000 + "K";
        else
            hitpointText.text = hitPoints.ToString();
    }
}
