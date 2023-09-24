using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public class Menu : MonoBehaviour
    {
        public void OnPlayButton()
        {
            SceneManager.LoadScene(1);
        }

        public void OnQuitButton()
        {
            Application.Quit();
        }

        public void Level1Button()
        {
            SceneManager.LoadScene(1);
        }
        public void Level2Button()
        {
            SceneManager.LoadScene(2);
        }
        public void Level3Button()
        {
            SceneManager.LoadScene(3);
        }
    }
}
