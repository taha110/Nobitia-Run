#pragma strict

public static var deathCounter = 0;

function Start () {

}

function Update () {

 if(Input.GetKeyDown(KeyCode.F))
          {
          }
          if(Input.GetKeyDown(KeyCode.G))
          {
               Fade(1,1.0);
          }
}

function OnTriggerEnter2D (other :  Collider2D) {
               Fade(1,0.0);
              // Destroy (gameObject, 0.5f);
	}

 function Fade(time: float, targetAlpha: float)
      {
           var t = 0.0;
           var currentAlpha = GetComponent.<Renderer>().material.color.a;
           while(t <= 1)
           {
               GetComponent.<Renderer>().material.color.a = Mathf.Lerp(currentAlpha, targetAlpha, t);
               t += Time.deltaTime/time;
               yield;
 
           }
           GetComponent.<Renderer>().material.color.a = targetAlpha;
      }