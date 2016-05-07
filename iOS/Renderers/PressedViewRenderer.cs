//
// Copyright 2016 ArcTouch LLC.
// All rights reserved.
//
// This file, its contents, concepts, methods, behavior, and operation
// (collectively the "Software") are protected by trade secret, patent,
// and copyright laws. The use of the Software is governed by a license
// agreement. Disclosure of the Software to third parties, in any form,
// in whole or in part, is expressly prohibited except as authorized by
// the license agreement.
//
using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using TDCArcTouch;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(PressedView), typeof(TDCArcTouch.iOS.PressedViewRenderer))]
namespace TDCArcTouch.iOS
{
	public class PressedViewRenderer : VisualElementRenderer<PressedView>
	{
		private UITapGestureRecognizer tapRecognizer;

		public PressedViewRenderer()
		{
			this.tapRecognizer = new UITapGestureRecognizer(RaiseTapped)
				{
					DelaysTouchesBegan = false
				};
		}

		protected override void OnElementChanged(ElementChangedEventArgs<PressedView> e) 
		{
			if (base.Element != null)
			{
				this.RemoveGestureRecognizer(this.tapRecognizer);
			}

			base.OnElementChanged(e);

			if (base.Element != null) 
			{
				this.AddGestureRecognizer(this.tapRecognizer);
			}
		}

		public override void TouchesBegan(Foundation.NSSet touches, UIKit.UIEvent evt)
		{
			base.TouchesBegan(touches, evt);

			if (base.Element != null)
			{
				((PressedView)base.Element).SetPressed(true);
			}
		}

		public override void TouchesCancelled(Foundation.NSSet touches, UIKit.UIEvent evt)
		{
			base.TouchesCancelled(touches, evt);

			if (base.Element != null)
			{
				((PressedView)base.Element).SetPressed(false);
			}
		}

		public override void TouchesEnded(Foundation.NSSet touches, UIKit.UIEvent evt)
		{
			base.TouchesEnded(touches, evt);

			if (base.Element != null)
			{
				((PressedView)base.Element).SetPressed(false);
			}
		}

		private void RaiseTapped()
		{
			if (base.Element != null)
			{
				((PressedView)base.Element).RaiseTapped();
			}
		}
	}
}

