using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using System.Collections.Generic;

namespace SignalR.Droid
{
    [Activity(Label = "SignalR", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var client = new Client("Android");

            var input = FindViewById<EditText>(Resource.Id.Input);
            var button = FindViewById<Button>(Resource.Id.Button);
            var messages = FindViewById<ListView>(Resource.Id.Messages);

            var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, new List<string>());

            messages.Adapter = adapter;

            await client.Connect();

            button.Click +=

            //input.EditorAction +=
              delegate
              {
                  inputManager.HideSoftInputFromWindow(input.WindowToken, HideSoftInputFlags.None);

                  if (string.IsNullOrEmpty(input.Text))
                      return;

                  client.Send(input.Text);

                  input.Text = "";
              };

            client.OnMessageReceived +=
              (sender, message) => RunOnUiThread(() =>
                adapter.Add(message));
        }
    }
}


