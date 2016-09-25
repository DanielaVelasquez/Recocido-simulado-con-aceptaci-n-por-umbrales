namespace SimulatedAnneling.View
{
    partial class SimulationSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.numUpSeeds = new System.Windows.Forms.NumericUpDown();
            this.lb_seeds = new System.Windows.Forms.Label();
            this.lb_number_cities = new System.Windows.Forms.Label();
            this.numUpNumberCities = new System.Windows.Forms.NumericUpDown();
            this.btn_run = new System.Windows.Forms.Button();
            this.lb_size_cities = new System.Windows.Forms.Label();
            this.lb_message_simulating = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpSeeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpNumberCities)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "TSP Settings";
            // 
            // numUpSeeds
            // 
            this.numUpSeeds.Location = new System.Drawing.Point(457, 87);
            this.numUpSeeds.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUpSeeds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpSeeds.Name = "numUpSeeds";
            this.numUpSeeds.Size = new System.Drawing.Size(79, 22);
            this.numUpSeeds.TabIndex = 1;
            this.numUpSeeds.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lb_seeds
            // 
            this.lb_seeds.AutoSize = true;
            this.lb_seeds.Location = new System.Drawing.Point(331, 89);
            this.lb_seeds.Name = "lb_seeds";
            this.lb_seeds.Size = new System.Drawing.Size(93, 17);
            this.lb_seeds.TabIndex = 0;
            this.lb_seeds.Text = "Seed number";
            // 
            // lb_number_cities
            // 
            this.lb_number_cities.AutoSize = true;
            this.lb_number_cities.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_number_cities.Location = new System.Drawing.Point(27, 81);
            this.lb_number_cities.Name = "lb_number_cities";
            this.lb_number_cities.Size = new System.Drawing.Size(97, 22);
            this.lb_number_cities.TabIndex = 2;
            this.lb_number_cities.Text = "Number cities";
            // 
            // numUpNumberCities
            // 
            this.numUpNumberCities.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpNumberCities.Location = new System.Drawing.Point(149, 79);
            this.numUpNumberCities.Maximum = new decimal(new int[] {
            7000,
            0,
            0,
            0});
            this.numUpNumberCities.Name = "numUpNumberCities";
            this.numUpNumberCities.Size = new System.Drawing.Size(77, 27);
            this.numUpNumberCities.TabIndex = 3;
            this.numUpNumberCities.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpNumberCities.ValueChanged += new System.EventHandler(this.numUpNumberCities_ValueChanged);
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.Location = new System.Drawing.Point(404, 115);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(132, 34);
            this.btn_run.TabIndex = 5;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // lb_size_cities
            // 
            this.lb_size_cities.AutoSize = true;
            this.lb_size_cities.Location = new System.Drawing.Point(232, 86);
            this.lb_size_cities.Name = "lb_size_cities";
            this.lb_size_cities.Size = new System.Drawing.Size(46, 17);
            this.lb_size_cities.TabIndex = 6;
            this.lb_size_cities.Text = "label2";
            // 
            // lb_message_simulating
            // 
            this.lb_message_simulating.AutoSize = true;
            this.lb_message_simulating.Location = new System.Drawing.Point(232, 132);
            this.lb_message_simulating.Name = "lb_message_simulating";
            this.lb_message_simulating.Size = new System.Drawing.Size(92, 17);
            this.lb_message_simulating.TabIndex = 7;
            this.lb_message_simulating.Text = "AQUI ESTOY";
            // 
            // SimulationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 168);
            this.Controls.Add(this.lb_message_simulating);
            this.Controls.Add(this.numUpSeeds);
            this.Controls.Add(this.lb_size_cities);
            this.Controls.Add(this.lb_seeds);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.numUpNumberCities);
            this.Controls.Add(this.lb_number_cities);
            this.Controls.Add(this.label1);
            this.Name = "SimulationSettings";
            this.Text = "SimulationSettings";
            this.Load += new System.EventHandler(this.SimulationSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpSeeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpNumberCities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpSeeds;
        private System.Windows.Forms.Label lb_seeds;
        private System.Windows.Forms.Label lb_number_cities;
        private System.Windows.Forms.NumericUpDown numUpNumberCities;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Label lb_size_cities;
        private System.Windows.Forms.Label lb_message_simulating;
    }
}