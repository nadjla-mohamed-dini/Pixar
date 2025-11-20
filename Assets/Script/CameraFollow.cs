using UnityEngine;

public class CameraFollow : MonoBehaviour
{
 public Transform followTransform;

 void FixedUpdate()
 {
  this.transform.position= new Vector3(followTransform.position.x,this.transform.position.y,this.transform.position.z);
 }

}
