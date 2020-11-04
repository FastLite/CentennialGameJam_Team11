using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public Transform ghostSpawner;
    public GameObject GhostPrefab;

    private bool GhostExits;

   
    // Update is called once per frame
    void Update()
    {

        //Calls the 'GoingGhost' function and confirms the ghost exited the body 
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            GoingGhost();
            GhostExits = true; 
        }
        if (GhostExits == true) { Destroy(gameObject); }

       


        void GoingGhost()
        {  
            // Instantiates the 'GhostPrefab' object if it didn't Exit yet then prevents it from instantiating if it exists
            if (GhostExits == false)
            {
                Instantiate(GhostPrefab, ghostSpawner.position, ghostSpawner.rotation);
                GhostExits = true;
            }
            else if (GhostExits == true)
            {
                return;
            } 
        }


        
    }

    

}
