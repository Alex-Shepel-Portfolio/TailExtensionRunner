using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{

    private bool _gameHasEnded;

    public GameObject CompleteLevelUI;
    

    public void CompleteLevl()
    {

        CompleteLevelUI.SetActive(true);

    }

   public void EndGame()
    {
        if (_gameHasEnded == false)
        {
            _gameHasEnded = true;

            Restart();
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   


    }

}
