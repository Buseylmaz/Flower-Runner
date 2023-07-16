using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    public float playerSpeed;
    [SerializeField] float xSpeed;
    [SerializeField] float limitx;

    float touchXDelta = 0;
    float newX = 0;


    void Start()
    {
        
    }

   

    
    void Update()
    {
        SwipeCheck();

    }



    /// <summary>
    /// Ekrana dokunup dokunulmadýgý test edilip ayrýca karakteri haraket ettirdik
    /// </summary>
    void SwipeCheck()
    {

        //Dokunup dokunmadýgýný kontrol için 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            //Parmagýmýzýn deðip degmedigini kontrol ediyoruz
            //Debug.Log("Finger is moved!!...");

            //x de ki hareki test ediyoruz
            //Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width); //degerler büyük rakamalr oldugu için screen.width böldük küçülmesi için


            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;

        }
        //Eðer telefon baglý degilse test edebilmek için mouse kullanmamýza yarar
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        else
        {
            touchXDelta = 0;
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;

        //Karekterin sag ve sola giderken platformdan düþmemesi için
        newX = Mathf.Clamp(newX, -limitx, limitx);

        //Ýleriye dogru koþmasý için 
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
