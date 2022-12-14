using UnityEngine;
using UnityEngine.UI;

public class UILevelProgress : MonoBehaviour
{
    [SerializeField] private StoneSpawner stoneSpawner;
    [SerializeField] private LevelState levelState;
    [SerializeField] private Text currentLeveltext;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Image progressBar;

    private float fillAmountStep;
    private void Start()
    {
        currentLeveltext.text = levelState.CurrentLevel.ToString();
        nextLevelText.text = (levelState.CurrentLevel + 1).ToString();
        progressBar.fillAmount = 0;
        fillAmountStep = 1 / (float) stoneSpawner.countStone;
    }
    public void StoneProgress()
    {
            progressBar.fillAmount += fillAmountStep;
    }
}
