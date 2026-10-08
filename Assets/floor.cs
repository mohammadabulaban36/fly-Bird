using UnityEngine;

public class floor : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Bird.gameRunning == true)
        {

            transform.Translate(-0.04f, 0, 0);

            if (transform.position.x < -6.1f)
            {
                Vector3 ne = transform.position;
                ne.x = 0;

                transform.position = ne;
            }
        }
}
}



