using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsHandeler : MonoBehaviour
{
    public static int playerMoney;
    [SerializeField]
    private TMP_Text textMoney;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMoney < 0)
        {
            playerMoney = 0;
        }
        textMoney.text = playerMoney.ToString();
    }
}
