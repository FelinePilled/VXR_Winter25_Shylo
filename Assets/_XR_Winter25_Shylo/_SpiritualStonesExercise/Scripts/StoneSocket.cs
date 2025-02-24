using System;
using UnityEngine;


    public class StoneSocket : MonoBehaviour
    {
        [Tooltip("Drag one of the three spiritual stones in here")] //This allows us to display some text when hovering over the variable name in the editor.
        [SerializeField] string Stone;
        public bool isOccupy = false;
        static int NumberOfStones = 0;
        [SerializeField] SlidingDoor SlidingDoor;
        [SerializeField] AudioSource AudioSource;



        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Stone)) 
            { 
                isOccupy = true;
                NumberOfStones++;
                Debug.Log($"{other.gameObject.name} gameobject entered the trigger");
                Debug.Log($"{NumberOfStones} gameobject entered the trigger");
            }

        if (NumberOfStones == 3) 
        {
            SlidingDoor.Open();
            AudioSource.Play();
        }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(Stone))
            {
                isOccupy = false;
                NumberOfStones--;
                Debug.Log($"{other.gameObject.name} gameobject exited the trigger");
                Debug.Log($"{NumberOfStones} gameobject exited the trigger");
            }
        }

}


