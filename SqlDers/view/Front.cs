﻿using SqlDers.controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace SqlDers
{
    
    public partial class Front : Form
    {
        Connection connection;
        Business business;
        GUIDTestController testController;
        ModelController modelController;
        static int parameterValue;

        public DataTable dt;
        DataGridView dataGridView = new DataGridView
        {
            Location = new System.Drawing.Point(650, 50), // Konumu ayarla
            Size = new System.Drawing.Size(700, 700),    // Boyutu ayarla
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        


        public Front()
        {
            connection = new Connection();
            testController = new GUIDTestController();
            modelController = new ModelController();
            business = new Business();
            
            InitializeComponent();
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            Button model=new Button(); 
            Button guid=new Button();
            model.Text = "model";
            guid.Text = "guid";
            model.Top = 700;
            model.Left = 1400;
            model.Width = 100;
            model.Height = 50;
            model.Click += modelLister;
            Controls.Add(model);
            guid.Top = 600;
            guid.Left = 1400;
            guid.Width = 100;
            guid.Height = 50;
            guid.Click += gUIDTestLister;
            Controls.Add(guid);
            Button storedP=new Button();
            storedP.Text = "SP";
            storedP.Top = 800;
            storedP.Left = 1400;
            storedP.Width = 100;
            storedP.Height = 50;
            storedP.Click += storedProcedure;
            Controls.Add(storedP);

            ButtonLister();
        }
        void ButtonLister()
        {
            int placeX=55;
            int placeY=55;
            int i = 0;
            foreach (string name in business.DataNameFinder())
            {
                if (i == 8) { placeX += 100; placeY = 55; i = 0; }
                ButtonAdd(placeY,placeX,name);
                placeY += 110;
                i++;
            }
        }
        //burası stored procedure denemesidir. gerekli kod yazımına uygun yapılmamıştır
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            parameterValue = Convert.ToInt32(textBox.Text);
        }
        //burası stored procedure denemesidir. gerekli kod yazımına uygun yapılmamıştır

        /*public void saveB()
        {
            Button button = new Button();
            button.Top = 800;
            button.Left = 800;
            button.Text = "save";
            button.Width = 50;
            button.Height = 50;
            button.Click += saver;
            Controls.Add(button);
        }*/
        private void ButtonAdd(int top, int left, string text)
        {
            Button button = new Button();
            button.Top = top;
            button.Left = left;
            button.Text = text;
            button.Width = 100;
            button.Height = 50;
            button.Click += Lister;
            Controls.Add(button);  
        }
        private void Lister(object sender,EventArgs e)
        {
            try
            {
            int i = 0;
            Button clickedButton = sender as Button;
            dt = business.BringList(clickedButton.Text);
            dataGridView.DataSource=dt;
            dataGridView.ReadOnly = true;
            Controls.Add(dataGridView); 
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void gUIDTestLister(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                Button clickedButton = sender as Button;
                dataGridView.DataSource = testController.GetAll();
                dataGridView.ReadOnly = true;
                Controls.Add(dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void modelLister(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                Button clickedButton = sender as Button;
                dataGridView.DataSource = modelController.GetAll();
                dataGridView.ReadOnly = true;
                Controls.Add(dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //burası stored procedure denemesidir. gerekli kod yazımına uygun yapılmamıştır
        private void storedProcedure(object sender,EventArgs e)
        {
           
            try
            {
                int i = 0;
                Button clickedButton = sender as Button;
                SqlCommand cmd = new SqlCommand("lowlo",connection.Baglanti());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parameter", parameterValue);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Bilgi");
                dataGridView.DataSource = ds.Tables[0];
                dataGridView.ReadOnly = true;
                Controls.Add(dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
        /*private void saver(object sender,EventArgs e)
{
string query = "INSERT INTO [dukkan].[dbo].[GUIDTest] (isim) VALUES (@isim)";

try
{
using (SqlCommand command = new SqlCommand(query, test))
{
  // Parametreleri ekliyoruz
  //command.Parameters.AddWithValue("@no", txtGirdiNum.Text);
  command.Parameters.AddWithValue("@isim", txtGirdiName.Text);

  int rowsAffected = command.ExecuteNonQuery();

  if (rowsAffected > 0)
  {
      MessageBox.Show("Numara ve isim başarıyla eklendi.");
  }
  else
  {
      MessageBox.Show("Kayıt eklenemedi.");
  }
}
}
catch (Exception ex)
{
MessageBox.Show(ex.Message);
}
}*/
    }
}

