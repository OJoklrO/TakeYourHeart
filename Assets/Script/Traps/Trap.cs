using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    // 陷阱名
    public virtual string TrapName { set; get; }
    // 生效后造成分数变化
    public virtual int ScoreChange { set; get; }


    /// <summary>
    /// 碰撞后的调用方法
    /// </summary>
    /// <param name="Player">碰撞到陷阱的Player</param>
    /// <returns>返回变化的分数</returns>
    public virtual int Trapped(GameObject Player)
    {
        return 0;
    }

    public void DestroyTrap()
    {
        Destroy(this.gameObject);
    }
}
