using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class DHT11_DataReceive : MonoBehaviour
{
    
    private SerialPort serialPort;
    public string portName = "COM5"; // Arduino 串口名稱
    public int baudRate = 9600; // 波特率
    private string receivedStringData;
    private float Timer;
    public float delayTime;

    public string Temperature;
    public string Humidity;

    private void Start()
    {
        
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= delayTime)
        {
            receivedStringData = serialPort.ReadLine();
            //Debug.Log(receivedStringData);

            string[] dataParts = receivedStringData.Split(','); // 使用逗号分割字符串

            if (dataParts.Length >= 2) // 确保至少有两个部分
            {
                Temperature = dataParts[0].Trim(); // 温度
                Humidity = dataParts[1].Trim(); // 湿度

                //Debug.Log("Temperature: " + Temperature);
                //Debug.Log("Humidity: " + Humidity);
            }

            Timer = 0;
        }
    }


    private void OnApplicationQuit()
    {
        serialPort.Close();
    }
}
