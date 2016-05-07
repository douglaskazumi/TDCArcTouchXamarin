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
using System.Collections.Generic;

using Xamarin.Forms;

namespace TDCArcTouch
{
	public partial class CustomPage : ContentPage
	{
		public CustomPage()
		{
			InitializeComponent();
			BindingContext = new CustomPageModel();
		}
	}
}

