using UnityEngine;
using UnityEngine.UI;

public class UIKeyText : MonoBehaviour
{

    [SerializeField] private CartBag bag;
    [SerializeField] private Text text;

    private void Start()
    {
        text.text = text.text = bag.GetAmountCoin().ToString();
        bag.ChengeAmountCoin.AddListener(OnChengeCoinPoints); // подписываемся
    }

    private void Update()
    {
        text.text = text.text = bag.GetAmountCoin().ToString();
    }

    private void OnDestroy()
    {
        bag.ChengeAmountCoin.RemoveListener(OnChengeCoinPoints);// отписыаемся 
    }
    private void OnChengeCoinPoints()
    {
        text.text = bag.GetAmountCoin().ToString();
    }
}