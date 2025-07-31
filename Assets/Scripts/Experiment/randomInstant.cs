using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class randomInstant : MonoBehaviour
{
    public GameObject[] lensPrefabs;
    public GameObject[] lensQuads;
    public Transform lensPos;

    // Start is called before the first frame update
    void Start()
    {
        ActivateLens(0);
        //int rand = 2;
        //Instantiate(lensPrefabs[rand], lensPos.position, lensPrefabs[rand].transform.rotation);

        //sliders[rand].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            LoadRandomScene();
        }

    }

    void LoadRandomScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void ActivateLens(int n){
        lensPrefabs[n].transform.SetParent(lensPos);
        lensPrefabs[n].transform.localPosition = Vector3.zero;
        lensPrefabs[n].transform.localRotation = Quaternion.identity;
        lensPrefabs[n].GetComponent<BoxCollider>().enabled = true;
        lensQuads[n].SetActive(true);
    }
}
