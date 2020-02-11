using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor_Player : MonoBehaviour
{
    //Componets
    private Rigidbody2D kinematic2D;

    //Animation
    private Animator anim_control;
    enum WALK_DIR : int { IDLE, UP, DOWN, LEFT, RIGHT }

    //Movement

    const float pixel_aspect = 32f;
    public float walk_speed = 1f;
    
    //private Vector3 linear_velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        //Set Componets
        kinematic2D = GetComponent <Rigidbody2D>();

        anim_control = GetComponent<Animator>();

    }

    // Movement and Input
    private void FixedUpdate()
    {
        Pixel_Perfect_Movement(pixel_aspect);
    }

    void Pixel_Perfect_Movement(float pixel_unit)
    {
        // New velocity based on direction of player input
        Vector2 current_velocity = Float2PixelPerfect(Direction_Movement() * walk_speed, pixel_unit) * Time.fixedDeltaTime;

        //Set current velocity
        kinematic2D.velocity = current_velocity;
        

    }

    Vector2 Direction_Movement()
    {
        // Create direction for player movement
        Vector2 accel_dir = Vector3.zero;
        WALK_DIR new_anim = WALK_DIR.IDLE;


        // Input Walk Movement
        if (Input.GetKey(KeyCode.W))
        { accel_dir.y += 1; new_anim = WALK_DIR.UP; }

        else if (Input.GetKey(KeyCode.S))
        { accel_dir.y += -1; new_anim = WALK_DIR.DOWN; }

        else if (Input.GetKey(KeyCode.A))
        { accel_dir.x += -1; new_anim = WALK_DIR.LEFT; }

        else if (Input.GetKey(KeyCode.D))
        { accel_dir.x += 1; new_anim = WALK_DIR.RIGHT; }

        //if (new_anim != WALK_DIR.IDLE) anim_control.SetInteger("Walk_Dir", (int)new_anim); anim_control.speed = 1; }else {  }

        return accel_dir;
    }

    Vector2 Float2PixelPerfect(Vector2 old_vector, float pixelperUnit)
    {
        Vector2 new_round_vector = new Vector2(
            Mathf.RoundToInt(old_vector.x * pixelperUnit),
            Mathf.RoundToInt(old_vector.y * pixelperUnit)
            );

        return new_round_vector / pixelperUnit;
    }
}
