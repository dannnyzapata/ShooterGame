using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GanadorReal : MonoBehaviour
{

    public Text Win;
    AudioSource Winning;
    public AudioClip Congratu;
    public GameObject ThePlayer;
    public GameObject ShootPoint;

    List<GameObject> CivilesLista = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Win.gameObject.SetActive(false);
        //CivilesLista.AddRange(GameObject.FindGameObjectsWithTag("Civil"));
        ///print(CivilesLista.Count);
        ///

        

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Civilian").Length == 0)
        {
            Time.timeScale = 0f;
            Win.gameObject.SetActive(true);
            ShootPoint.GetComponent<Pistol>().enabled = false;
            ThePlayer.GetComponent<FirstPersonController>().enabled = false;
            //if (Input.anyKey)
            //{
            //    ShootPoint.GetComponent<Pistol>().enabled = true;
            //    ThePlayer.GetComponent<FirstPersonController>().enabled = true;
            //    Time.timeScale = 1f;
            //    Cursor.visible = true;
            //    SceneManager.LoadScene("Main Menu");
            //}
                                                                                   
        }

    }
   



}
