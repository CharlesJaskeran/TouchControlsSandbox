using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public RunController movement;
    public Canvas gameOverUI;
    public GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //Debug.Log("Detecting player collision");
        if (collisionInfo.collider.tag == "Obstacle")
        {
            GetComponent<RunController>().enabled = false;
            Debug.Log("You hit a rock! Game Over!");
            gameManager.enablePlayerGameOverUI();
            //FindObjectOfType<GameMan>().EndCubeGame();
        }
    }

}
