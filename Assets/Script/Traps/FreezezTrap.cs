using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezezTrap : Trap
{
    public float FreezeTime = 5f;
    private int _scoreChange = -10;
    private string _trapName = "FreezeTrap";
    public override string TrapName
    {
        get { return _trapName; }
    }
    public override int ScoreChange
    {
        get { return _scoreChange; }
    }

    public override int Trapped(GameObject Player)
    {
        Player.gameObject.GetComponent<Player>().StopForSeconds(FreezeTime);
        Invoke("DestroyTrap", 1);
        return ScoreChange;
    }

    IEnumerator Wait(Player p)
    {
        float _speed = p.Speed;
        p.Speed = 0;
        yield return new WaitForSeconds(FreezeTime);
        p.Speed = _speed;
        DestroyTrap();
        yield return null;
    }
}
