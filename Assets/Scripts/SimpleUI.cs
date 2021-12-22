// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class SimpleUI : MonoBehaviour
// {
//     public Button[] options;
//     public ARPlaceObject arHandler;
//     public int index = 0;

//     void Start()
//     {
//         arHandler = FindObjectOfType<ARPlaceObject>();
//         arHandler.simpleUI = this;

//         for (int i = 0; i < options.Length; i++)
//         {
//             int closureIndex = i ; // Prevents the closure problem
//             options[i].onClick.AddListener(() => TaskOnClick(closureIndex));
//         }
//     }

//     void TaskOnClick(int option)
//     {
//         index = option;
//     }
// }
