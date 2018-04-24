﻿// /*******************************************************************************
//  * Copyright 2012-2018 Esri
//  *
//  *  Licensed under the Apache License, Version 2.0 (the "License");
//  *  you may not use this file except in compliance with the License.
//  *  You may obtain a copy of the License at
//  *
//  *  http://www.apache.org/licenses/LICENSE-2.0
//  *
//  *   Unless required by applicable law or agreed to in writing, software
//  *   distributed under the License is distributed on an "AS IS" BASIS,
//  *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  *   See the License for the specific language governing permissions and
//  *   limitations under the License.
//  ******************************************************************************/

using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Esri.ArcGISRuntime.Toolkit.UI;
using Esri.ArcGISRuntime.Toolkit.UI.Controls;

namespace Esri.ArcGISRuntime.Toolkit.Internal
{
    /// <summary>
    /// Helper class for providing common cross-platform names for UI component manipulation
    /// </summary>
    internal static class ViewExtensions
    {
        private static DisplayMetrics s_displayMetrics;
        private static IWindowManager s_windowManager;

        public static void SetMargin(this View view, double left, double top, double right, double bottom)
        {
            if (view.LayoutParameters is ViewGroup.MarginLayoutParams layoutParams)
            {
                layoutParams.LeftMargin = (int)Math.Round(left);
            }
        }

        public static double GetActualWidth(this View view) => view.MeasuredWidth;

        public static double GetActualHeight(this View view) => view.MeasuredHeight;

        public static void SetWidth(this RectangleView view, double width)
        {
            if (view == null)
            {
                return;
            }

            view.Width = width;
        }

        public static bool GetIsVisible(this View view) => view.Visibility == ViewStates.Visible;

        public static void SetIsVisible(this View view, bool isVisible) => view.Visibility = isVisible ? ViewStates.Visible : ViewStates.Gone;

        public static double GetOpacity(this View view) => view.Alpha;

        public static void SetOpacity(this View view, double opacity) => view.Alpha = (float)opacity;

        public static bool GetIsEnabled(this View view) => view.Enabled;

        public static void SetIsEnabled(this View view, bool enabled) => view.Enabled = enabled;

        public static void Arrange(this View view, RectF bounds)
        {
            if (bounds.Width() == 0 && bounds.Height() == 0)
            {
                view.SetIsVisible(false);
            }
            else
            {
                view.SetIsVisible(true);
                view.SetMargin(bounds.Left, bounds.Top, bounds.Right, bounds.Bottom);
            }
        }

        public static void SetBackgroundColor(this View view, Color color) => view.SetBackgroundColor(color);

        public static void SetBorderColor(this View view, Color color)
        {
            throw new NotImplementedException();

            //view.BorderColor = color;
        }

        public static void SetBorderColor(this RectangleView view, Color color)
        {
            throw new NotImplementedException();

            //view.BorderColor = color;
        }

        //public static void SetBorderColor(this DrawActionButton view, UIColor color) => view.BorderColor = color;

        //public static void SetBorderColor(this DrawActionToggleButton view, UIColor color) => view.BorderColor = color;

        public static void SetBorderWidth(this View view, double width)
        {
            throw new NotImplementedException();

            //view.BorderWidth = width;
        }

        public static void SetTextColor(this TextView label, Color color) => label.SetTextColor(color);

        public static void RemoveChild(this ViewGroup parent, View child) => parent.RemoveView(child);

        public static IEnumerable<View> GetChildren(this ViewGroup parent)
        {
            var children = new List<View>();
            for (var i = 0; i < parent.ChildCount; i++)
            {
                children.Add(parent.GetChildAt(i));
            }

            return children;
        }

        public static void Measure(this View view, SizeF availableSize) => view.Measure((int)Math.Round(availableSize.Width), (int)Math.Round(availableSize.Height));

        // Gets a display metrics object for calculating display dimensions
        internal static DisplayMetrics GetDisplayMetrics()
        {
            if (s_displayMetrics == null)
            {
                if (s_windowManager == null)
                {
                    s_windowManager = Application.Context?.GetSystemService(Context.WindowService)?.JavaCast<IWindowManager>();
                }

                if (s_windowManager == null)
                {
                    s_displayMetrics = Application.Context?.Resources?.DisplayMetrics;
                }
                else
                {
                    s_displayMetrics = new DisplayMetrics();
                    s_windowManager.DefaultDisplay.GetMetrics(s_displayMetrics);
                }
            }

            return s_displayMetrics;
        }
    }
}
