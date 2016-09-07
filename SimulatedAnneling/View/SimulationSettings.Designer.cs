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
            this.gpBoxSeed = new System.Windows.Forms.GroupBox();
            this.lb_seeds = new System.Windows.Forms.Label();
            this.numUpSeeds = new System.Windows.Forms.NumericUpDown();
            this.lsBxSeedsValues = new System.Windows.Forms.ListBox();
            this.lb_seed_values = new System.Windows.Forms.Label();
            this.lb_first = new System.Windows.Forms.Label();
            this.txt_first = new System.Windows.Forms.TextBox();
            this.lb_steps = new System.Windows.Forms.Label();
            this.txt_steps = new System.Windows.Forms.TextBox();
            this.ckBoxManualInput = new System.Windows.Forms.CheckBox();
            this.lb_message_manual_input = new System.Windows.Forms.Label();
            this.btn_add_seed = new System.Windows.Forms.Button();
            this.txt_seed_manual_input = new System.Windows.Forms.TextBox();
            this.btn_remove_seed = new System.Windows.Forms.Button();
            this.lb_number_cities = new System.Windows.Forms.Label();
            this.numUpNumberCities = new System.Windows.Forms.NumericUpDown();
            this.gpBoxCities = new System.Windows.Forms.GroupBox();
            this.ckBoxChooseCities = new System.Windows.Forms.CheckBox();
            this.ls_cities = new System.Windows.Forms.ListBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_find = new System.Windows.Forms.Button();
            this.cb_cities = new System.Windows.Forms.ComboBox();
            this.ls_selected_cities = new System.Windows.Forms.ListBox();
            this.lb_selected_cities = new System.Windows.Forms.Label();
            this.btn_add_city = new System.Windows.Forms.Button();
            this.btn_remove_city = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.gpBoxSeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpSeeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpNumberCities)).BeginInit();
            this.gpBoxCities.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "TSP Settings";
            // 
            // gpBoxSeed
            // 
            this.gpBoxSeed.Controls.Add(this.btn_remove_seed);
            this.gpBoxSeed.Controls.Add(this.txt_seed_manual_input);
            this.gpBoxSeed.Controls.Add(this.btn_add_seed);
            this.gpBoxSeed.Controls.Add(this.lb_message_manual_input);
            this.gpBoxSeed.Controls.Add(this.ckBoxManualInput);
            this.gpBoxSeed.Controls.Add(this.txt_steps);
            this.gpBoxSeed.Controls.Add(this.lb_steps);
            this.gpBoxSeed.Controls.Add(this.txt_first);
            this.gpBoxSeed.Controls.Add(this.lb_first);
            this.gpBoxSeed.Controls.Add(this.lb_seed_values);
            this.gpBoxSeed.Controls.Add(this.lsBxSeedsValues);
            this.gpBoxSeed.Controls.Add(this.numUpSeeds);
            this.gpBoxSeed.Controls.Add(this.lb_seeds);
            this.gpBoxSeed.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBoxSeed.Location = new System.Drawing.Point(30, 117);
            this.gpBoxSeed.Name = "gpBoxSeed";
            this.gpBoxSeed.Size = new System.Drawing.Size(493, 260);
            this.gpBoxSeed.TabIndex = 1;
            this.gpBoxSeed.TabStop = false;
            this.gpBoxSeed.Text = "Seeds";
            // 
            // lb_seeds
            // 
            this.lb_seeds.AutoSize = true;
            this.lb_seeds.Location = new System.Drawing.Point(26, 40);
            this.lb_seeds.Name = "lb_seeds";
            this.lb_seeds.Size = new System.Drawing.Size(50, 22);
            this.lb_seeds.TabIndex = 0;
            this.lb_seeds.Text = "Seeds";
            // 
            // numUpSeeds
            // 
            this.numUpSeeds.Location = new System.Drawing.Point(80, 40);
            this.numUpSeeds.Name = "numUpSeeds";
            this.numUpSeeds.Size = new System.Drawing.Size(55, 27);
            this.numUpSeeds.TabIndex = 1;
            // 
            // lsBxSeedsValues
            // 
            this.lsBxSeedsValues.FormattingEnabled = true;
            this.lsBxSeedsValues.ItemHeight = 22;
            this.lsBxSeedsValues.Location = new System.Drawing.Point(306, 65);
            this.lsBxSeedsValues.Name = "lsBxSeedsValues";
            this.lsBxSeedsValues.Size = new System.Drawing.Size(167, 136);
            this.lsBxSeedsValues.TabIndex = 2;
            // 
            // lb_seed_values
            // 
            this.lb_seed_values.AutoSize = true;
            this.lb_seed_values.Location = new System.Drawing.Point(302, 40);
            this.lb_seed_values.Name = "lb_seed_values";
            this.lb_seed_values.Size = new System.Drawing.Size(97, 22);
            this.lb_seed_values.TabIndex = 3;
            this.lb_seed_values.Text = "Seeds Values";
            this.lb_seed_values.Click += new System.EventHandler(this.lb_seed_values_Click);
            // 
            // lb_first
            // 
            this.lb_first.AutoSize = true;
            this.lb_first.Location = new System.Drawing.Point(26, 96);
            this.lb_first.Name = "lb_first";
            this.lb_first.Size = new System.Drawing.Size(37, 22);
            this.lb_first.TabIndex = 4;
            this.lb_first.Text = "First";
            // 
            // txt_first
            // 
            this.txt_first.Location = new System.Drawing.Point(67, 93);
            this.txt_first.Name = "txt_first";
            this.txt_first.Size = new System.Drawing.Size(37, 27);
            this.txt_first.TabIndex = 5;
            // 
            // lb_steps
            // 
            this.lb_steps.AutoSize = true;
            this.lb_steps.Location = new System.Drawing.Point(110, 93);
            this.lb_steps.Name = "lb_steps";
            this.lb_steps.Size = new System.Drawing.Size(45, 22);
            this.lb_steps.TabIndex = 6;
            this.lb_steps.Text = "Steps";
            // 
            // txt_steps
            // 
            this.txt_steps.Location = new System.Drawing.Point(160, 93);
            this.txt_steps.Name = "txt_steps";
            this.txt_steps.Size = new System.Drawing.Size(49, 27);
            this.txt_steps.TabIndex = 7;
            // 
            // ckBoxManualInput
            // 
            this.ckBoxManualInput.AutoSize = true;
            this.ckBoxManualInput.Location = new System.Drawing.Point(29, 167);
            this.ckBoxManualInput.Name = "ckBoxManualInput";
            this.ckBoxManualInput.Size = new System.Drawing.Size(114, 26);
            this.ckBoxManualInput.TabIndex = 8;
            this.ckBoxManualInput.Text = "Manual input";
            this.ckBoxManualInput.UseVisualStyleBackColor = true;
            // 
            // lb_message_manual_input
            // 
            this.lb_message_manual_input.AutoSize = true;
            this.lb_message_manual_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_message_manual_input.Location = new System.Drawing.Point(26, 191);
            this.lb_message_manual_input.Name = "lb_message_manual_input";
            this.lb_message_manual_input.Size = new System.Drawing.Size(138, 13);
            this.lb_message_manual_input.TabIndex = 9;
            this.lb_message_manual_input.Text = "Separate each value by a \',\'";
            // 
            // btn_add_seed
            // 
            this.btn_add_seed.Location = new System.Drawing.Point(201, 207);
            this.btn_add_seed.Name = "btn_add_seed";
            this.btn_add_seed.Size = new System.Drawing.Size(45, 27);
            this.btn_add_seed.TabIndex = 10;
            this.btn_add_seed.Text = "Add";
            this.btn_add_seed.UseVisualStyleBackColor = true;
            // 
            // txt_seed_manual_input
            // 
            this.txt_seed_manual_input.Location = new System.Drawing.Point(29, 207);
            this.txt_seed_manual_input.Name = "txt_seed_manual_input";
            this.txt_seed_manual_input.Size = new System.Drawing.Size(166, 27);
            this.txt_seed_manual_input.TabIndex = 11;
            // 
            // btn_remove_seed
            // 
            this.btn_remove_seed.Location = new System.Drawing.Point(398, 207);
            this.btn_remove_seed.Name = "btn_remove_seed";
            this.btn_remove_seed.Size = new System.Drawing.Size(75, 29);
            this.btn_remove_seed.TabIndex = 12;
            this.btn_remove_seed.Text = "Remove";
            this.btn_remove_seed.UseVisualStyleBackColor = true;
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
            this.numUpNumberCities.Location = new System.Drawing.Point(127, 79);
            this.numUpNumberCities.Maximum = new decimal(new int[] {
            7000,
            0,
            0,
            0});
            this.numUpNumberCities.Name = "numUpNumberCities";
            this.numUpNumberCities.Size = new System.Drawing.Size(77, 27);
            this.numUpNumberCities.TabIndex = 3;
            // 
            // gpBoxCities
            // 
            this.gpBoxCities.Controls.Add(this.btn_remove_city);
            this.gpBoxCities.Controls.Add(this.btn_add_city);
            this.gpBoxCities.Controls.Add(this.lb_selected_cities);
            this.gpBoxCities.Controls.Add(this.ls_selected_cities);
            this.gpBoxCities.Controls.Add(this.cb_cities);
            this.gpBoxCities.Controls.Add(this.btn_find);
            this.gpBoxCities.Controls.Add(this.txt_search);
            this.gpBoxCities.Controls.Add(this.ls_cities);
            this.gpBoxCities.Controls.Add(this.ckBoxChooseCities);
            this.gpBoxCities.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBoxCities.Location = new System.Drawing.Point(30, 383);
            this.gpBoxCities.Name = "gpBoxCities";
            this.gpBoxCities.Size = new System.Drawing.Size(493, 306);
            this.gpBoxCities.TabIndex = 4;
            this.gpBoxCities.TabStop = false;
            this.gpBoxCities.Text = "Choose cities";
            // 
            // ckBoxChooseCities
            // 
            this.ckBoxChooseCities.AutoSize = true;
            this.ckBoxChooseCities.Location = new System.Drawing.Point(29, 40);
            this.ckBoxChooseCities.Name = "ckBoxChooseCities";
            this.ckBoxChooseCities.Size = new System.Drawing.Size(116, 26);
            this.ckBoxChooseCities.TabIndex = 0;
            this.ckBoxChooseCities.Text = "Choose cities";
            this.ckBoxChooseCities.UseVisualStyleBackColor = true;
            // 
            // ls_cities
            // 
            this.ls_cities.FormattingEnabled = true;
            this.ls_cities.ItemHeight = 22;
            this.ls_cities.Location = new System.Drawing.Point(30, 153);
            this.ls_cities.Name = "ls_cities";
            this.ls_cities.Size = new System.Drawing.Size(217, 92);
            this.ls_cities.TabIndex = 1;
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(29, 80);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(145, 27);
            this.txt_search.TabIndex = 2;
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(180, 80);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(66, 27);
            this.btn_find.TabIndex = 3;
            this.btn_find.Text = "Find";
            this.btn_find.UseVisualStyleBackColor = true;
            // 
            // cb_cities
            // 
            this.cb_cities.FormattingEnabled = true;
            this.cb_cities.Items.AddRange(new object[] {
            "Id",
            "Name",
            "Country",
            "Population"});
            this.cb_cities.Location = new System.Drawing.Point(30, 113);
            this.cb_cities.Name = "cb_cities";
            this.cb_cities.Size = new System.Drawing.Size(217, 30);
            this.cb_cities.TabIndex = 4;
            // 
            // ls_selected_cities
            // 
            this.ls_selected_cities.FormattingEnabled = true;
            this.ls_selected_cities.ItemHeight = 22;
            this.ls_selected_cities.Location = new System.Drawing.Point(278, 109);
            this.ls_selected_cities.Name = "ls_selected_cities";
            this.ls_selected_cities.Size = new System.Drawing.Size(195, 136);
            this.ls_selected_cities.TabIndex = 5;
            // 
            // lb_selected_cities
            // 
            this.lb_selected_cities.AutoSize = true;
            this.lb_selected_cities.Location = new System.Drawing.Point(274, 80);
            this.lb_selected_cities.Name = "lb_selected_cities";
            this.lb_selected_cities.Size = new System.Drawing.Size(102, 22);
            this.lb_selected_cities.TabIndex = 6;
            this.lb_selected_cities.Text = "Selected Cities";
            // 
            // btn_add_city
            // 
            this.btn_add_city.Location = new System.Drawing.Point(171, 251);
            this.btn_add_city.Name = "btn_add_city";
            this.btn_add_city.Size = new System.Drawing.Size(75, 30);
            this.btn_add_city.TabIndex = 7;
            this.btn_add_city.Text = "Add ";
            this.btn_add_city.UseVisualStyleBackColor = true;
            // 
            // btn_remove_city
            // 
            this.btn_remove_city.Location = new System.Drawing.Point(398, 251);
            this.btn_remove_city.Name = "btn_remove_city";
            this.btn_remove_city.Size = new System.Drawing.Size(75, 30);
            this.btn_remove_city.TabIndex = 8;
            this.btn_remove_city.Text = "Remove";
            this.btn_remove_city.UseVisualStyleBackColor = true;
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.Location = new System.Drawing.Point(391, 695);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(132, 34);
            this.btn_run.TabIndex = 5;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            // 
            // SimulationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 737);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.gpBoxCities);
            this.Controls.Add(this.numUpNumberCities);
            this.Controls.Add(this.lb_number_cities);
            this.Controls.Add(this.gpBoxSeed);
            this.Controls.Add(this.label1);
            this.Name = "SimulationSettings";
            this.Text = "SimulationSettings";
            this.Load += new System.EventHandler(this.SimulationSettings_Load);
            this.gpBoxSeed.ResumeLayout(false);
            this.gpBoxSeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpSeeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpNumberCities)).EndInit();
            this.gpBoxCities.ResumeLayout(false);
            this.gpBoxCities.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpBoxSeed;
        private System.Windows.Forms.Button btn_remove_seed;
        private System.Windows.Forms.TextBox txt_seed_manual_input;
        private System.Windows.Forms.Button btn_add_seed;
        private System.Windows.Forms.Label lb_message_manual_input;
        private System.Windows.Forms.CheckBox ckBoxManualInput;
        private System.Windows.Forms.TextBox txt_steps;
        private System.Windows.Forms.Label lb_steps;
        private System.Windows.Forms.TextBox txt_first;
        private System.Windows.Forms.Label lb_first;
        private System.Windows.Forms.Label lb_seed_values;
        private System.Windows.Forms.ListBox lsBxSeedsValues;
        private System.Windows.Forms.NumericUpDown numUpSeeds;
        private System.Windows.Forms.Label lb_seeds;
        private System.Windows.Forms.Label lb_number_cities;
        private System.Windows.Forms.NumericUpDown numUpNumberCities;
        private System.Windows.Forms.GroupBox gpBoxCities;
        private System.Windows.Forms.Label lb_selected_cities;
        private System.Windows.Forms.ListBox ls_selected_cities;
        private System.Windows.Forms.ComboBox cb_cities;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.ListBox ls_cities;
        private System.Windows.Forms.CheckBox ckBoxChooseCities;
        private System.Windows.Forms.Button btn_remove_city;
        private System.Windows.Forms.Button btn_add_city;
        private System.Windows.Forms.Button btn_run;
    }
}