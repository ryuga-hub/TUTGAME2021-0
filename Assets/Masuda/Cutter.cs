using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public GameObject CutterPrefab;
    public AudioClip CutterSound;
    private float timer = 0.0f;
    private float timeBetweenShot = 4.0f;
    private float power = 1000.0f;
    

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        // もしもzキーを押したならば（条件）
        if (Input.GetKeyDown(KeyCode.Z) && timer > timeBetweenShot)
        {
            timer = 0.0f;
            GameObject Cutter = Instantiate(CutterPrefab, transform.position, Quaternion.identity);
            Rigidbody CutterRb = Cutter.GetComponent<Rigidbody>();
            CutterRb.AddForce(transform.forward * power);
            
            // 発射したカッターを4秒後に破壊する。
            Destroy(Cutter, 4.0f);

            //カッター射出時の音
            AudioSource.PlayClipAtPoint(CutterSound, transform.position);
        }

    }
}
