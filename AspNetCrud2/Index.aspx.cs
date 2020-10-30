using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetCrud2
{
    public partial class Index : System.Web.UI.Page
    {
        string connectionString = @"Server=10.25.1.86; UserID=root;Password=valerie5250;Database=AspCrudDb";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                GridFill();
            }
        }

        private void GridFill()
        {
            using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
            {
                sqlConn.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ProductViewAll", sqlConn);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtTbl = new DataTable();
                sqlDa.Fill(dtTbl);
                gvProduct.DataSource = dtTbl;
                gvProduct.DataBind();
                gvProduct.DataSource = dtTbl;
                gvProduct.DataBind();
            }
        }

        private void Clear()
        {
            hfProductID.Value = string.Empty;
            txtProduct.Text = txtPrice.Text = txtCount.Text = txtDescription.Text = string.Empty;
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            lblErrorMessage.Text = lblSucessMessage.Text = string.Empty;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
                {
                    sqlConn.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("ProductAddOrEdit", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_productid", Convert.ToInt32(hfProductID.Value == string.Empty ? "0" : hfProductID.Value));
                    sqlCmd.Parameters.AddWithValue("_product", txtProduct.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_price", Convert.ToDecimal(txtPrice.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("_count", Convert.ToInt32(txtCount.Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("_description", txtDescription.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    GridFill();
                    Clear();
                    lblSucessMessage.Text = "Submitted succesfully";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void LnkSelect_OnClick(object sender, EventArgs e)
        {
            try
            {
                object obj = (sender as LinkButton).CommandArgument;
                int productID = Convert.ToInt32(obj);

                using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
                {

                    sqlConn.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("ProductViewByID", sqlConn);
                    sqlDa.SelectCommand.Parameters.AddWithValue("_productid", productID);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dtTbl = new DataTable();
                    sqlDa.Fill(dtTbl);
                    txtProduct.Text = dtTbl.Rows[0][1].ToString();
                    txtPrice.Text = dtTbl.Rows[0][2].ToString();
                    txtCount.Text = dtTbl.Rows[0][3].ToString();
                    txtDescription.Text = dtTbl.Rows[0][4].ToString();

                    hfProductID.Value = dtTbl.Rows[0][0].ToString();

                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }


        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlConn = new MySqlConnection(connectionString))
                {
                    sqlConn.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("ProductDeleteByID", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_productid", Convert.ToInt32(hfProductID.Value == string.Empty ? "0" : hfProductID.Value));
                    sqlCmd.ExecuteNonQuery();
                    GridFill();
                    Clear();
                    lblSucessMessage.Text = "Deleted succesfully";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}