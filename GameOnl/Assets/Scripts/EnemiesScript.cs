using Unity.VisualScripting;
using UnityEngine;

public class EnemiesScript : MonoBehaviour
{
    public float start, end;
    private bool isRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var positionEnemy = transform.position.x;
        if(positionEnemy < start)
        {
            isRight = true;
        }

        if (positionEnemy > end)
        {
            isRight = false;
        }


        Vector2 scale = transform.localScale;
        if(isRight)
        {
            scale.x = -1;
            transform.Translate(Vector3.right * 2f * Time.deltaTime);
        }
        else
        {
            scale.x = 1;
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
        }
        transform.localScale = scale;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "A")
        {
            isRight = !isRight;
        }
    }
}
