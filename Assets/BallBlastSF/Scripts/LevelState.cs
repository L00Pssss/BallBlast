using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    [SerializeField] private StoneSpawner spwaner;
    [SerializeField] private Cart cart;
    [SerializeField] private CartBag bag;
    [SerializeField] private Turret turret;
    [SerializeField] private UIUpgrade upgrade;
    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat; // при столконвении и т.д.

  //  private bool buttonNextLevel = false;
    private int currentLevel = 1;
    private float timer;
 //   private float timerNextLevel;
    private bool chekPassed;
 //   private bool chekSave = false;
    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    private void Awake()
    {
        spwaner.Completed.AddListener(OnSpawnCompleted);
        cart.CollisionStone.AddListener(OnCartCollisionStone);
        Load();
    }

    private void OnDestroy()
    {
        spwaner.Completed.RemoveListener(OnSpawnCompleted);
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
    }
    private void OnCartCollisionStone()
    {
        Defeat.Invoke(); 
    }

    private void OnSpawnCompleted()
    {
        chekPassed = true;
    }

    public void Save()
    {
        CurrentLevel++;

        PlayerPrefs.SetInt("CurrentLevel", currentLevel); //уровень
        PlayerPrefs.SetInt("CartBag:Coin", bag.GetSetCoin); // zoloto

        PlayerPrefs.SetFloat("Turret:FireRate", turret.FireRate); // skorost'
        PlayerPrefs.SetInt("Turret:Damage", turret.Damage); // yron
        PlayerPrefs.SetInt("Turret:ProjectileAmmount", turret.ProjectileAmmount); // snara9d
                                                                                  
        PlayerPrefs.SetInt("UIUpgrade:SpeedCoin", upgrade.SpeedCoin); // snara9d       
        PlayerPrefs.SetInt("UIUpgrade:DamageCoin", upgrade.DamageCoin); // snara9d       
        PlayerPrefs.SetInt("UIUpgrade:ProjectileCoin", upgrade.ProjectileCoin); // snara9d    
    }

    private void Load()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        bag.GetSetCoin = PlayerPrefs.GetInt("CartBag:Coin", 50);

        turret.FireRate = PlayerPrefs.GetFloat("Turret:FireRate", 0.3f);
        turret.Damage = PlayerPrefs.GetInt("Turret:Damage", 1);
        turret.ProjectileAmmount = PlayerPrefs.GetInt("Turret:ProjectileAmmount", 1);


        upgrade.SpeedCoin = PlayerPrefs.GetInt("UIUpgrade:SpeedCoin", 50);
        upgrade.DamageCoin = PlayerPrefs.GetInt("UIUpgrade:DamageCoin", 50);
        upgrade.ProjectileCoin = PlayerPrefs.GetInt("UIUpgrade:ProjectileCoin", 50);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            if (chekPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0)
                {
                    Passed.Invoke();
                }
            }
            timer = 0;
        }




        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.F2) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
