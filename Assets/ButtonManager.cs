using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static int towerPlacing=0;
    public GameObject placeholderTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(towerPlacing>0){
            placeholderTower.SetActive(true);
        }else{
            placeholderTower.SetActive(false);
        }
    }
    public void blueTower(){
        if(MoneyManager.money>=10){
            towerPlacing=1;
            MoneyManager.money-=10;
        }
       
    }
    public void greenTower(){
        if(MoneyManager.money>=10){
            towerPlacing=2;
            MoneyManager.money-=10;
        }
    }
    public void orangeTower(){
        if(MoneyManager.money>=30){
            towerPlacing=3;
            MoneyManager.money-=30;
        }
    }
    public void purpleTower(){
        if(MoneyManager.money>=20){
            towerPlacing=4;
            MoneyManager.money-=20;
        }
    }
}
