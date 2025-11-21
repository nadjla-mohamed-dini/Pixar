using UnityEngine;

public class VirusChase2D : MonoBehaviour
{
    public Transform robot;       
    public float BaseSpeed = 3f;      
    public float speedMultiplier = 1f; 

    private Rigidbody2D rb;
    private RobotRunner2D robotRunner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        if (robot !=null)
        {
            robotRunner = robot.GetComponent<RobotRunner2D>();
        }
    }

    void Update()
    {
        if (robot == null || robotRunner == null)  return;
        float directionX = Mathf.Sign(robot.position.x - transform.position.x);

        //speed of the robot 
        float robotSpeed = robotRunner.speed * robotRunner.speedMultiplier;
        float factor = 0.8f;
        if (DataCollect.totalData >= 3 && DataCollect.totalData <= 5)
        {
            factor = 1f;
        }
        else if (DataCollect.totalData > 5)
        {
            factor = 1f; // keep 100 speed on the freeze
        }
        float virusSpeed = BaseSpeed + robotSpeed * factor;
        rb.linearVelocity = new Vector2(directionX * virusSpeed * speedMultiplier, 0);
    }
}
