using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public int wood = 0;               //Increase AxeSpeed
    public int mushrooms = 0;          //Increase Speed
    public int tears = 0;         //Increase Damage
    public int grave = 0;

    private void Update()
    {
        if (grave >= 3)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
