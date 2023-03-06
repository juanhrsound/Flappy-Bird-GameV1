using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public MeshRenderer meshR;
    public float animationSpeed = 0.5f;
        

    void Awake()
    {
        meshR = GetComponent<MeshRenderer>();
        
    }

    public IEnumerator LerpAnimationSpeed()
    {

        float currentTime = 0f;
        float animationDuration = 0f;
        float startValue = 10f;
        float endValue = 50f;

        while (currentTime < animationDuration)
        {
            currentTime += Time.deltaTime;
            animationSpeed = Mathf.Lerp(startValue, endValue, currentTime / animationDuration);
            yield return null;
        }

    }

    private void FixedUpdate()
    {
        meshR.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }

}
