namespace TwitterBiggoDemo
{
    partial class TwitterFeed
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
            this.lstFollowNames = new System.Windows.Forms.ListBox();
            this.lstTweetList = new System.Windows.Forms.ListBox();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.ShowAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstFollowNames
            // 
            this.lstFollowNames.FormattingEnabled = true;
            this.lstFollowNames.ItemHeight = 16;
            this.lstFollowNames.Location = new System.Drawing.Point(12, 75);
            this.lstFollowNames.Name = "lstFollowNames";
            this.lstFollowNames.Size = new System.Drawing.Size(190, 372);
            this.lstFollowNames.TabIndex = 0;
            this.lstFollowNames.UseWaitCursor = true;
            this.lstFollowNames.SelectedIndexChanged += new System.EventHandler(this.LstFollowNamesSelectedIndexChanged);
            // 
            // lstTweetList
            // 
            this.lstTweetList.BackColor = System.Drawing.Color.White;
            this.lstTweetList.FormattingEnabled = true;
            this.lstTweetList.ItemHeight = 16;
            this.lstTweetList.Location = new System.Drawing.Point(209, 75);
            this.lstTweetList.Name = "lstTweetList";
            this.lstTweetList.Size = new System.Drawing.Size(661, 372);
            this.lstTweetList.TabIndex = 1;
            this.lstTweetList.UseWaitCursor = true;
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(209, 30);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(661, 22);
            this.txtSearchTerm.TabIndex = 2;
            // 
            // ShowAll
            // 
            this.ShowAll.Location = new System.Drawing.Point(13, 12);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(189, 57);
            this.ShowAll.TabIndex = 3;
            this.ShowAll.Text = "Search";
            this.ShowAll.UseVisualStyleBackColor = true;
            this.ShowAll.Click += new System.EventHandler(this.BtnShowAllClick);
            // 
            // TwitterFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.lstTweetList);
            this.Controls.Add(this.lstFollowNames);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "TwitterFeed";
            this.Text = "Twitter Feed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFollowNames;
        private System.Windows.Forms.ListBox lstTweetList;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Button ShowAll;


    }
}

