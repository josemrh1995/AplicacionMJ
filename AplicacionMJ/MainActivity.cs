 using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Nio.Channels;
using static AplicacionMJ.Login;

namespace AplicacionMJ
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtUserName;
        EditText txtPass;
        Button btnLogin;
        Button btnCreateAccount;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnCreateAccount = FindViewById<Button>(Resource.Id.BtnCreateAccount);
            btnLogin = FindViewById<Button>(Resource.Id.BtnLogin);
            txtPass = FindViewById<EditText>(Resource.Id.TxtPass);
            txtUserName = FindViewById<EditText>(Resource.Id.TxtUserName);

            btnLogin.Click += BtnLogin_Click;
            btnCreateAccount.Click += BtnCreateAccount_Click;
        }

        private void BtnCreateAccount_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);

        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                Login resultado = null;
                if (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtPass.Text.Trim()))
                {
                    resultado= new Auxiliar().Seleccionar(txtUserName.Text.Trim(), txtPass.Text.Trim());
                    if (resultado != null)
                    {
                        txtUserName.Text = resultado.UserName.ToString();
                        Toast.MakeText(this, "Login successful", ToastLength.Short).Show();
                        var welcome = new Intent(this, typeof(Login));
                        welcome.PutExtra("usuario", FindViewById<EditText>(Resource.Id.TxtUserName).Text);
                        StartActivity(welcome);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Invalid username and/or password", ToastLength.Long).Show();

                    }
                }
                else
                {
                    Toast.MakeText(this, "Username and/or password are empty", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Tostring (), ToastLength.Short).Show();
            }
        } 
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}