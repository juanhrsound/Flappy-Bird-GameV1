using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public MeshRenderer meshR;
    private float animationSpeed;


    // Start is called before the first frame update
    void Start()
    {


        StartCoroutine(LerpAnimationSpeed());

    }


    IEnumerator LerpAnimationSpeed()
    {
        float currentTime = 0f;
        float animationDuration = 3f;
        float startValue = 10f;
        float endValue = 0.25f;

        while (currentTime < animationDuration)
        {
            currentTime += Time.deltaTime;
            animationSpeed = Mathf.Lerp(startValue, endValue, currentTime / animationDuration);
            yield return null;
        }
        //yield return new WaitForSeconds(5);

    }


    // Update is called once per frame
    void Awake()
    {
        meshR = GetComponent<MeshRenderer>();
        
    }

    private void Update()
    {
        meshR.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }

}
