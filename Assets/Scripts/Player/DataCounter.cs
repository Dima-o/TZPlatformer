using TMPro;
using UnityEngine;

public class DataCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text textCountCoin;
    [SerializeField] private TMP_Text textCountCoinInMenu;

    [SerializeField] private GameObject menuVictory;

    private int countCoin;

    private void Start()
    {
        countCoin = 0;
    }

    private void Update()
    {
        if (menuVictory.activeSelf)
        {
            CounterDataInMenu();
        }
    }

    public void CounterDataCoins()
    {
        countCoin += 1;
        textCountCoin.text = countCoin.ToString();
    }

    private void CounterDataInMenu()
    {
        textCountCoinInMenu.text = countCoin.ToString();
    }
}
