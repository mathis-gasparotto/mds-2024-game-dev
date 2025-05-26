using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Instance.PlayGame();
    }
}
