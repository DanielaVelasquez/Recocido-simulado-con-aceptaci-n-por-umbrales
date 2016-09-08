namespace SimulatedAnneling.View
{
    partial class MapView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grBxInformation = new System.Windows.Forms.GroupBox();
            this.lb_connected_cities = new System.Windows.Forms.Label();
            this.lsbox_connectedCities = new System.Windows.Forms.ListBox();
            this.txt_longitude = new System.Windows.Forms.TextBox();
            this.txt_latitude = new System.Windows.Forms.TextBox();
            this.txt_population = new System.Windows.Forms.TextBox();
            this.txt_country = new System.Windows.Forms.TextBox();
            this.lb_longitude = new System.Windows.Forms.Label();
            this.lb_latitude = new System.Windows.Forms.Label();
            this.lb_population = new System.Windows.Forms.Label();
            this.lb_country = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lb_name = new System.Windows.Forms.Label();
            this.btn_simulate = new System.Windows.Forms.Button();
            this.grBxInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBxInformation
            // 
            this.grBxInformation.Controls.Add(this.lb_connected_cities);
            this.grBxInformation.Controls.Add(this.lsbox_connectedCities);
            this.grBxInformation.Controls.Add(this.txt_longitude);
            this.grBxInformation.Controls.Add(this.txt_latitude);
            this.grBxInformation.Controls.Add(this.txt_population);
            this.grBxInformation.Controls.Add(this.txt_country);
            this.grBxInformation.Controls.Add(this.lb_longitude);
            this.grBxInformation.Controls.Add(this.lb_latitude);
            this.grBxInformation.Controls.Add(this.lb_population);
            this.grBxInformation.Controls.Add(this.lb_country);
            this.grBxInformation.Controls.Add(this.txtName);
            this.grBxInformation.Controls.Add(this.lb_name);
            this.grBxInformation.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBxInformation.Location = new System.Drawing.Point(726, 26);
            this.grBxInformation.Name = "grBxInformation";
            this.grBxInformation.Size = new System.Drawing.Size(339, 624);
            this.grBxInformation.TabIndex = 1;
            this.grBxInformation.TabStop = false;
            this.grBxInformation.Text = "Information";
            // 
            // lb_connected_cities
            // 
            this.lb_connected_cities.AutoSize = true;
            this.lb_connected_cities.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_connected_cities.Location = new System.Drawing.Point(17, 314);
            this.lb_connected_cities.Name = "lb_connected_cities";
            this.lb_connected_cities.Size = new System.Drawing.Size(126, 22);
            this.lb_connected_cities.TabIndex = 11;
            this.lb_connected_cities.Text = "Connected cities";
            // 
            // lsbox_connectedCities
            // 
            this.lsbox_connectedCities.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbox_connectedCities.FormattingEnabled = true;
            this.lsbox_connectedCities.ItemHeight = 22;
            this.lsbox_connectedCities.Location = new System.Drawing.Point(20, 343);
            this.lsbox_connectedCities.Name = "lsbox_connectedCities";
            this.lsbox_connectedCities.Size = new System.Drawing.Size(294, 246);
            this.lsbox_connectedCities.TabIndex = 10;
            // 
            // txt_longitude
            // 
            this.txt_longitude.Location = new System.Drawing.Point(105, 265);
            this.txt_longitude.Name = "txt_longitude";
            this.txt_longitude.Size = new System.Drawing.Size(209, 27);
            this.txt_longitude.TabIndex = 9;
            // 
            // txt_latitude
            // 
            this.txt_latitude.Location = new System.Drawing.Point(105, 210);
            this.txt_latitude.Name = "txt_latitude";
            this.txt_latitude.Size = new System.Drawing.Size(209, 27);
            this.txt_latitude.TabIndex = 8;
            // 
            // txt_population
            // 
            this.txt_population.Location = new System.Drawing.Point(105, 154);
            this.txt_population.Name = "txt_population";
            this.txt_population.Size = new System.Drawing.Size(209, 27);
            this.txt_population.TabIndex = 7;
            // 
            // txt_country
            // 
            this.txt_country.Location = new System.Drawing.Point(105, 102);
            this.txt_country.Name = "txt_country";
            this.txt_country.Size = new System.Drawing.Size(209, 27);
            this.txt_country.TabIndex = 6;
            // 
            // lb_longitude
            // 
            this.lb_longitude.AutoSize = true;
            this.lb_longitude.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_longitude.Location = new System.Drawing.Point(17, 265);
            this.lb_longitude.Name = "lb_longitude";
            this.lb_longitude.Size = new System.Drawing.Size(72, 22);
            this.lb_longitude.TabIndex = 5;
            this.lb_longitude.Text = "Longitude";
            // 
            // lb_latitude
            // 
            this.lb_latitude.AutoSize = true;
            this.lb_latitude.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_latitude.Location = new System.Drawing.Point(17, 213);
            this.lb_latitude.Name = "lb_latitude";
            this.lb_latitude.Size = new System.Drawing.Size(59, 22);
            this.lb_latitude.TabIndex = 4;
            this.lb_latitude.Text = "Latitude";
            // 
            // lb_population
            // 
            this.lb_population.AutoSize = true;
            this.lb_population.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_population.Location = new System.Drawing.Point(17, 154);
            this.lb_population.Name = "lb_population";
            this.lb_population.Size = new System.Drawing.Size(76, 22);
            this.lb_population.TabIndex = 3;
            this.lb_population.Text = "Population";
            // 
            // lb_country
            // 
            this.lb_country.AutoSize = true;
            this.lb_country.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_country.Location = new System.Drawing.Point(17, 102);
            this.lb_country.Name = "lb_country";
            this.lb_country.Size = new System.Drawing.Size(59, 22);
            this.lb_country.TabIndex = 2;
            this.lb_country.Text = "Country";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(105, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 27);
            this.txtName.TabIndex = 1;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(17, 50);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(49, 22);
            this.lb_name.TabIndex = 0;
            this.lb_name.Text = "Name";
            // 
            // btn_simulate
            // 
            this.btn_simulate.Location = new System.Drawing.Point(962, 656);
            this.btn_simulate.Name = "btn_simulate";
            this.btn_simulate.Size = new System.Drawing.Size(103, 38);
            this.btn_simulate.TabIndex = 2;
            this.btn_simulate.Text = "Simulate";
            this.btn_simulate.UseVisualStyleBackColor = true;
            this.btn_simulate.Click += new System.EventHandler(this.btn_simulate_Click);
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 706);
            this.Controls.Add(this.btn_simulate);
            this.Controls.Add(this.grBxInformation);
            this.Name = "MapView";
            this.Text = "MapView";
            this.Load += new System.EventHandler(this.MapView_Load);
            this.grBxInformation.ResumeLayout(false);
            this.grBxInformation.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox grBxInformation;
        private System.Windows.Forms.Label lb_connected_cities;
        private System.Windows.Forms.ListBox lsbox_connectedCities;
        private System.Windows.Forms.TextBox txt_longitude;
        private System.Windows.Forms.TextBox txt_latitude;
        private System.Windows.Forms.TextBox txt_population;
        private System.Windows.Forms.TextBox txt_country;
        private System.Windows.Forms.Label lb_longitude;
        private System.Windows.Forms.Label lb_latitude;
        private System.Windows.Forms.Label lb_population;
        private System.Windows.Forms.Label lb_country;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Button btn_simulate;
    }
}