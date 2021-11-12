﻿using Datos;
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
    public partial class ProductosForm : Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }

        ConexionDB conexion = new ConexionDB();
        Producto producto = new Producto();

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);

            bool Inserto = conexion.InsertarProducto(producto);

            if (Inserto)
            {
                MessageBox.Show("Producto registrado con éxito");

                DescripcionTextBox.Text = " ";
                PrecioTextBox.Clear();
                ExistenciaTextBox.Text = string.Empty;
                producto = null;
            }
            else
            {
                MessageBox.Show("No se registró el producto");
            }

        }
    }
}
