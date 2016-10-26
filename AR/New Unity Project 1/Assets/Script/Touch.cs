using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {
    Vector2 my_screenpos = new Vector2();
    private Animation an1;
    //public GameObject huo_BJ_03;想找个技能特效文件不好使了

	// Use this for initialization
	void Start () {
        Input.multiTouchEnabled = true;
        an1 = this.GetComponent<Animation>();
	
	}
    void MobileTouchInput()
    {
        if(Input.touchCount<=0)
        {
            return;
        }
        else if(Input.touchCount==1)
        {
            if (Input.touches[0].phase == TouchPhase.Began) ;
              my_screenpos = Input.touches[0].position;
       if(an1.Play("idle"))
       {
           an1.Play("attack03");
           //Instantiate(huo_BJ_03, transform.position, Quaternion.identity);
           //des(huo_BJ_03);
       }else
       {   
               an1.Play("idle");   
       }
        }
        else if(Input.touches[0].phase==TouchPhase.Moved)
        {
            Debug.Log("MOVED");
        }
        if (Input.touches[0].phase == TouchPhase.Ended && Input.touches[0].phase != TouchPhase.Canceled)
        {
            Vector2 pos = Input.touches[0].position;
            Debug.Log("TOUCHOUTED");
            //手指松开了
        }
    }
    IEnumerator des(GameObject  go)
    {
        yield return new WaitForSeconds(an1["attck03"].length);
        Destroy(go);
    }
	
	// Update is called once per frame
	void Update () {
        MobileTouchInput();
        print("123");
        if(!an1.isPlaying)
        {
            an1.Play("idle");
        }
	
	}
}
