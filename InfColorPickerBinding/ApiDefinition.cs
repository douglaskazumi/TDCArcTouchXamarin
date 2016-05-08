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
using System.Runtime.InteropServices;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace InfColorPickerBinding
{
	// @interface InfColorBarView : UIView
	[BaseType (typeof(UIView))]
	interface InfColorBarView
	{
	}

	// @interface InfColorBarPicker : UIControl
	[BaseType (typeof(UIControl))]
	interface InfColorBarPicker
	{
		// @property (nonatomic) float value;
		[Export ("value")]
		float Value { get; set; }
	}

	// @interface InfColorIndicatorView : UIView
	[BaseType (typeof(UIView))]
	interface InfColorIndicatorView
	{
		// @property (nonatomic) UIColor * color;
		[Export ("color", ArgumentSemantic.Assign)]
		UIColor Color { get; set; }
	}

	// @interface InfColorPickerController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface InfColorPickerController
	{
		// +(InfColorPickerController *)colorPickerViewController;
		[Static]
		[Export ("colorPickerViewController")]
		//[Verify (MethodToProperty)]
		InfColorPickerController ColorPickerViewController { get; }

		// +(CGSize)idealSizeForViewInPopover;
		[Static]
		[Export ("idealSizeForViewInPopover")]
		//[Verify (MethodToProperty)]
		CGSize IdealSizeForViewInPopover { get; }

		// -(void)presentModallyOverViewController:(UIViewController *)controller;
		[Export ("presentModallyOverViewController:")]
		void PresentModallyOverViewController (UIViewController controller);

		// @property (nonatomic) UIColor * sourceColor;
		[Export ("sourceColor", ArgumentSemantic.Assign)]
		UIColor SourceColor { get; set; }

		// @property (nonatomic) UIColor * resultColor;
		[Export ("resultColor", ArgumentSemantic.Assign)]
		UIColor ResultColor { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		InfColorPickerControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<InfColorPickerControllerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @protocol InfColorPickerControllerDelegate
	[BaseType(typeof(NSObject))]
	[Model]
	interface InfColorPickerControllerDelegate
	{
		// @optional -(void)colorPickerControllerDidFinish:(InfColorPickerController *)controller;
		[Export ("colorPickerControllerDidFinish:")]
		void ColorPickerControllerDidFinish (InfColorPickerController controller);

		// @optional -(void)colorPickerControllerDidChangeColor:(InfColorPickerController *)controller;
		[Export ("colorPickerControllerDidChangeColor:")]
		void ColorPickerControllerDidChangeColor (InfColorPickerController controller);
	}

	// @interface InfColorPickerNavigationController : UINavigationController
	[BaseType (typeof(UINavigationController))]
	interface InfColorPickerNavigationController
	{
	}

	// @interface InfColorSquareView : UIImageView
	[BaseType (typeof(UIImageView))]
	interface InfColorSquareView
	{
		// @property (nonatomic) float hue;
		[Export ("hue")]
		float Hue { get; set; }
	}

	// @interface InfColorSquarePicker : UIControl
	[BaseType (typeof(UIControl))]
	interface InfColorSquarePicker
	{
		// @property (nonatomic) float hue;
		[Export ("hue")]
		float Hue { get; set; }

		// @property (nonatomic) CGPoint value;
		[Export ("value", ArgumentSemantic.Assign)]
		CGPoint Value { get; set; }
	}

	// @interface InfSourceColorView : UIControl
	[BaseType (typeof(UIControl))]
	interface InfSourceColorView
	{
		// @property (nonatomic) BOOL trackingInside;
		[Export ("trackingInside")]
		bool TrackingInside { get; set; }
	}
}

