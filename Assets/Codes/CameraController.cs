using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlatformShoot 
{
    public class CameraController : MonoBehaviour
    {
        public Transform mTarget;
        // Start is called before the first frame update
        private void Start() {
          // 获取玩家 position 
          mTarget = GameObject.FindGameObjectWithTag("Player").transform;
          
        }
        // 逻辑更新结束后执行摄像机更新
        private void LateUpdate() {
          if(mTarget == null){
            return;
          }

          // 摄像机跟随玩家
          transform.localPosition = new Vector3(mTarget.position.x,mTarget.position.y,-10);

        }
    }

}