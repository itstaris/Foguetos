using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_instantiator : MonoBehaviour

{
    public GameObject objectToInstantiate;

    // Tempo mínimo e máximo para instanciar um novo obstáculo
    public float minTime;
    public float maxTime;

    // Distância mínima e máxima no eixo Y, eixo X
    public float minY;
    public float maxY;
    private float fixedX = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Instantiating());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Instantiating()
    {
        while(true)
        {
            // Espera um tempo aleatório
            float randomTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(randomTime);

            // Gera uma posição aleatória no eixo Y
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(fixedX, randomY, transform.position.z);

            // Instância
            Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
            //Debug.Log("foi instanciado");
        }
    }
}