var maxX = 6.1;
var minX = -6.1;
var moveSpeed = 22.0;
     
private var tChange: float = 0; // force new direction in the first Update
private var randomX: float;

public var active: System.Boolean;

function Update () {
    if (active) {
        // change to random direction at random intervals
        if (Time.time >= tChange){
            randomX = Random.Range(-5.0,5.0); // with float parameters, a random float
            // set a random interval between 0.7 and 0.9
            tChange = Time.time + Random.Range(0.7, 0.9);
        }
        transform.Translate(Vector3(randomX,0,0) * moveSpeed * Time.deltaTime);
        // if object reached any border, revert the appropriate direction
        if (transform.position.x >= maxX || transform.position.x <= minX) {
            randomX = -randomX;
        }
        // make sure the position is inside the borders
        transform.position.x = Mathf.Clamp(transform.position.x, minX, maxX);
    }
}