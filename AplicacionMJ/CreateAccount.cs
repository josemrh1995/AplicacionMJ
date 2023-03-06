using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AplicacionMJ.Login;

namespace AplicacionMJ
{
    [Activity(Label = "CreateAccount")]
    public class CreateAccount : Activity
    {
        EditText txtNewUser;
        EditText txtNewUserKey;
        Button btnRegisterUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            txtNewUser = FindViewById<EditText>(Resource.Id.txtNewUser);
            txtNewUserKey = FindViewById<EditText>(Resource.Id.txtNewUserKey);
            btnRegisterUser = FindViewById<Button>(Resource.Id.btnRegisterNewUser);

            btnRegisterUser.Click += BtnRegisterUser_Click;   
        }
        private void BtnRegisterUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNewUser.Text.Trim()) && !string.IsNullOrEmpty(txtNewUserKey.Text.Trim()))
                {
                    new Auxiliar().Guardar(new Login() { Id = 0, UserName = txtNewUser.Text.Trim(), Password = txtNewUserKey.Text.Trim() });
                    Toast.MakeText(this, "Registro guardado", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una clave", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}