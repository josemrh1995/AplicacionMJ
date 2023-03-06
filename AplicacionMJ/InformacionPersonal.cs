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

namespace AplicacionMJ
{
    [Activity(Label = "InformacionPersonal")]
    public class InformacionPersonal : Activity
    {
        EditText txtNombres;
        EditText txtApellidos;
        EditText txtEdad;
        EditText txtSexo;
        EditText txtNDocumento;
        Button btnIngresarInformacion;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            txtNombres = FindViewById<EditText>(Resource.Id.txtNombre);
            txtApellidos = FindViewById<EditText>(Resource.Id.txtApellidos);
            txtEdad = FindViewById<EditText>(Resource.Id.txtEdad);
            txtSexo = FindViewById<EditText>(Resource.Id.txtSexo);
            txtNDocumento = FindViewById<EditText>(Resource.Id.txtNDocumento);
            btnIngresarInformacion = FindViewById<Button>(Resource.Id.btnRegistrarUsuarioNuevo);

            btnIngresarInformacion.Click += BtnRegistrarUsuario_Click;
        }

        private void BtnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombres.Text.Trim()) && !string.IsNullOrEmpty(txtApellidos.Text.Trim()) && !string.IsNullOrEmpty(txtEdad.Text.Trim()) && !string.IsNullOrEmpty(txtSexo.Text.Trim()) && !string.IsNullOrEmpty(txtNDocumento.Text.Trim()))
                {
                    //new Auxiliar().Guardar(new Informacion() { Registro = 0, Nombres = txtNombres.Text.Trim(), Apellidos = txtApellidos.Text.Trim(), Edad = txtEdad.Text.Trim(), Sexo = txtSexo.Text.Trim(), NDocumento = txtNDocumento.Text.Trim()});
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