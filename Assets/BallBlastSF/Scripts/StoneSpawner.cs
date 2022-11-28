using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints; // где будем спавнить
    [SerializeField] private float spawnRate; // скорость спавна

    [Header("Balance")]
    [SerializeField] private Turret turret; // ссылка на пушку 
    [SerializeField] public float amount; // количество 

    [SerializeField] [Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private float maxHitPointsRate;
    


    [SerializeField] private Color[] stoneColor;

    [SerializeField] public bool StartLvL;

    [SerializeField] private LevelState levelState;

    [SerializeField] public Freez freez;
    [SerializeField] public UIUpgrade uIUpgrade;
    


    [Space(10)] public UnityEvent Completed;

    [SerializeField] public UILevelProgress levelProgress1;

    private int[] array = new int[50];
    [HideInInspector] public int countStone;



    private float timer;
    private float amountSpawnde;
    private int stoneMaxHitPoints;
    private int stoneMinHitPoints;


    private void Awake()
    {
        amount = levelState.CurrentLevel;
        RandomForSpawn();
    }

    private void Start()
    {
        int damagePerSecond = (int)( (turret.Damage * turret.ProjectileAmmount) * (1 / turret.FireRate) );

        stoneMaxHitPoints = (int) (damagePerSecond * maxHitPointsRate);
        stoneMinHitPoints = (int) (damagePerSecond * minHitpointsPercentage);


        timer = spawnRate;
    }



    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            Spaw(StartLvL);

            timer = 0;
        }

        if (amountSpawnde == amount)
        {
            enabled = false;

            StartLvL = false;

            Completed.Invoke();
        } 
    }


    private void NextLvl()
    {
        timer = 0;
        spawnRate++;

    }
   
    private void RandomForSpawn()
    {
        for (int i = 0; i < amount; i++)
        {
            array[i] = Random.Range(1, 4);
            if (array[i] == 1)
            {
                countStone += 3;
            }
            if (array[i] == 2)
            {
                countStone += 7;
            } 
            if (array[i] == 3)
            {
                countStone += 15;
            }
        }
    }


    private float sizeZ;
    private int SizeStoneArray;

    private void Spaw(bool Start)
    {
        if (Start == true)
        {
        stonePrefab.freez = this.freez;
        stonePrefab.uIUpgrade = this.uIUpgrade;
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.uILevelProgress = levelProgress1;
        sizeZ += 0.0001f;
        stone.GetComponentInChildren<SpriteRenderer>().material.color = stoneColor[Random.Range(0, 4)];
        transform.position = new Vector3(transform.position.x, transform.position.y, sizeZ);
        sizeZ += 0.0001f;

        stone.SetSize((Stone.Size)array[SizeStoneArray]);

            SizeStoneArray++;
        stone.MaxHitPoint = Random.Range(stoneMinHitPoints, stoneMaxHitPoints + 1);
            amountSpawnde++;
        }
    }
}
