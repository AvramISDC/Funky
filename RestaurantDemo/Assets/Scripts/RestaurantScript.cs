using UnityEngine;
using UnityEngine.SceneManagement;

public class RestaurantScript : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene(1);
    }

    public void VisitRestaurant()
    {
        SceneManager.LoadScene(4);
    }

    public void VisitReservation()
    {
        SceneManager.LoadScene(5);
    }

}
