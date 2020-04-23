using ElRaccoone.Tweens.Helpers;
using UnityEngine;

namespace ElRaccoone.Tweens.Core {
  public abstract class TweenBase<T> : TweenInstance {

    [HideInInspector] public T valueFrom = default (T);
    [HideInInspector] public T valueTo = default (T);
    [HideInInspector] public T valueCurrent = default (T);

    private float time = 0;
    private float duration = 0;
    private float delay = 0;
    private Ease ease = 0;
    private bool hasDelay = false;
    private bool didOverwriteFrom = false;
    private bool isLoopPingPongEnabled = false;
    private bool isPlayingForward = true;
    private int loopCount = 0;

    public abstract T OnGetFrom ();
    public abstract void OnUpdate (float easedTime);

    private void Awake () {
      if (this.didOverwriteFrom == false)
        this.valueFrom = this.OnGetFrom ();
    }

    private void Update () {
      if (this.hasDelay == true) {
        this.delay -= Time.deltaTime;
        if (this.delay <= 0)
          this.hasDelay = false;
      } else {
        var _timeDelta = Time.deltaTime / this.duration;
        if (this.isLoopPingPongEnabled == true) {
          this.time += this.isPlayingForward == true ? _timeDelta : -_timeDelta;
          if (this.time > 1) {
            this.isPlayingForward = false;
            this.time = 1;
          } else if (this.time < 0) {
            this.isPlayingForward = true;
            this.time = 0;
          }
          this.OnUpdate (EasingMethods.Apply (this.ease, this.time));
        } else {
          this.time += _timeDelta;
          if (this.time >= 1)
            this.time = 1;
          this.OnUpdate (EasingMethods.Apply (this.ease, this.time));
          if (this.time == 1) {
            if (this.loopCount > 0) {
              this.loopCount -= 1;
              this.time = 0;
            } else {
              Object.Destroy (this);
            }
          }
        }
      }
    }

    internal float InterpolateValue (float from, float to, float time) {
      return from * (1 - time) + to * time;
    }

    public TweenBase<T> Finalize (float duration, T valueTo) {
      this.duration = duration;
      this.valueTo = valueTo;
      return this;
    }

    public TweenBase<T> SetFrom (T valueFrom) {
      this.didOverwriteFrom = true;
      this.valueFrom = valueFrom;
      return this;
    }

    public TweenBase<T> SetLoopPingPong () {
      this.isLoopPingPongEnabled = true;
      return this;
    }

    public TweenBase<T> SetLoopCount (int loopCount) {
      this.loopCount = loopCount;
      return this;
    }

    public TweenBase<T> SetDelay (float delay) {
      this.delay = delay;
      this.hasDelay = true;
      return this;
    }

    public TweenBase<T> SetEase (Ease ease) {
      this.ease = ease;
      return this;
    }

    public TweenBase<T> SetEaseLinear () {
      this.ease = Ease.Linear;
      return this;
    }

    public TweenBase<T> SetEaseSineIn () {
      this.ease = Ease.SineIn;
      return this;
    }

    public TweenBase<T> SetEaseSineOut () {
      this.ease = Ease.SineOut;
      return this;
    }

    public TweenBase<T> SetEaseSineInOut () {
      this.ease = Ease.SineInOut;
      return this;
    }

    public TweenBase<T> SetEaseQuadIn () {
      this.ease = Ease.QuadIn;
      return this;
    }

    public TweenBase<T> SetEaseQuadOut () {
      this.ease = Ease.QuadOut;
      return this;
    }

    public TweenBase<T> SetEaseQuadInOut () {
      this.ease = Ease.QuadInOut;
      return this;
    }

    public TweenBase<T> SetEaseCubicIn () {
      this.ease = Ease.CubicIn;
      return this;
    }

    public TweenBase<T> SetEaseCubicOut () {
      this.ease = Ease.CubicOut;
      return this;
    }

    public TweenBase<T> SetEaseCubicInOut () {
      this.ease = Ease.CubicInOut;
      return this;
    }

    public TweenBase<T> SetEaseQuartIn () {
      this.ease = Ease.QuartIn;
      return this;
    }

    public TweenBase<T> SetEaseQuartOut () {
      this.ease = Ease.QuartOut;
      return this;
    }

    public TweenBase<T> SetEaseQuartInOut () {
      this.ease = Ease.QuartInOut;
      return this;
    }

    public TweenBase<T> SetEaseQuintIn () {
      this.ease = Ease.QuintIn;
      return this;
    }

    public TweenBase<T> SetEaseQuintOut () {
      this.ease = Ease.QuintOut;
      return this;
    }

    public TweenBase<T> SetEaseQuintInOut () {
      this.ease = Ease.QuintInOut;
      return this;
    }

    public TweenBase<T> SetEaseExpoIn () {
      this.ease = Ease.ExpoIn;
      return this;
    }

    public TweenBase<T> SetEaseExpoOut () {
      this.ease = Ease.ExpoOut;
      return this;
    }

    public TweenBase<T> SetEaseExpoInOut () {
      this.ease = Ease.ExpoInOut;
      return this;
    }

    public TweenBase<T> SetEaseCircIn () {
      this.ease = Ease.CircIn;
      return this;
    }

    public TweenBase<T> SetEaseCircOut () {
      this.ease = Ease.CircOut;
      return this;
    }

    public TweenBase<T> SetEaseCircInOut () {
      this.ease = Ease.CircInOut;
      return this;
    }

    public TweenBase<T> SetEaseBackIn () {
      this.ease = Ease.BackIn;
      return this;
    }

    public TweenBase<T> SetEaseBackOut () {
      this.ease = Ease.BackOut;
      return this;
    }

    public TweenBase<T> SetEaseBackInOut () {
      this.ease = Ease.BackInOut;
      return this;
    }

    public TweenBase<T> SetEaseElasticIn () {
      this.ease = Ease.ElasticIn;
      return this;
    }

    public TweenBase<T> SetEaseElasticOut () {
      this.ease = Ease.ElasticOut;
      return this;
    }

    public TweenBase<T> SetEaseElasticInOut () {
      this.ease = Ease.ElasticInOut;
      return this;
    }

    public TweenBase<T> SetEaseBounceIn () {
      this.ease = Ease.BounceIn;
      return this;
    }

    public TweenBase<T> SetEaseBounceOut () {
      this.ease = Ease.BounceOut;
      return this;
    }

    public TweenBase<T> SetEaseBounceInOut () {
      this.ease = Ease.BounceInOut;
      return this;
    }
  }
}
