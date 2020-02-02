using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueActive : MonoBehaviour{
   [SerializeField] private float duration;
    /// <summary>
    /// Multiplier to apply to player speed. Enter value between 0.0 and 1.0.
    /// </summary>
    public float  multiplier;

    private void Start(){
        //Debug.Log("START HAS PLAYED");
        StartCoroutine(Countdown(duration));
    }

    private IEnumerator Countdown(float duration){
        while (duration > 0){
            duration -= Time.deltaTime;
            //Debug.Log($"Glue Timer: {duration}");
            yield return null;
        }
        //Debug.Log("I should be fucking dead!");
        Destroy(gameObject);
    }

    //Slow player upon entering
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Player>().speed *= multiplier;
        }
    }

    //Restore player speed upon exit
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().speed /= multiplier;
        }
    }
}
