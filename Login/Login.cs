using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        ConexionDB conexion = new ConexionDB();
        Usuario user = new Usuario();

        private void button1_Click(object sender, EventArgs e)
        {
            if (UsuarioTextBox.Text == "")
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese usuario");
                UsuarioTextBox.Focus();
                return;
            }

            if (ClaveTextBox.Text == "")
            {
                errorProvider1.SetError(ClaveTextBox, "Ingrese contraseña");
                ClaveTextBox.Focus();
                return;
            }


            user.CodigoUsuario = UsuarioTextBox.Text;
            user.Clave = ClaveTextBox.Text;

            bool valido = conexion.ValidarUsuario(user);

            if (valido)
            {
                ProductosForm formulario = new ProductosForm();
                this.Hide();
                formulario.Show();
            }
            else
            {
                MessageBox.Show("Usuario incorrecto");
            }
        }
    }
}
