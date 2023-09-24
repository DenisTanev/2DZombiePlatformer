using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject PausePanel;

        private void Update()
        {
            
        }

        public void Pause()
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Continue()
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void MainMenu()
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
