using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamHOi : MonoBehaviour
{
    public float DoNay = 0.5f;
    public float TocDoNay = 4f;
    private bool DuocNay = true;
    private Vector3 vtDau;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.contacts[0].normal.y > 0)
        {
            vtDau = transform.position;
            KhoiNayLen();
        }
    }
    void KhoiNayLen()
    {
        
        StartCoroutine(KhoiNay());
        DuocNay = false;
    }
    IEnumerator KhoiNay()
    {
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + TocDoNay * Time.deltaTime);
            if (transform.localPosition.y >= vtDau.y + DoNay) break;
            yield return null;
        }
        while(true)
        {
            Score.scorea += 100;
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - TocDoNay * Time.deltaTime);
            if (transform.localPosition.y <= vtDau.y) break;
            Destroy(gameObject);
            GameObject KhoiRong = (GameObject)Instantiate(Resources.Load("Prefabs/KhoiTrong"));
            KhoiRong.transform.position = vtDau;
            yield return null;
        }
    }
}
