using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static int towerPlacing=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void blueTower(){
        towerPlacing=1;
    }
    public void greenTower(){
        towerPlacing=2;
    }
    public void orangeTower(){
        towerPlacing=3;
    }
    public void purpleTower(){
        towerPlacing=4;
    }
}
