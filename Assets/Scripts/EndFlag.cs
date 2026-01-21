using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{

    public bool finalLevel;
    [SerializeField]
    public string nextLevelName;
    public void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.CompareTag("Player"))
            {
                if (finalLevel == true)
                {
                    SceneManager.LoadScene("Menu");
                }
                else
                {
                    SceneManager.LoadScene(nextLevelName);
                }
            }
    }
}
