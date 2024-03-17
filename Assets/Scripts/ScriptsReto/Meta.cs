using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public static Meta instance;
    public GameObject meta;
    public int random;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        meta = GameObject.Find("Meta");
        random = AudioManager.instance.random;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UIController.instance.PanelWinnerOn();
            Time.timeScale = 0;
            meta.SetActive(false);
            AudioManager.instance.StopPlayMusic(random);
            AudioManager.instance.PlayMusic(3);

        }
        else if (other.tag == "RunnerEnemy")
        {
            
            UIController.instance.PanelLosserOn();
            Time.timeScale = 0;
            meta.SetActive(false);
            AudioManager.instance.StopPlayMusic(random);
            AudioManager.instance.PlayMusic(4);
        }
        
    }
}
