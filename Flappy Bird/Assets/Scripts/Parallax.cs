using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public MeshRenderer meshR;
    public float animationSpeed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        
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
