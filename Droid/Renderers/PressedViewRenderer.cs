using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using TDCArcTouch;

[assembly: ExportRenderer(typeof(PressedView), typeof(TDCArcTouch.Droid.PressedViewRenderer))]
namespace TDCArcTouch.Droid
{
	public class PressedViewRenderer : VisualElementRenderer<PressedView>
	{
		private const int MIN_ELAPSED_TIME_MS = 150;

		private bool cancelTouch;
		private long lastUpTime;

		public PressedViewRenderer()
		{
		}

		public override bool OnTouchEvent(global::Android.Views.MotionEvent e)
		{
			switch (e.Action)
			{
				case global::Android.Views.MotionEventActions.Down:
					return OnTouchDown(e);
				case global::Android.Views.MotionEventActions.Up:
					return OnTouchUp(e);
				case global::Android.Views.MotionEventActions.Cancel:
					return OnTouchCancel(e);
				case global::Android.Views.MotionEventActions.Move:
					return OnTouchMove(e);
			}
			return base.OnTouchEvent(e);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<PressedView> e)
		{
			base.OnElementChanged(e);

			if (base.Element != null)
			{
				((PressedView)base.Element).SetPressed(false);
			}
		}

		private bool OnTouchDown(global::Android.Views.MotionEvent e)
		{
			this.cancelTouch = false;

			if (base.Element != null)
			{
				//((PressedView)this.Element).IsPressed = true;
				((PressedView)base.Element).SetPressed(true);
			}

			return true;
		}

		private bool OnTouchUp(global::Android.Views.MotionEvent e)
		{
			if (base.Element != null)
			{
				if (!this.cancelTouch)
				{
					//((PressedView)this.Element).IsPressed = false;
					((PressedView)base.Element).SetPressed(false);
					if ((e.EventTime - this.lastUpTime) > MIN_ELAPSED_TIME_MS)
					{
						((PressedView)this.Element).RaiseTapped();
					}
				}
			}

			this.lastUpTime = e.EventTime;

			return true;
		}

		private bool OnTouchCancel(global::Android.Views.MotionEvent e)
		{
			if (base.Element != null)
			{
				//((PressedView)this.Element).IsPressed = false;
				((PressedView)base.Element).SetPressed(false);
			}

			return true;
		}

		private bool OnTouchMove(global::Android.Views.MotionEvent e)
		{
			if (base.ViewGroup != null)
			{
				int width = base.ViewGroup.Width;
				int height = base.ViewGroup.Height;
				if ((e.GetX() < 0) || (e.GetY() < 0) || (e.GetX() >= width) || (e.GetY() >= height))
				{
					this.cancelTouch = true;
					if (base.Element != null)
					{
						//((PressedView)this.Element).IsPressed = false;
						((PressedView)base.Element).SetPressed(false);
					}
				}
			}

			return true;
		}
	}
}