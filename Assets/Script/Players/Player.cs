using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 0.05f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    /// <summary>
    /// 只读，角色名
    /// </summary>
    public virtual string PlayerName
    {
        get;
    }

    /// <summary>
    /// 接受输入进行对应移动
    /// </summary>
    /// <param name="up">上移按键</param>
    /// <param name="down">下移按键</param>
    /// <param name="left">左移按键</param>
    /// <param name="right">右移按键</param>
    /// <returns>返回人物当前朝向</returns>
    public Directions Move(KeyCode up, KeyCode down, KeyCode left, KeyCode right)
    {
        Directions dir = Directions.Stop;
        if (Input.GetKey(up) && Input.GetKey(right))
        {
            this.transform.Translate((new Vector3(1, 1, 0)).normalized * Speed);
            dir = Directions.UpRight;
        }
        else if (Input.GetKey(down) && Input.GetKey(right))
        {
            this.transform.Translate((new Vector3(1, -1, 0)).normalized * Speed);
            dir = Directions.DownRight;
        }
        else if (Input.GetKey(up) && Input.GetKey(left))
        {
            this.transform.Translate((new Vector3(-1, 1, 0)).normalized * Speed);
            dir = Directions.UpLeft;
        }
        else if (Input.GetKey(down) && Input.GetKey(left))
        {
            this.transform.Translate((new Vector3(-1, -1, 0)).normalized * Speed);
            dir = Directions.DownLeft;
        }
        else
        {
            if (Input.GetKey(up))
            {
                this.transform.Translate((new Vector3(0, 1, 0)).normalized * Speed);
                dir = Directions.Up;
            }
            else if (Input.GetKey(down))
            {
                this.transform.Translate((new Vector3(0, -1, 0)).normalized * Speed);
                dir = Directions.Down;
            }
            else if (Input.GetKey(left))
            {
                this.transform.Translate((new Vector3(-1, 0, 0)).normalized * Speed);
                dir = Directions.Left;
            }
            else if (Input.GetKey(right))
            {
                this.transform.Translate((new Vector3(1, 0, 0)).normalized * Speed);
                dir = Directions.Right;
            }
        }

        return dir;
    }

    /// <summary>
    /// 碰撞到陷阱时调用
    /// </summary>
    /// <param name="Player">本Player的GameObject</param>
    /// <param name="Trap">tag为Trap的碰撞物</param>
    /// <returns>返回分数变化</returns>
    public int Trapped(GameObject Player, Collider2D Trap)
    {
        var x = Trap.gameObject.GetComponent<Trap>();
        return x.Trapped(Player);
    }

    public void StopForSeconds(float time)
    {
        StartCoroutine(_stopForSeconds(time));
    }

    private IEnumerator _stopForSeconds(float time)
    {
        float s = Speed;
        Speed = 0;
        yield return new WaitForSeconds(time);
        Speed = s;
        yield return 0;
    }

}

public enum Directions
{
    Stop,
    Up,
    UpRight,
    Right,
    DownRight,
    Down,
    DownLeft,
    Left,
    UpLeft,
}
