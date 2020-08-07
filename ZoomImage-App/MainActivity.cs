using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using Com.Jsibbold.Zoomage;

namespace ZoomImage_App
{
    [Android.App.Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public partial class MainActivity : AppCompatActivity, View.IOnClickListener, CompoundButton.IOnCheckedChangeListener
    {
        private ZoomageView demoView;
        private View optionsView;
        private AlertDialog optionsDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            demoView = FindViewById<ZoomageView>(Resource.Id.demoView);
            PrepareOptions();
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.options_menu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (!optionsDialog.IsShowing)
            {
                optionsDialog.Show();
            }
            return base.OnOptionsItemSelected(item);
        }

        private void PrepareOptions()
        {
            optionsView = LayoutInflater.Inflate(Resource.Layout.zoomage_options, null);
            SetSwitch(Resource.Id.zoomable, demoView.Zoomable);
            SetSwitch(Resource.Id.translatable, demoView.Translatable);
            SetSwitch(Resource.Id.animateOnReset, demoView.AnimateOnReset);
            SetSwitch(Resource.Id.autoCenter, demoView.AutoCenter);
            SetSwitch(Resource.Id.restrictBounds, demoView.RestrictBounds);
            optionsView.FindViewById(Resource.Id.reset).SetOnClickListener(this);
            optionsView.FindViewById(Resource.Id.autoReset).SetOnClickListener(this);

            optionsDialog = new AlertDialog.Builder(this).SetTitle("Zoomage Options")
                    .SetView(optionsView)
                    .SetPositiveButton("Close", OnClickOK)
                    .Create();
        }

        private void OnClickOK(object sender, DialogClickEventArgs e)
        {

        }

        private void SetSwitch(int id, bool state = false)
        {
            SwitchCompat switchView = optionsView.FindViewById<SwitchCompat>(id);
            switchView.SetOnCheckedChangeListener(this);
            switchView.Checked = state;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.reset)
            {
                demoView.Reset();
            }
            else
            {
                ShowResetOptions();
            }
        }

        private void ShowResetOptions()
        {
            string[] options = new string[] { "Under", "Over", "Always", "Never" };

            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetItems(options, new AlertDialogClick(demoView));

            builder.Create().Show();
        }

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            switch (buttonView.Id)
            {
                case Resource.Id.zoomable:
                    demoView.Zoomable = isChecked;
                    break;
                case Resource.Id.translatable:
                    demoView.Translatable = isChecked;
                    break;
                case Resource.Id.restrictBounds:
                    demoView.RestrictBounds = isChecked;
                    break;
                case Resource.Id.animateOnReset:
                    demoView.AnimateOnReset = isChecked;
                    break;
                case Resource.Id.autoCenter:
                    demoView.AutoCenter = isChecked;
                    break;
            }
        }
    }
}