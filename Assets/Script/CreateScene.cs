using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScene : MonoBehaviour
{
    public GameObject Map;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    public GameObject Gurad1;
    public GameObject Gurad2;
    public GameObject Gurad3;
    public GameObject Gurad4;

    private Position position;

    private void Awake()
    {
        Instantiate(Map);

        position = Map.gameObject.GetComponent<Position>();

        Instantiate(Player1, position.Position1, Quaternion.identity);
        Instantiate(Player2, position.Position1, Quaternion.identity);
        Instantiate(Player3, position.Position1, Quaternion.identity);

        Gurad1.gameObject.GetComponent<Gurad>().Route = position.Route1;
        Gurad2.gameObject.GetComponent<Gurad>().Route = position.Route2;
        Gurad3.gameObject.GetComponent<Gurad>().Route = position.Route3;
        Gurad4.gameObject.GetComponent<Gurad>().Route = position.Route4;

        Instantiate(Gurad1, position.Route1[0].transform.position, Quaternion.identity);
        Instantiate(Gurad2, position.Route2[0].transform.position, Quaternion.identity);
        Instantiate(Gurad3, position.Route3[0].transform.position, Quaternion.identity);
        Instantiate(Gurad4, position.Route4[0].transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
