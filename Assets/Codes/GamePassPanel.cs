using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace PlatformShoot 
{
    public class GamePassPanel : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // 点击重新开始按钮 加载游戏场景 SampleScene
            transform.Find("ResetGameBtn").GetComponent<Button>().onClick.AddListener(()=>{
                print("listen");
                SceneManager.LoadScene("SampleScene");
            });
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
