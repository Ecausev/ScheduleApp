namespace ScheduleApp
{
    partial class AdminUc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appDataSet = new ScheduleApp.AppDataSet();
            this.userTableAdapter = new ScheduleApp.AppDataSetTableAdapters.UserTableAdapter();
            this.odradenoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.odradenoTableAdapter = new ScheduleApp.AppDataSetTableAdapters.OdradenoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odradenoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "User";
            this.userBindingSource.DataSource = this.appDataSet;
            // 
            // appDataSet
            // 
            this.appDataSet.DataSetName = "AppDataSet";
            this.appDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // odradenoBindingSource
            // 
            this.odradenoBindingSource.DataMember = "Odradeno";
            this.odradenoBindingSource.DataSource = this.appDataSet;
            // 
            // odradenoTableAdapter
            // 
            this.odradenoTableAdapter.ClearBeforeFill = true;
            // 
            // AdminUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AdminUc";
            this.Size = new System.Drawing.Size(1053, 577);
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odradenoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource userBindingSource;
        private AppDataSet appDataSet;
        private AppDataSetTableAdapters.UserTableAdapter userTableAdapter;
        private System.Windows.Forms.BindingSource odradenoBindingSource;
        private AppDataSetTableAdapters.OdradenoTableAdapter odradenoTableAdapter;
    }
}
