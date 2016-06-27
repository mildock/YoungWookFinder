using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Speech.Tts;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace YW.Mobile.YoungWookFinder
{
    [Activity(Label = "YW.Mobile.YoungWookFinder", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnFind = null;
        Android.Speech.Tts.TextToSpeech textToSpeech;
        MapFragment mapMain = null;
        GoogleMap map = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            SetObject();

            btnFind.Click += BtnFind_Click;

        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            //textToSpeech.Speak("촬리야", QueueMode.Add , null);


            //var geoUri = Android.Net.Uri.Parse("geo:42.374260,-71.120824");
            //var mapIntent = new Intent(Intent.ActionView, geoUri);
            //StartActivity(mapIntent);

            if (map != null)
            {
                LatLng location = new LatLng(37.545645, 127.134824);
                CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
                builder.Target(location);
                builder.Zoom(18);
                //builder.Bearing(155);     //회전
                //builder.Tilt(65);           //기울기
                CameraPosition cameraPosition = builder.Build();
                CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);


                MarkerOptions markerOpt1 = new MarkerOptions();
                markerOpt1.SetPosition(new LatLng(37.545645, 127.134824));
                markerOpt1.SetTitle("김영욱");
                
                map.AddMarker(markerOpt1);

                map.MoveCamera(cameraUpdate);
            }
        }

        private void SetObject()
        {
            this.ActionBar.Hide();
            btnFind = FindViewById<Button>(Resource.Id.btnFind);
            textToSpeech = new Android.Speech.Tts.TextToSpeech(Application.Context, null);
            mapMain = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.mapMain);
            map = mapMain.Map;
            //map.MapType = GoogleMap.MapTypeNormal;
            map.UiSettings.ZoomControlsEnabled = true;

        }
    }
}

