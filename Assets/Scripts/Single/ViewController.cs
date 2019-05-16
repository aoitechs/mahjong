﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Single.MahjongDataType;
using Single.Managers;
using Single.UI;
using Single.UI.Controller;
using UnityEngine;

namespace Single
{
    public class ViewController : MonoBehaviour
    {
        public static ViewController Instance { get; private set; }

        public BoardInfoManager BoardInfoManager;
        public YamaManager YamaManager;
        public TableTilesManager TableTilesManager;
        public PlayerInfoManager PlayerInfoManager;
        public HandPanelManager HandPanelManager;
        public TimerController TurnTimeController;
        public PlayerEffectManager PlayerEffectManager;
        public InTurnPanelManager InTurnPanelManager;
        public OutTurnPanelManager OutTurnPanelManager;
        public MeldSelectionManager MeldSelectionManager;
        public WaitingPanelManager[] WaitingPanelManagers;
        public RoundDrawManager RoundDrawManager;
        public PointSummaryPanelManager PointSummaryPanelManager;
        public PointTransferManager PointTransferManager;
        public GameEndPanelManager GameEndPanelManager;

        private void OnEnable()
        {
            Instance = this;
        }

        public void AssignRoundStatus(ClientRoundStatus status)
        {
            BoardInfoManager.CurrentRoundStatus = status;
            YamaManager.CurrentRoundStatus = status;
            TableTilesManager.CurrentRoundStatus = status;
            PlayerInfoManager.CurrentRoundStatus = status;
            HandPanelManager.CurrentRoundStatus = status;
            PointTransferManager.CurrentRoundStatus = status;
        }

        public float ShowEffect(int placeIndex, PlayerEffectManager.Type type)
        {
            return PlayerEffectManager.ShowEffect(placeIndex, type);
        }

        public IEnumerator RevealHandTiles(int placeIndex, PlayerHandData handData)
        {
            yield return new WaitForSeconds(MahjongConstants.HandTilesRevealDelay);
            TableTilesManager.OpenUp(placeIndex);
            TableTilesManager.SetHandTiles(placeIndex, handData.HandTiles);
        }
    }
}
