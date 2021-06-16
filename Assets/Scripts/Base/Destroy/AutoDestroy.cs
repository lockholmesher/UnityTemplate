using UnityEngine;
public class AutoDestroy : MonoBehaviour
{
    IAutoDestroy autoDestroy;

    float timeCount = 0;

    IAutoDestroy OnAutoDestroy
    {
        get
        {
            if (autoDestroy == null)
            {
                autoDestroy = GetComponent<IAutoDestroy>();
            }
            return autoDestroy;
        }
    }

    private void Update()
    {
        if (OnAutoDestroy == null) return;
        if (!OnAutoDestroy.IsAutoDestroy) return;
        if (timeCount <= OnAutoDestroy.TimeCountDestroy)
        {
            timeCount += Time.deltaTime;
            return;
        }
        Destroy(this.gameObject);
    }
}
