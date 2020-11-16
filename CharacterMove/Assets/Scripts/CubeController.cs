using DG.Tweening;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public void PlayAnimation()
    {
        var targetPosition = transform.up * 3f;
        var duration = 1f;
        var eulerAngles = new Vector3(0, 180, 0);
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(targetPosition, duration));
        sequence.Join(transform.DORotate(eulerAngles, duration));
        sequence.AppendInterval(1);
        sequence.Append(transform.DOScale(Vector3.one * 0.75f, 0.3f));
        sequence.Append(transform.DOScale(Vector3.one * 1.5f, 1));
        sequence.Join(transform.DORotate(eulerAngles, 1f, RotateMode.LocalAxisAdd));
        sequence.Append(transform.DOScale(Vector3.one, 0.2f));
        sequence.OnComplete(OnComplete);
    }

    private void OnComplete()
    {
    }
}