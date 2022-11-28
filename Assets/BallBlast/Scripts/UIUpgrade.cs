using UnityEngine;
using UnityEngine.UI;

public class UIUpgrade : MonoBehaviour
{

    [SerializeField] Turret turret;
    [SerializeField] CartBag bag;
    [SerializeField] Stone stone;
    [SerializeField] Cart cart;
    [SerializeField] private Text[] SpeedText;
    [SerializeField] private Text[] DamagelText;
    [SerializeField] private Text[] ProjectileText;
    [SerializeField] private GameObject TextPrefab;

    [SerializeField] private GameObject TextPrefabStoneStop;
    [SerializeField] private GameObject TextPrefabImoratal;

    public int SpeedCoin = 50;
    public int DamageCoin = 50;
    public int ProjectileCoin = 50;

    private void Update()
    {
        UIUpdate();
    }

    public void UpdateStopStone()
    {
       Instantiate(TextPrefabStoneStop);
    }
    
    public void UpdateImoratl()
    {
        Debug.Log("zapusk");
       Instantiate(TextPrefabImoratal);
    }

    public void UpgradeSpeed()
    {
        if (bag.GetSetCoin == SpeedCoin)
        {
            turret.FireRate -= 0.1f;
            bag.GetSetCoin -= SpeedCoin;
            SpeedCoin += 50;
            return;
        }
        Instantiate(TextPrefab);
    }
    public void UpgradeDamage()
    {
        if (bag.GetSetCoin == DamageCoin)
        {
            turret.Damage += 1;
            bag.GetSetCoin -= DamageCoin;
            DamageCoin += 50;
            return;
        }
        Instantiate(TextPrefab);
              
    }  
    
    public void UpgradeProjectile()
    {
        if (bag.GetSetCoin == ProjectileCoin)
        {
            turret.ProjectileAmmount += 1;           
            bag.GetSetCoin -= ProjectileCoin;
            ProjectileCoin += 50;
            return;
        }
        Instantiate(TextPrefab);
    }


    private void UIUpdate()
    {
        for (int i = 0; i < 3; i++) 
        {
            SpeedText[i].text = $"Shot speed {SpeedCoin.ToString()}";
            DamagelText[i].text = $"Damage {DamageCoin.ToString()}";
            ProjectileText[i].text = $"Projectile {ProjectileCoin.ToString()}";
        }
    }

}
