using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    //text
    public Text countText;
    public Text winText;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float move_Horizontal = Input.GetAxis("Horizontal");
        float move_Vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(move_Horizontal, 0.0f, move_Vertical);
       /* //transform.rotation = Quaternion.LookRotation(movement);
        // transform.Translate(movement * Time.deltaTime, Space.World); 
        // code not needed as it now doesn't snap back to original position */
        if (movement != Vector3.zero)
        {
            transform.rotation = (Quaternion.LookRotation(movement));
        }

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}