using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerActive : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float speed; //distance = duration * speed

    private void Start(){
        StartCoroutine(Countdown(duration));
    }

    private void FixedUpdate(){
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private IEnumerator Countdown(float duration){
        while (duration > 0){
            duration -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<Player>().DropItem(Vector2.zero);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Building")
        {
            collision.gameObject.GetComponent<Building>().pointValue -= 5;
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
