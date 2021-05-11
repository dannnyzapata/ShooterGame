using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{

    public Text contadorEnemigos;
    public Text contadorAmigos;
    private int AmigosSav;
    private int EnemigosMue;



    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        AmigosSav = CivScript.CivSavedCounter;
        EnemigosMue = (EnemyHealth.enemycounterdead);
        

        contadorAmigos.text = AmigosSav.ToString();
        contadorEnemigos.text = EnemigosMue.ToString();
        
    }
}
