using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player
{
    private string _playerName = "Player1";
    public override string PlayerName
    {
        get { return _playerName; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Move(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Trap"))
        {
            //Trapped(this.gameObject, collision);
            Debug.Log(Trapped(this.gameObject, collision));
        }
    }
}
