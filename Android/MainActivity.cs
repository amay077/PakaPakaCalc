using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PakaPakaCalc.Views;
using PakaPakaCalc.ViewModels;
using Android.Content.PM;

namespace PakaPakaCalc
{
    [Activity(MainLauncher = true, 
        Theme = "@android:style/Theme.Holo.Light", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            var navPage = new NavigationPage(new GameSettingPage());
            SetPage(navPage);
            ActionBar.Hide();
        }

        public override void OnBackPressed()
        {
//            base.OnBackPressed();
        }
    }
}

