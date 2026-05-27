using System.Collections;
using TMPro;
using UnityEngine;

namespace CleanRefactor
{
    public class ShopVFX : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;

        public void PlayPurchaseSound()
        {
            audioSource.Play();
        }

        public void DisplayPurchaseFeedback(ShopNotification notification, TextMeshProUGUI feedbackText)
        {
            StartCoroutine(DisplayFeedbackCoroutine(notification, feedbackText));
        }

        IEnumerator DisplayFeedbackCoroutine(ShopNotification notification, TextMeshProUGUI feedbackText)
        {
            string message = string.Empty;
            switch (notification.type)
            {
                case ShopNotification.NotificationType.PurchaseComplete:
                    message = "Purchase Complete!";
                    PlayPurchaseSound();
                    break;
                case ShopNotification.NotificationType.NotEnoughCoins:
                    message = "Not enough coins!";
                    break;
                case ShopNotification.NotificationType.MaxUsesReached:
                    message = "Max uses reached!";
                    break;
                case ShopNotification.NotificationType.RequiredLevelNotReached:
                    message = "Required level not reached!";
                    break;
                case ShopNotification.NotificationType.AlreadyOwned:
                    message = "Item already owned!";
                    break;
            }

            feedbackText.text = message;
            yield return new WaitForSeconds(2f);
            feedbackText.text = "Buy";
        }
    }
}
