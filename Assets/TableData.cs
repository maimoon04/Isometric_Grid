using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableData : MonoBehaviour
{

    [SerializeField] private bool Placed;
    [SerializeField] private GameObject TableV, TableH;

    public bool IsHorizantalDirection;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetTableRotation()
    {
        if (IsHorizantalDirection)
        {
            TableH.SetActive(false);
            TableV.SetActive(true);
        }
        else
        {

            TableH.SetActive(true);
            TableV.SetActive(false);
        }
    }

}
    // Update is called once per frame
   

