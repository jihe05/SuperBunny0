
using UnityEngine;
using UnityEngine.SceneManagement;


public class Satting : MonoBehaviour
{
   
    public GameObject CanvasObject;//����ȭ��
 

    private void Awake()
    {
        //ȭ��
        Invoke("Choose", 0.8f);

    }

        
   private void Choose()
   {
        Debug.Log("Ȱ��ȭ");
       CanvasObject.gameObject.SetActive(true);

   }









}
