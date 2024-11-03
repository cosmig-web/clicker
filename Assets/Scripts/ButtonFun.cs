using TMPro;
using UnityEngine;

public class ButtonFun : MonoBehaviour
{

    public TextMeshProUGUI priceText;
    public TextMeshProUGUI countText;

    public void UpdateText(int price, int count)
    {
        priceText.text = $"price: {price}";
        countText.text = count.ToString();
    }

}
