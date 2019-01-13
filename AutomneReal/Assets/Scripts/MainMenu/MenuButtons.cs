using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine("StartGameCor");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartGameCor()
    {
        Destroy(button1);
        Destroy(button2);
        Destroy(button3);
        for (float i=0; i < 255f; i+=4)
        {
            spriteRenderer.color = new Color(0, 0, 0, (i / 255));
            yield return new WaitForSeconds(0.05f);
        }
        SceneManager.LoadScene("MapTest");
    }

}
