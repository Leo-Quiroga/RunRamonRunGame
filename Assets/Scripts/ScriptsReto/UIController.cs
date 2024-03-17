using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public static UIController instance;

    public  GameObject panelWinner;
    public GameObject panelLoser;
    public GameObject panelInicio;
    public float timer = 3;
    public Text timerCountDown;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       

        StartCoroutine(StartRace());


    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void PanelWinnerOn()
    {
        panelWinner.SetActive(true);
    }

    public void PanelWinnerOff()
    {
        panelWinner.SetActive(false);
    }

    public void PanelLosserOn()
    {
        panelLoser.SetActive(true);
    }
    public void PanelLosserOff()
    {
        panelLoser.SetActive(false);
    }

    public void PanelStartOn()
    {
        panelInicio.SetActive(true);

    }
    public void PanelStartOff()
    {
        panelInicio.SetActive(false);
    }

    IEnumerator StartRace()
    {
        
        PanelStartOn();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(4f);

        PanelStartOff();
        Time.timeScale = 1;
    }

}
