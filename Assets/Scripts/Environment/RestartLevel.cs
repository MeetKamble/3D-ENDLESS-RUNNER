using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    [SerializeField]

    void Update()
    {
        StartCoroutine(GameRestart());
    }
    IEnumerator GameRestart()
    {
        if (this.gameObject.GetComponent<EndRunSequence>().enabled == true)
        {
            yield return new WaitForSeconds(3);
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                CollectableControl.coinCount = 0;
            }
            else if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                CollectableControl.coinCount = 0;
            }
        }
    }
}