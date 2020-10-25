using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{

    private PlayerBehaviour playerBehaviour;
    public bool moneyBar;
    public bool alcoholBar;
    public bool funBar;

    // Start is called before the first frame update
    void Start()
    {
        playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moneyBar)
        {
            this.GetComponent<Slider>().value = playerBehaviour.moneyStatus;
        } else if (alcoholBar)
        {
            this.GetComponent<Slider>().value = playerBehaviour.alcoholStatus;
        } else if (funBar)
        {
            this.GetComponent<Slider>().value = playerBehaviour.funStatus;
        }
    }
}
