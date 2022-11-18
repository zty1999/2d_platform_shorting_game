using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using UnityEngine.UI.TMP;

namespace PlatformShoot {
    public class MainPanel : MonoBehaviour
    {
        private TMPro.TextMeshProUGUI mScoreText;
        // Start is called before the first frame update
        void Start()
        {
            mScoreText = transform.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
            Debug.Log(mScoreText);
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        public void UpdateScoreText(int score){
            print(score);
            int temp = int.Parse(mScoreText.text);
            print(temp);
            mScoreText.text = (temp + score).ToString();
        }
    }
}