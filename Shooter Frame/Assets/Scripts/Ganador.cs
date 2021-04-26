using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ganador : MonoBehaviour
{

    public Text Win;
    AudioSource Winning;
    public AudioClip Congratu;

    //List<GameObject> CivilesLista = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Win.gameObject.SetActive(false);
        //CivilesLista.AddRange(GameObject.FindGameObjectsWithTag("Civil"));
        ///print(CivilesLista.Count);

    }

    // Update is called once per frame
    void Update()
    {


        print(GameObject.FindGameObjectsWithTag("Civilian").Length);

        if (GameObject.FindGameObjectsWithTag("Civilian").Length == 0)
        {
            Win.gameObject.SetActive(true);
            
        }
    }
}
