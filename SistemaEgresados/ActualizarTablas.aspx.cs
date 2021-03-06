﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaEgresados
{
    public partial class ActualizarTablas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        SqlConnection conn = new SqlConnection("Data Source=SQL5045.site4now.net;Initial Catalog=DB_A4CEA1_graduadosmgp;User Id=DB_A4CEA1_graduadosmgp_admin;Password=graduados19;");
        public void cargarDatos(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("obtenerEstudiante", conn);                     //usa el sp
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cedula", SqlDbType.Float).Value = cedula.Text;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TextEditNombre.Text = dr.GetValue(0).ToString();
                TextEditCedula.Text = dr.GetValue(1).ToString();
                TextEditCarnet.Text = dr.GetValue(2).ToString();
                TextEditGenero.Text = dr.GetValue(3).ToString();
                TextEditCorreo.Text = dr.GetValue(4).ToString();
                TextEditTelefono.Text = dr.GetValue(5).ToString();
                TextEditCel.Text = dr.GetValue(6).ToString();
                TextEditProvincia.Text = dr.GetValue(7).ToString();
                TextEditDistrito.Text = dr.GetValue(8).ToString();
                TextEditCanton.Text = dr.GetValue(9).ToString();
                TextEditPais.Text = dr.GetValue(10).ToString();
                TextEditDireccion.Text = dr.GetValue(11).ToString();
                TextEditActa.Text = dr.GetValue(12).ToString();
                TextEditPlan.Text = dr.GetValue(13).ToString();
                TextEditCarrera.Text = dr.GetValue(14).ToString();
                TextEditSede.Text = dr.GetValue(15).ToString();
                TextEditGrado.Text = dr.GetValue(16).ToString();
                TextEditTitulo.Text = dr.GetValue(17).ToString();
                TextEditEnfasis.Text = dr.GetValue(18).ToString();
               


                //graduacion2.SelectedDate = Convert.ToDateTime(dr.GetValue(19).ToString());
            }

            dr.Close();
            conn.Close();
        }

        public void editarDatos(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("editarEstudiante", conn);                     //usa el sp
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cedula", SqlDbType.Float).Value = TextEditCedula.Text;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = TextEditNombre.Text;
            cmd.Parameters.Add("@genero", SqlDbType.VarChar).Value = TextEditGenero.Text;
            cmd.Parameters.Add("@carnet", SqlDbType.VarChar).Value = TextEditCarnet.Text;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = TextEditCorreo.Text;
            cmd.Parameters.Add("@telefonoCasa", SqlDbType.Float).Value = TextEditTelefono.Text;           
            cmd.Parameters.Add("@celular", SqlDbType.Float).Value = TextEditCel.Text;
            cmd.Parameters.Add("@provincia", SqlDbType.VarChar).Value = TextEditProvincia.Text;                     
            cmd.Parameters.Add("@distrito", SqlDbType.VarChar).Value = TextEditDistrito.Text;
            cmd.Parameters.Add("@canton", SqlDbType.VarChar).Value = TextEditCanton.Text;
            cmd.Parameters.Add("@pais", SqlDbType.VarChar).Value = TextEditPais.Text;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = TextEditDireccion.Text;
            cmd.Parameters.Add("@acta", SqlDbType.VarChar).Value = TextEditActa.Text;
            cmd.Parameters.Add("@plan", SqlDbType.VarChar).Value = TextEditPlan.Text;
            cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = TextEditCarrera.Text;
            cmd.Parameters.Add("@sede", SqlDbType.VarChar).Value = TextEditSede.Text;
            cmd.Parameters.Add("@grado", SqlDbType.VarChar).Value = TextEditGrado.Text;
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = TextEditTitulo.Text;
            cmd.Parameters.Add("@enfasis", SqlDbType.VarChar).Value = TextEditEnfasis.Text;
            //cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = graduacion2.SelectedDate;


            try
            {
                conn.Open();
                Int32 rowsAffected = cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            conn.Close();
            Response.Redirect("ActualizarTablas.aspx");
        }
    }
}