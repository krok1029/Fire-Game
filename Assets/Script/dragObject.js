var speed = 50;
function OnMouseDrag() {
    transform.position += Vector3.right * Time.deltaTime * Input.GetAxis("Mouse X") * speed*10;
    transform.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse Y") * speed*10;
}

