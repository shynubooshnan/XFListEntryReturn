using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ListViewKeyboardEntry;
using ListViewKeyboardEntry.Droid;
using ListViewKeyboardHelper;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace ListViewKeyboardEntry.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
            }
        }

        /// <summary>
        /// on key down
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            base.OnKeyDown(keyCode, e);
            Console.WriteLine(keyCode);
            if (keyCode == Keycode.NavigateNext) // check and update key code for soft keyboard next
                UtilityHelper.ShouldBlockReturn = true;
            else
                UtilityHelper.ShouldBlockReturn = false;
            return false;
        }

    }
}
