using UnityEngine;
public class PauseSystem : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool jogoPausado = false;
    public GameObject[] UIStuff; 
    void Start()
    {
        pauseMenu.SetActive(false);
        for (int i = 0; i < UIStuff.Length; i++) 
        {
            UIStuff[i].gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (jogoPausado == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                jogoPausado = false;
                pauseMenu.SetActive(false);
                for (int i = 0; i < UIStuff.Length; i++)
                {
                    UIStuff[i].gameObject.SetActive(true);
                }
                Time.timeScale = 1f;
            }
        }
        else if (jogoPausado == false) 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                jogoPausado = true;
                pauseMenu.SetActive(true);
                for (int i = 0; i < UIStuff.Length; i++)
                {
                    UIStuff[i].gameObject.SetActive(false);
                }
                Time.timeScale = 0f;
            }
         }
    }
}
