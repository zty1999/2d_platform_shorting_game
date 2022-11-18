using UnityEngine;
namespace PlatformShoot
{
    // 子弹
    public class Bullet : MonoBehaviour
    {

        private LayerMask mLayerMask;
        private GameObject mGamePass;
        private int bulletDir;// 子弹朝向
        // Start is called before the first frame update
        void Start()
        {
            // 3秒后销毁自身
            GameObject.Destroy(this.gameObject,3f);
            mLayerMask = LayerMask.GetMask("Ground","BulletTrigger");
        }
        public void GetGamePass(GameObject pass){
            mGamePass = pass;
        }
        // 子弹朝向设置为角色朝向
        public void InitDir(int dir){
            bulletDir = dir;
        }
        // Update is called once per frame
        void Update()
         {   
            // 沿x轴正方向飞行
            // transform.Translate(12 * Time.deltaTime,0,0);

            transform.Translate(bulletDir * 12 * Time.deltaTime,0,0);

            
            
        }
        void FixedUpdate()
         {   
            // Physics2D.OverlapBox 返回 collider 当 collider 不为空说明子弹碰到了地面或者trigger的对象。
            var coll = Physics2D.OverlapBox(transform.position,transform.localScale,0,mLayerMask);
            if(coll){
                // 碰到的是红色方块 销毁红色方块
                if(coll.CompareTag("BulletTrigger")){
                  GameObject.Destroy(coll.gameObject);
                  mGamePass.SetActive(true);
                }
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}