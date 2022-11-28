using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectial projectialPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;
    [SerializeField] private int projectileAmount;
    [SerializeField] private float projectileInterval;

    private float timer;
    public int Damage
    {
        get { return damage;  } // возвращаем значение свойства
        
        set { damage = value; }// устанавливаем новое значение свойства}
    }
    public int ProjectileAmmount
    {
        get { return projectileAmount; } // возвращаем значение свойства

        set { projectileAmount = value; }// устанавливаем новое значение свойства}
    }
    public float FireRate
    {
        get { return fireRate; } // возвращаем значение свойства

        set { fireRate = value; }// устанавливаем новое значение свойства}
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void SpawnProjectile()
    {
        float startPosX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;

        for (int i = 0; i < projectileAmount; i++)
        {
            Projectial projectial =  Instantiate(projectialPrefab,
                new Vector3(startPosX + i * projectileInterval, shootPoint.position.y,shootPoint.position.z),
                transform.rotation);
            projectial.SetDamage(damage);
        }
    }
    public void Fire()
    {
        if (timer >= fireRate)
        {
            SpawnProjectile();
            timer = 0;
        }
    }
}
