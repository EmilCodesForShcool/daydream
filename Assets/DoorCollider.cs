    using UnityEngine;
using UnityEngine.SceneManagement;

    public class TriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // This code will execute when another collider enters this trigger.
        Debug.Log("Triggered by: " + other.gameObject.name);

        // You can perform actions based on the 'other' collider,
        // for example, checking its tag or component.
        if (this.gameObject.CompareTag("doorSchool"))
        {
            SceneManager.LoadScene(2);
            // Perform specific actions for the player.
        }
        if (this.gameObject.CompareTag("doorLibrary"))
        {
            SceneManager.LoadScene(3);
            // Perform specific actions for the player.
        }
        if (this.gameObject.CompareTag("doorOffice"))
        {
            SceneManager.LoadScene(4);
            // Perform specific actions for the player.
        }
        if (this.gameObject.CompareTag("doorBedroom"))
        {
            SceneManager.LoadScene(1);
            // Perform specific actions for the player.
        }
    }
}