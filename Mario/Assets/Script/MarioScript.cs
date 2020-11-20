using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioScript : MonoBehaviour
{
    private float VanToc = 8;
    private float TocDo = 0;
    private float NhayCao = 450;
    private bool DuoiDat = true;
    private bool ChuyenHuong = false;
    private float Down = 3;
    private float SlowJump = 2;
    private new Rigidbody2D rigidbody;

    private bool QuayPhai = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("TocDo", TocDo);
        animator.SetBool("MatDat", DuoiDat);
        animator.SetBool("ChuyenHuong", ChuyenHuong);
        NhayLen();
    }
    private void FixedUpdate()
    {
        DiChuyen();
    }
    void DiChuyen()
    {
        float phimQuaLai = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(VanToc * phimQuaLai, rigidbody.velocity.y);
        TocDo = Mathf.Abs(VanToc * phimQuaLai);
        if(phimQuaLai>0 && !QuayPhai)
        {
            HuongMat();
        }
        if (phimQuaLai < 0 && QuayPhai)
        {
            HuongMat();
        }
    }
    void HuongMat()
    {
        QuayPhai = !QuayPhai;
        Vector2 Huong = transform.localScale;
        Huong.x *= -1;
        transform.localScale = Huong;
        if (TocDo > 0) StartCoroutine(MarioChuyenHuong());
    }
    void NhayLen()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && DuoiDat == true && transform.position.y < 2 )
        {
            rigidbody.AddForce((Vector2.up)* NhayCao);
            DuoiDat = false;
        }
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (Down - 1) * Time.deltaTime;
        }
        else if (rigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (SlowJump - 1) * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MatDat")
        {
            DuoiDat = true;
        }
    }
    IEnumerator MarioChuyenHuong()
    {
        ChuyenHuong = true;
        yield return new WaitForSeconds(0.2f);
        ChuyenHuong = false;
    }
}
