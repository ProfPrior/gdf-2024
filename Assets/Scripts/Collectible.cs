using UnityEngine;

public class Collectible : MonoBehaviour {
    private float rotationSpeed = 90.0f;

    [SerializeField] private GameObject collectEffect;
    [SerializeField] private AudioClip collectSound;

    // Update is called once per frame
    void Update() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(collectSound);
            Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
