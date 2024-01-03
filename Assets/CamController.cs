using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private WebCamTexture webcamTexture;

    void Start()
    {
        // 檢查是否有可用的攝像頭
        if (WebCamTexture.devices.Length > 0)
        {
            // 選擇第一個可用的攝像頭
            webcamTexture = new WebCamTexture(WebCamTexture.devices[0].name, Screen.width, Screen.height);

            // 指定攝像頭紋理給相機組件
            Camera.main.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            Camera.main.targetTexture.Create();
            Camera.main.fieldOfView = 60;
            Camera.main.aspect = (float)Screen.width / Screen.height;
            Camera.main.enabled = true;
            Camera.main.ResetAspect();
            Camera.main.Render();
        }
        else
        {
            Debug.LogError("找不到可用的攝像頭！");
        }
    }

    void Update()
    {
        // 檢查攝像頭是否正在運行，並在需要時更新紋理
        if (webcamTexture != null && !webcamTexture.isPlaying)
        {
            webcamTexture.Play();
        }
    }
}
