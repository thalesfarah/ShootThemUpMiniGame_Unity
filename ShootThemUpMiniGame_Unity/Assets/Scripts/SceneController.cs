using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void MudaCena(string cena) 
    {
        SceneManager.LoadScene(cena);
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
    public void ResetaXPInicial() 
    {
        GameController.gameController.xpInicio = 0;
    }
}
