using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CivScript : MonoBehaviour
{
    public float CivSAved = 10f;
    public static int CivSavedCounter = 0;

    public void SaveCiv(float save)
    {
        CivSAved -= save;

        if (CivSAved <= 0) { CivSaved(); }
    }


    public void CivSaved()
    {
        Destroy(gameObject);
        CivSavedCounter++;
    }
}
