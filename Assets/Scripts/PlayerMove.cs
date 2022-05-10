using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 50f;

    string GroundTag = "Level";
    string CollectTag = "gem";

    private Rigidbody rb;
    bool isGround = true;

    private int score = 25;

    public TextMeshProUGUI rem, win, info;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        info.text = SystemInfo.deviceUniqueIdentifier;

        float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(x * speed * Time.deltaTime, 0, -z * speed * Time.deltaTime);

        rb.AddForce(force);

        if(transform.position.y < -20)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(0, 400f, 0);
            isGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GroundTag)
        {
            isGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CollectTag)) {
            other.enabled = false;
            score--;
            rem.text = "Remaining - " + score.ToString();
            if(score == 0)
            {
                win.gameObject.SetActive(true);
            }
        }
    }
}
