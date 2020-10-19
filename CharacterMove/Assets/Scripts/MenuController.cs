using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuContoller : MonoBehaviour
{
    [SerializeField] private Transform centerPoint;
    [SerializeField] private Transform pasuePoint;

    [SerializeField] private Transform playButton;
    private float pausePanelY;
    private bool isPause;
    
    
    void Start()
    {
        pausePanelY = pasuePoint.transform.position.y;
        
    }

  public void ShowPausePanel()
    {
        var posY = isPause ? pausePanelY : centerPoint.transform.position.y;
        pasuePoint.DOMoveY(posY, 1);
        if (isPause)
        {
            var sequece = DOTween.Sequence();
            sequece.Append(playButton.DOScale(Vector3.one, 0.5f));
            sequece.Append(playButton.DOShakeRotation(2f, new Vector3(0, 0, 90),
                40,60));
            sequece.Append(playButton.DOJump(new Vector3(playButton.transform.position.x,
                playButton.transform.position.y +10f,playButton.transform.position.z),2f ,1,1));
        }
        else
        {
            playButton.DOScale(Vector3.zero, 0.5f);
        }
        isPause = !isPause;
    }
    
  
}
