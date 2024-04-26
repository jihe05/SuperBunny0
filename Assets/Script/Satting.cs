
using UnityEngine;
using UnityEngine.SceneManagement;


public class Satting : MonoBehaviour
{
   
    public GameObject CanvasObject;//선택화면
 

    private void Awake()
    {
        //화면
        Invoke("Choose", 0.8f);

    }

        
   private void Choose()
   {
        Debug.Log("활성화");
       CanvasObject.gameObject.SetActive(true);

   }









}
