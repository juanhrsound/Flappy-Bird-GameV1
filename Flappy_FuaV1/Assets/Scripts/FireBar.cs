using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{
    public Slider slider;
    public Image currentImage;
    public Sprite[] chooseSprite;
    public Animator anim;
    public AudioSource firebarLoop;
    public AudioClip fireClick;
    



    void Start()
    {
        slider = GetComponent<Slider>();
        currentImage = GetComponent<Image>();        
        currentImage.sprite = chooseSprite[0];
        anim = GetComponent<Animator>();
        anim.enabled = false;


    }

    private void Update()
    {
        
        StartCoroutine(SettingBar());


    }

    public void TheFireBar(int fireValue)
    {
        if (fireValue <= 8)
        {
            currentImage.sprite = chooseSprite[fireValue];

        }

        if(fireValue == 8)
        {
            firebarLoop.Play();
            firebarLoop.PlayOneShot(fireClick);
        }

    }

    IEnumerator SettingBar()
    {
     
        if(FindObjectOfType<GameManager>().fireMax >= 8)
        {
            anim.enabled = true;
            anim.SetBool("fuaReady", true);
            

            if (Input.GetMouseButtonDown(0))
            {
                if (firebarLoop.isPlaying)
                {
                    firebarLoop.Stop();
                    FindObjectOfType<Player>().fuaaa.Play();

                }
                               

                if (FindObjectOfType<Spawner>().mainMusic.isPlaying)
                {
                    FindObjectOfType<Spawner>().mainMusic.Stop();
                    FindObjectOfType<Spawner>().hiHat.Play();
                }

                
                
                FindObjectOfType<GameManager>().fireMax = 0;
                FindObjectOfType<AlmostBurned>().almostBurned_B = false;
                currentImage.sprite = chooseSprite[0];
                anim.SetBool("fuaReady", false);
                anim.enabled = false;
                

                FindObjectOfType<Parallax>().StartCoroutine("LerpAnimationSpeed");
                FindObjectOfType<GameManager>().fireMax = 0;
                FindObjectOfType<Player>().FUAState(true);
                FindObjectOfType<Spawner>().StartCoroutine("PowerOn");
                FindObjectOfType<Player>().anim.SetBool("cuchoFua", true);
                


                Time.timeScale *= 3;

                yield return new WaitForSeconds(21.55f);

                Time.timeScale = 1;
                FindObjectOfType<Spawner>().PowerOff();
                FindObjectOfType<Player>().FUAState(false);

                yield return new WaitForSeconds(1f);
                FindObjectOfType<Player>().anim.SetBool("cuchoFua", false);
                FindObjectOfType<AlmostBurned>().almostBurned_B = true;


                yield return new WaitForSeconds(3.8f);
                if (FindObjectOfType<Spawner>().hiHat.isPlaying)
                {
                    FindObjectOfType<Spawner>().hiHat.Stop();
                    FindObjectOfType<Spawner>().mainMusic.Play();
                }


            }

        }

    }








}
