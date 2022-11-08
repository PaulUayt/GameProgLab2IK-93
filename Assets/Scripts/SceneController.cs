using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    int tokens = 0;

    [SerializeField] Text tokenText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Token"))
        {
            Destroy(other.gameObject);
            tokens++;
            tokenText.text = "Token: " + tokens;
        }

        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            tokens = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (this.CompareTag("Player") && other.CompareTag("Finish_Restart"))
        {
            tokens = 0;
            SceneManager.LoadScene(0);
        }
    }
}
