using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restartScr : MonoBehaviour
{
    public Image image;
    public static restartScr rest;
    private void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        rest = this;
    }
    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
