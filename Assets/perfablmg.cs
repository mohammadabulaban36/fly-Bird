using UnityEngine;

public class perfablmg : MonoBehaviour
{
   
    void FixedUpdate()
    {
        if (Bird.gameRunning == true)
        {
            transform.Translate(-0.04f, 0, 0);

            if (transform.position.x <= -2f)
            {
                Vector3 ne = transform.position;
                ne.x = 7.5f;
                ne.y = Random.Range(-.5f, 0.5f);
                transform.position = ne;
            }
        }
    }
}