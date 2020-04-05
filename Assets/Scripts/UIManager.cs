using Assets.Scripts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {        
        public void StartButtonClicked()
        {
            Debug.Log("Play");
            GameManager.gGameManager.SetGameState(GameState.Play);
            GameManager.gGameManager.PlayGame();
        }
    }
}
