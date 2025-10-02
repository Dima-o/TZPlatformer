using UnityEngine;
using UnityEngine.UI;

public class DataCounter : MonoBehaviour
{
    [SerializeField] private Text textCountEnemy;
    [SerializeField] private Text textCountCoin;

    [SerializeField] private Text textCountEnemyInMenu;
    [SerializeField] private Text textCountCoinInMenu;

    [SerializeField] private GameObject menu;

    private int countEnemy;
    private int countCoin;

    private void Start()
    {
        countEnemy = 0;
        countCoin = 0;
    }

    private void Update()
    {
        if (menu.activeSelf)
        {
            CounterDataInMenu();
        }
    }

    public void CounterDataEnemy()
    {
        countEnemy += 1;
        textCountEnemy.text = countEnemy.ToString();
    }

    public void CounterDataCoins()
    {
        countCoin += 1;
        textCountCoin.text = countCoin.ToString();
    }

    private void CounterDataInMenu()
    {
        textCountCoinInMenu.text = countCoin.ToString();
        textCountEnemyInMenu.text = countEnemy.ToString();
    }
}
