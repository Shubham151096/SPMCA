using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Views.View;
using System.Text.RegularExpressions;
using System.Drawing;
using Xamarin.Essentials;
using Android.Hardware.Input;
using Android.Views.InputMethods;

namespace SPCMA.Activity
{
    [Activity( Theme = "@style/MyTheme.Layout", WindowSoftInputMode = SoftInput.AdjustResize)]
    //public class LoginActivity : AppCompatActivity
    //{
    //    protected override void OnCreate(Bundle savedInstanceState)
    //    {
    //        base.OnCreate(savedInstanceState);
    //        Xamarin.Essentials.Platform.Init(this, savedInstanceState);
    //        SetContentView(Resource.Layout.LoginLayout);

    //        // Create your application here
    //    }


    //}
    public class LoginActivity : AppCompatActivity
    {
        ImageView ShowPassImgBtn, HidePassImgBtn;
        TextView ForgotPassTxtBtn, EmailErrTxt, PassErrTxt, SignUpTxtBtn;
        EditText EmailEditTxt, PasswordEditTxt;
        FrameLayout PassContainerFrame;
        Button LoginBtn;
        int count = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginLayout);
            ShowPassImgBtn = FindViewById<ImageView>(Resource.Id.showPassImgBtn);
            HidePassImgBtn = FindViewById<ImageView>(Resource.Id.hidePassImgBtn);
            ForgotPassTxtBtn = FindViewById<TextView>(Resource.Id.ForgotPasstxtBtn);
            EmailErrTxt = FindViewById<TextView>(Resource.Id.EmailErrTxt);
            PassErrTxt = FindViewById<TextView>(Resource.Id.PassErrTxt);
            PassErrTxt = FindViewById<TextView>(Resource.Id.PassErrTxt);
            SignUpTxtBtn = FindViewById<TextView>(Resource.Id.SignUptxtBtn);
            EmailEditTxt = FindViewById<EditText>(Resource.Id.EmailEditTxt);
            PasswordEditTxt = FindViewById<EditText>(Resource.Id.PasswordEditTxt);
            LoginBtn = FindViewById<Button>(Resource.Id.LoginBtn);
            PassContainerFrame = FindViewById<FrameLayout>(Resource.Id.PassContainerfrm);
            ShowPassImgBtn.Click += ShowPassImgBtn_Click;
            HidePassImgBtn.Click += HidePassImgBtn_Click;
            EmailEditTxt.TextChanged += EmailEditTxt_TextChanged;
            PasswordEditTxt.TextChanged += PasswordEditTxt_TextChanged;
            LoginBtn.Click += LoginBtn_Click;
            LoginBtn.LongClick += LoginBtn_LongClick;
            ForgotPassTxtBtn.Click += ForgotPassTxtBtn_Click;
            SignUpTxtBtn.Click += SignUpTxtBtn_Click;
        }

        private void SignUpTxtBtn_Click(object sender, EventArgs e)
        {
            // StartActivity(new Intent(this, typeof(SignUpLayoutActivity)));
            Toast.MakeText(this, "wait for version 2.0 , try with \"admin\"", ToastLength.Short).Show();
        }

        private void ForgotPassTxtBtn_Click(object sender, EventArgs e)
        {
            // StartActivity(new Intent(this, typeof(ForgotPasswordActivity)));
            Toast.MakeText(this, "wait for version 2.0 , try with \"admin\"",ToastLength.Short).Show();
        }

        private void LoginBtn_LongClick(object sender, LongClickEventArgs e)
        {

            Toast.MakeText(this, "Whats your problem pro", ToastLength.Long).Show();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var view = CurrentFocus;
            if (view == null)
            {
                view = new View(this);
            }
            var inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(view.WindowToken, 0);

            if (EmailEditTxt.Text.ToLower() != "admin" || PasswordEditTxt.Text.ToLower() != "admin")
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                dialog.SetPositiveButton("OK", (sender, args) => { });
                dialog.SetTitle("information");
                dialog.SetMessage("the username or password is incorrect");
                dialog.Show();
                return;
            }

           // Toast.MakeText(this, "login successful", ToastLength.Short).Show();
            StartActivity(new Intent(this, typeof(Activity.AppListActivity)));
        }

        private void PasswordEditTxt_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            UsernameAndPassValidator(false);
        }

        private void EmailEditTxt_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {

            UsernameAndPassValidator(true);
        }

        public override void OnBackPressed()
        {
            count++;
            if(count > 1)
            base.OnBackPressed();

        }

        public void UsernameAndPassValidator(bool focusedonusername)
        {
            EmailErrTxt.Visibility = ViewStates.Invisible;
            PassErrTxt.Visibility = ViewStates.Invisible;

            if (EmailEditTxt.Text.Length == 0 && focusedonusername)
            {
                EmailErrTxt.Visibility = ViewStates.Visible;
                EmailErrTxt.Text = "Please enter username.";
                LoginBtn.Enabled = false;
                return;
            }
            if (PasswordEditTxt.Text.Length == 0 && !focusedonusername)
            {
                PassErrTxt.Visibility = ViewStates.Visible;
                PassErrTxt.Text = "please enter password.";
                LoginBtn.Enabled = false;
                return;
            }
            if (EmailEditTxt.Text.Length <= 4 && EmailEditTxt.Text.Length != 0 && focusedonusername)
            {
                EmailErrTxt.Visibility = ViewStates.Visible;
                EmailErrTxt.Text = "Username too short. Minimum 4 characters required.";
                LoginBtn.Enabled = false;
                return;
            }
            if (PasswordEditTxt.Text.Length <= 4 && PasswordEditTxt.Text.Length != 0 && !focusedonusername)
            {
                PassErrTxt.Visibility = ViewStates.Visible;
                PassErrTxt.Text = "Password too short. Minimum 4 characters required.";
                LoginBtn.Enabled = false;
                return;
            }
            if (EmailEditTxt.Text.Length >= 5 && PasswordEditTxt.Text.Length >= 5)
                LoginBtn.Enabled = true;

        }


        private void HidePassImgBtn_Click(object sender, EventArgs e)
        {
            ShowPassImgBtn.Visibility = ViewStates.Visible;
            HidePassImgBtn.Visibility = ViewStates.Invisible;
            /// this is used to make password field shows the text.
            PasswordEditTxt.TransformationMethod = PasswordTransformationMethod.Instance;
        }

        private void ShowPassImgBtn_Click(object sender, EventArgs e)
        {
            HidePassImgBtn.Visibility = ViewStates.Visible;
            ShowPassImgBtn.Visibility = ViewStates.Invisible;
            PasswordEditTxt.TransformationMethod = HideReturnsTransformationMethod.Instance;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}