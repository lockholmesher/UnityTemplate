using LTAUnityBase.Base.Controller;
using System;

namespace LTAUnityBase.Base.UI.Effect
{
    public class EffectController : BehaviourController
    {
        protected IEffect[] effects;

        Action endEffect;

        protected virtual void Awake()
        {
            effects = GetComponents<IEffect>();
        }

        protected void ShowEffect()
        {
            foreach (IEffect effect in effects)
            {
                effect.ShowEffect();
            }
        }

        protected void HidEffect()
        {
            foreach (IEffect effect in effects)
            {
                effect.HideEffect();
            }
        }
    }
}
