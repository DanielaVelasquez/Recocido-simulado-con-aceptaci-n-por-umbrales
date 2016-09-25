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
            this.btn_simulate = new System.Windows.Forms.Button();
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
            this.gboxSolution = new System.Windows.Forms.GroupBox();
            this.btnChart = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.txtCostFunction = new System.Windows.Forms.TextBox();
            this.lbCostFunction = new System.Windows.Forms.Label();
            this.lbSolutionCities = new System.Windows.Forms.Label();
            this.lsBoxCities = new System.Windows.Forms.ListBox();
            this.grBxInformation.SuspendLayout();
            this.gboxSolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBxInformation
            // 
            this.grBxInformation.Controls.Add(this.lb_connected_cities);
            this.grBxInformation.Controls.Add(this.btn_simulate);
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
            this.grBxInformation.Size = new System.Drawing.Size(339, 807);
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
            // btn_simulate
            // 
            this.btn_simulate.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_simulate.Location = new System.Drawing.Point(211, 763);
            this.btn_simulate.Name = "btn_simulate";
            this.btn_simulate.Size = new System.Drawing.Size(103, 38);
            this.btn_simulate.TabIndex = 2;
            this.btn_simulate.Text = "Simulate";
            this.btn_simulate.UseVisualStyleBackColor = true;
            this.btn_simulate.Click += new System.EventHandler(this.btn_simulate_Click);
            // 
            // lsbox_connectedCities
            // 
            this.lsbox_connectedCities.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbox_connectedCities.FormattingEnabled = true;
            this.lsbox_connectedCities.ItemHeight = 22;
            this.lsbox_connectedCities.Location = new System.Drawing.Point(20, 343);
            this.lsbox_connectedCities.Name = "lsbox_connectedCities";
            this.lsbox_connectedCities.Size = new System.Drawing.Size(294, 400);
            this.lsbox_connectedCities.TabIndex = 10;
            this.lsbox_connectedCities.SelectedIndexChanged += new System.EventHandler(this.lsbox_connectedCities_SelectedIndexChanged);
            // 
            // txt_longitude
            // 
            this.txt_longitude.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_longitude.Location = new System.Drawing.Point(105, 265);
            this.txt_longitude.Name = "txt_longitude";
            this.txt_longitude.ReadOnly = true;
            this.txt_longitude.Size = new System.Drawing.Size(209, 27);
            this.txt_longitude.TabIndex = 9;
            // 
            // txt_latitude
            // 
            this.txt_latitude.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_latitude.Location = new System.Drawing.Point(105, 210);
            this.txt_latitude.Name = "txt_latitude";
            this.txt_latitude.ReadOnly = true;
            this.txt_latitude.Size = new System.Drawing.Size(209, 27);
            this.txt_latitude.TabIndex = 8;
            // 
            // txt_population
            // 
            this.txt_population.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_population.Location = new System.Drawing.Point(105, 154);
            this.txt_population.Name = "txt_population";
            this.txt_population.ReadOnly = true;
            this.txt_population.Size = new System.Drawing.Size(209, 27);
            this.txt_population.TabIndex = 7;
            // 
            // txt_country
            // 
            this.txt_country.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_country.Location = new System.Drawing.Point(105, 102);
            this.txt_country.Name = "txt_country";
            this.txt_country.ReadOnly = true;
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
            this.txtName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtName.Location = new System.Drawing.Point(105, 50);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
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
            // gboxSolution
            // 
            this.gboxSolution.Controls.Add(this.btnChart);
            this.gboxSolution.Controls.Add(this.txtTime);
            this.gboxSolution.Controls.Add(this.lbTime);
            this.gboxSolution.Controls.Add(this.txtCostFunction);
            this.gboxSolution.Controls.Add(this.lbCostFunction);
            this.gboxSolution.Controls.Add(this.lbSolutionCities);
            this.gboxSolution.Controls.Add(this.lsBoxCities);
            this.gboxSolution.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxSolution.Location = new System.Drawing.Point(27, 628);
            this.gboxSolution.Name = "gboxSolution";
            this.gboxSolution.Size = new System.Drawing.Size(679, 205);
            this.gboxSolution.TabIndex = 8;
            this.gboxSolution.TabStop = false;
            this.gboxSolution.Text = "Solution information";
            // 
            // btnChart
            // 
            this.btnChart.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChart.Location = new System.Drawing.Point(533, 161);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(113, 35);
            this.btnChart.TabIndex = 6;
            this.btnChart.Text = "See Charts";
            this.btnChart.UseVisualStyleBackColor = true;
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTime.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(401, 104);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(245, 27);
            this.txtTime.TabIndex = 5;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(305, 109);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(43, 22);
            this.lbTime.TabIndex = 4;
            this.lbTime.Text = "Time";
            // 
            // txtCostFunction
            // 
            this.txtCostFunction.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCostFunction.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostFunction.Location = new System.Drawing.Point(401, 62);
            this.txtCostFunction.Name = "txtCostFunction";
            this.txtCostFunction.ReadOnly = true;
            this.txtCostFunction.Size = new System.Drawing.Size(245, 27);
            this.txtCostFunction.TabIndex = 3;
            // 
            // lbCostFunction
            // 
            this.lbCostFunction.AutoSize = true;
            this.lbCostFunction.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCostFunction.Location = new System.Drawing.Point(305, 65);
            this.lbCostFunction.Name = "lbCostFunction";
            this.lbCostFunction.Size = new System.Drawing.Size(90, 22);
            this.lbCostFunction.TabIndex = 2;
            this.lbCostFunction.Text = "Cost function";
            // 
            // lbSolutionCities
            // 
            this.lbSolutionCities.AutoSize = true;
            this.lbSolutionCities.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSolutionCities.Location = new System.Drawing.Point(23, 33);
            this.lbSolutionCities.Name = "lbSolutionCities";
            this.lbSolutionCities.Size = new System.Drawing.Size(49, 22);
            this.lbSolutionCities.TabIndex = 1;
            this.lbSolutionCities.Text = "Cities";
            // 
            // lsBoxCities
            // 
            this.lsBoxCities.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsBoxCities.FormattingEnabled = true;
            this.lsBoxCities.ItemHeight = 22;
            this.lsBoxCities.Location = new System.Drawing.Point(26, 62);
            this.lsBoxCities.Name = "lsBoxCities";
            this.lsBoxCities.Size = new System.Drawing.Size(240, 114);
            this.lsBoxCities.TabIndex = 0;
            this.lsBoxCities.SelectedIndexChanged += new System.EventHandler(this.lsBoxCities_SelectedIndexChanged);
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 865);
            this.Controls.Add(this.gboxSolution);
            this.Controls.Add(this.grBxInformation);
            this.Name = "MapView";
            this.Text = "Traveler salesman problem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapView_FormClosed);
            this.Load += new System.EventHandler(this.MapView_Load);
            this.grBxInformation.ResumeLayout(false);
            this.grBxInformation.PerformLayout();
            this.gboxSolution.ResumeLayout(false);
            this.gboxSolution.PerformLayout();
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
        private System.Windows.Forms.GroupBox gboxSolution;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TextBox txtCostFunction;
        private System.Windows.Forms.Label lbCostFunction;
        private System.Windows.Forms.Label lbSolutionCities;
        private System.Windows.Forms.ListBox lsBoxCities;
    }
}