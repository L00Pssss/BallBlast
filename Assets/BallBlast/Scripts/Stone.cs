using UnityEngine;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructible
{
    public enum Size
    {
        Small,
        Normal,
        Big,
        Huge
    }

    [SerializeField] private Size size;
    [SerializeField] private float sizeZ = 0.0001f; 
    private StoneMovement movement;

    [SerializeField] private float spawUpForece;
    [SerializeField] public bool StopStone;
    [SerializeField] private float Timer = 0;


    [SerializeField] private Coin coinPrefab;

    [SerializeField] private ImmortalityCoin_Bonus immortalityCoinBonusPrefab;
    [SerializeField] private FrostCoin FrostCoinBonusPrefab;

    [SerializeField] public UIUpgrade uIUpgrade;

    public UILevelProgress uILevelProgress;

    public Freez freez;
    public Size SizeStone => size;

    private void Awake()
    {
        movement = GetComponent<StoneMovement>();
        Die.AddListener(OnStoneDestroyed);
        freez.FreezEvent.AddListener(Frezzq);
        SetSize(size);
    }

    private void OnDestroy()
    {
        Die.RemoveListener(OnStoneDestroyed);
        freez.FreezEvent.RemoveListener(Frezzq);
    }
    public void Frezzq()
    {
        uIUpgrade.UpdateStopStone();
        StopStone = true;
    }

    private void Update()
    {
        if (StopStone == true)
        {
            Stone stone = GetComponent<Stone>();
            stone.movement.enabled = false;
            Timer += Time.deltaTime;
        }
        if (Timer >= 5f)
        {
            StopStone = false;
            Stone stone = GetComponent<Stone>();
            stone.movement.enabled = true;
            Timer = 0;
        }
    }
    private void OnStoneDestroyed()
    {

        if (size != Size.Small && size != Size.Huge && size != Size.Big)
        {
            SpawStones();
            SpawnImmortalityCoinBonus();
        }

        if (size == Size.Huge)
        {
            SpawStones();

            SpawnCoin();
        }

        if (size == Size.Big)
        {
            SpawStones();

            SpawnFrostCoinBonus();
        }
        Destroy(gameObject);
        uILevelProgress.StoneProgress();
    }

    public void ChangeColor()
    {

        foreach (Transform child in transform)
        {
            if (child.name == "View")
            {
                //   child.GetComponentInChildren<SpriteRenderer>().material.color = stoneColor[1];
               child.GetComponentInChildren<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
        }      
    }

    private int chance;

    private void SpawnCoin()
    {
        chance = Random.Range(100, 201);
        if (chance <= 135)
        {
            Coin coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    } 
    private void SpawnImmortalityCoinBonus()
    {
        chance = Random.Range(200, 301);
        if (chance <= 210 && chance >= 200)
        {
            ImmortalityCoin_Bonus immortalityBonus = Instantiate(immortalityCoinBonusPrefab, transform.position, Quaternion.identity);
        }
    }
    private void SpawnFrostCoinBonus()
    {
        chance = Random.Range(300, 401);
        if (chance <= 310 && chance >= 300)
        {
            FrostCoin frostBonus = Instantiate(FrostCoinBonusPrefab, transform.position, Quaternion.identity);
            frostBonus.freez = this.freez;
        }
    }


    private void SpawStones()
    {
        sizeZ += 0.0001f;
        for (int i = 0; i < 2; i++)
        {    
            Stone stone = Instantiate(this, transform.position, Quaternion.identity); // this тот же камень \
            stone.SetSize(size - 1);
            stone.MaxHitPoint = Mathf.Clamp(MaxHitPoint / 2, 1, MaxHitPoint);
            stone.transform.position = new Vector3(transform.position.x, transform.position.y, sizeZ);
            stone.movement.SetHorizontalDirection((i % 2 * 2) - 1);
            sizeZ += 0.0001f;      
        }
    }

    public void SetSize(Size size)
    {
        if (size < 0) return;
        transform.localScale = GetVectorFromSize(size);
        this.size = size; // обновл€ем текущий размер 
    }
    private Vector3 GetVectorFromSize(Size size) // возвращ€ет в зависимости от значение size ¬ектор дл€ скейла. 
    {
        if (size == Size.Huge) return
                 new Vector3(1, 1, 1);
        if (size == Size.Big) return
                new Vector3(0.75f, 0.75f, 0.75f);
        if (size == Size.Normal) return
                new Vector3(0.6f, 0.6f, 0.6f);
        if (size == Size.Small) return
                new Vector3(0.4f, 0.4f, 0.4f);

        return Vector3.one;
    }



















































}
