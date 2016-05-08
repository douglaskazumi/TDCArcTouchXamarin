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
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace InfColorPickerBinding
{
	static class CFunctions
	{
		// extern float pin (float minValue, float value, float maxValue);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern float pin (float minValue, float value, float maxValue);

		// extern void HSVtoRGB (float h, float s, float v, float *r, float *g, float *b);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern unsafe void HSVtoRGB (float h, float s, float v, float* r, float* g, float* b);

		// extern void RGBToHSV (float r, float g, float b, float *h, float *s, float *v, BOOL preserveHS);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern unsafe void RGBToHSV (float r, float g, float b, float* h, float* s, float* v, bool preserveHS);

		// extern CGImageRef createSaturationBrightnessSquareContentImageWithHue (float hue);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern unsafe CGImage createSaturationBrightnessSquareContentImageWithHue (float hue);

		// extern CGImageRef createHSVBarContentImage (InfComponentIndex barComponentIndex, float *hsv);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern unsafe CGImage createHSVBarContentImage (InfComponentIndex barComponentIndex, float[] hsv);
	}

	public enum InfComponentIndex : uint
	{
		Hue = 0,
		Saturation = 1,
		Brightness = 2
	}
}

