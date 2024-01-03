using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text TemperatureText;
    public TMP_Text HumidityText;
    public SpriteRenderer TemperatureSprite;
    public SpriteRenderer HumiditySprite;
    public DHT11_DataReceive DHT11_data;

    private string TemperatureString;
    private string HumidityString;

    private void Start()
    {
        TemperatureSprite.color = new Color(0.3607843f, 0.9254902f, 0.3372549f, 1f);
        HumiditySprite.color = new Color(0.3607843f, 0.9254902f, 0.3372549f, 1f);
    }
    void Update()
    {
        TemperatureString = DHT11_data.Temperature;
        HumidityString = DHT11_data.Humidity;

        TemperatureText.text = "Temperature : " + TemperatureString;
        HumidityText.text = "Humidity : " + HumidityString + "%";

        TemperatureDetermine(TemperatureToInt());
        HumidityDetermine(HumidityToInt());

    }
    private int TemperatureToInt()
    {
        bool success = int.TryParse(TemperatureString, out int Intdata);
        if (success)
            return Intdata; 
        else
            return 0;
    }
    private int HumidityToInt()
    {
        bool success = int.TryParse(HumidityString, out int Intdata);
        if (success)
            return Intdata;
        else
            return 0;
    }
    //根據葉菜、根莖、茄果
    private void TemperatureDetermine(int TemperatureValue) 
    {
        if(TemperatureValue >= 15 && TemperatureValue <= 27)
        {
            //正常
            TemperatureSprite.color = new Color(0.3607843f, 0.9254902f, 0.3372549f, 1f);
        }
        else if(TemperatureValue > 27)
        {
            //太熱
            TemperatureSprite.color = new Color(1f, 0.240566f, 0.2475051f, 1f);
        }
        else if(TemperatureValue < 15)
        {
            //太冷
            TemperatureSprite.color = new Color(0.5424528f, 0.852214f, 1f, 1f);
        }
    }
    private void HumidityDetermine(int HumidityValue)
    {
        if (HumidityValue >= 57 && HumidityValue <= 77)
        {
            //正常
            HumiditySprite.color = new Color(0.3607843f, 0.9254902f, 0.3372549f, 1f);
        }
        else if (HumidityValue > 77)
        {
            //太溼
            HumiditySprite.color = new Color(0f, 0.3701007f, 1f, 1f);
        }
        else if (HumidityValue < 57)
        {
            //太乾
            HumiditySprite.color = new Color(0.6179246f, 0.7587681f, 1f, 1f);
        }
    }
}
