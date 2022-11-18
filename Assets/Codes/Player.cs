using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace PlatformShoot 
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D mRig;
        private float mGroundMoveSpeed = 5;// 移动速度
        private float mJumpForce = 12;// 跳跃高度
        private bool mJumpInput;// 跳跃状态判断


        public int mFaceDir = 1;// 玩家朝向


        public MainPanel mMainPanel;// 分数面板
        public GameObject mGamePass;// 通关方块
        // Start is called before the first frame update
        private void Start() {
            mRig = GetComponent<Rigidbody2D>();

            // GamePass 默认为未激活状态 此时通关方块不显示 
            mGamePass = GameObject.Find("GamePass");
            mGamePass.SetActive(false);
            // 分数面板
            mMainPanel =  GameObject.FindGameObjectWithTag("MainPanel").GetComponent<MainPanel>();//根据名字获取游戏物体("MainPanel").GetComponent<MainPanel>();
            // mMainPanel = GameObject.Find("MainPanel").GetComponent<MainPanel>();
            print(mMainPanel);

        }
        
        private void Update() {
            // 空格键 判断是否跳跃  update 判断  fixedUpdate 移动
            if(Input.GetKeyDown(KeyCode.Space)){
                mJumpInput = true;
            }
            // J键 发射子弹
            if(Input.GetKeyDown(KeyCode.J)){
                // 加载子弹原型到场景
                var bulletObj = Resources.Load<GameObject>("Bullet");
                // 场景中实例化一个子弹对象，并设置子弹出生位置为玩家中心，旋转角度为初始角度 也就是0
                bulletObj = GameObject.Instantiate(bulletObj,transform.position,Quaternion.identity);
                Bullet bullet = bulletObj.GetComponent<Bullet>();
                // 传入 GamePass 符合条件则激活 GamePass 状态  显示通关方块
                bullet.GetGamePass(mGamePass);
                // 修改子弹方向
                bullet.InitDir(mFaceDir);
            }
            // mRig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * mGroundMoveSpeed,mRig.velocity.y);
        }
        private void FixedUpdate() {
            // 跳跃
            if(mJumpInput){
                mJumpInput = false;
                mRig.velocity = new Vector2(mRig.velocity.x,mJumpForce);
            }
            // 方向输入
            float direction = Input.GetAxisRaw("Horizontal");
            // 更改角色朝向
            // 方向输入有输入且与朝向不同
            if(direction != 0 && direction != mFaceDir){
                // 更新当前朝向
                mFaceDir = -mFaceDir;
                // 变换组件方向 y轴旋转一百八十度，从而达到角色转向
                transform.Rotate(0,180,0);
            }
            // 左右移动
            mRig.velocity = new Vector2(direction * mGroundMoveSpeed,mRig.velocity.y);
        }

        // 碰撞检测
        private void OnTriggerEnter2D(Collider2D coll) {
            // 碰撞体对象为 door 切换场景
            if(coll.gameObject.CompareTag("Door")){
                SceneManager.LoadScene("GamePassScene");
            }

            // 碰撞体对象为 分数方块 消除方块，分数增加
            if(coll.gameObject.CompareTag("Reward")){
                GameObject.Destroy(coll.gameObject);
                mMainPanel.UpdateScoreText(1);
            }
        }
    }

}