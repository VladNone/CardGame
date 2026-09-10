using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    public int Moneys = 0;
    public TextMeshProUGUI textMoney;

    private int moneysShower;

    private void Start()
    {
        moneysShower = Moneys;
    }
    private void Update()
    {
        if (moneysShower < Moneys)
        {
            moneysShower += 1;
        }
        else if (moneysShower > Moneys)
        {
            moneysShower -= 1;
        }

        textMoney.text = moneysShower.ToString() + "<sprite=0>";
    }
}
