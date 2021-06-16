using LTAUnityBase.Base.DesignPattern;
public class UserInfo
{
    float gold;
    float gem;

    public float Gold
    {
        set
        {
            gold = value;
            Observer.Instance.Notify(ObserverKey.UpdateUserInfo);
        }
        get
        {
            return gold;
        }
    }

    public float Gem
    {
        set
        {
            gem = value;
            Observer.Instance.Notify(ObserverKey.UpdateUserInfo);
        }
        get
        {
            return gem;
        }
    }

}
