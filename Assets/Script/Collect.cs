using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class Collect : MonoBehaviour
{

    [SerializeField] int score;

    public TextMeshProUGUI scoreText;
    public Animator playerAnim;
    public GameObject player;

    public GameObject finishPanel;

    public OyuncuKontrol oyuncuKontrol;


    void Start()
    {
        playerAnim=player.GetComponentInChildren<Animator>();
    }


    /// <summary>
    /// Flower adýnda tagla temas edince objeyi yok ediyoruz.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flower"))
        {
            AddFlower();
            //Debug.Log("Flower");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Finish"))
        {
            //bitiþ çizgisine gelince koþmayý durdurduk
            oyuncuKontrol.playerSpeed = 0;

            //Yüzü bize dönük olmasý için transfrom deðerine eriþtik
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self); //space.self kendi etrafýnda döndürmek

            finishPanel.SetActive(true);

            if (score >= 8)
            {
                //Debug.Log("Mutlu");
                playerAnim.SetBool("Dance", true);
            }
            else
            {
                //Debug.Log("Üzgün");
                playerAnim.SetBool("Sad", true);
            }

            
            

        }

        else if (other.CompareTag("Cactus"))
        {
            if (score > 0)
            {
                MinusCactus();
            }
            else
            {
                ConstScore();
            }
            
            Destroy(other.gameObject);

        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Engele Çarptý");
            SceneManager.LoadScene(0);
        }
        
    }


    public void AddFlower()
    {
        score += 1;
        scoreText.text = "Skor: " + score.ToString();
    }


    public void MinusCactus()
    {
        score -= 1;
        scoreText.text = "Skor: " + score.ToString();
    }

    public void ConstScore()
    {
        scoreText.text = "Skor: " + score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
