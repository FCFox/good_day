namespace 网页抓取工具
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.stopBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.catchBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.ipRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.titleText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.URLText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.countText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nextImageText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fixedCountText = new System.Windows.Forms.TextBox();
            this.imageURIText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.stopBtn);
            this.panel1.Controls.Add(this.pauseBtn);
            this.panel1.Controls.Add(this.catchBtn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.savePathTextBox);
            this.panel1.Controls.Add(this.ipRichTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 498);
            this.panel1.TabIndex = 0;
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(249, 363);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 8;
            this.stopBtn.Text = "停止";
            this.stopBtn.UseVisualStyleBackColor = true;
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(149, 363);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(75, 23);
            this.pauseBtn.TabIndex = 7;
            this.pauseBtn.Text = "暂停";
            this.pauseBtn.UseVisualStyleBackColor = true;
            // 
            // catchBtn
            // 
            this.catchBtn.Location = new System.Drawing.Point(35, 363);
            this.catchBtn.Name = "catchBtn";
            this.catchBtn.Size = new System.Drawing.Size(75, 23);
            this.catchBtn.TabIndex = 6;
            this.catchBtn.Text = "开始抓取";
            this.catchBtn.UseVisualStyleBackColor = true;
            this.catchBtn.Click += new System.EventHandler(this.CatchBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "保存的路径";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SavePathBtn_Click);
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Location = new System.Drawing.Point(24, 309);
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(151, 21);
            this.savePathTextBox.TabIndex = 4;
            this.savePathTextBox.Text = "C:\\Users\\Administrator\\Desktop\\测试";
            // 
            // ipRichTextBox
            // 
            this.ipRichTextBox.Location = new System.Drawing.Point(22, 103);
            this.ipRichTextBox.Name = "ipRichTextBox";
            this.ipRichTextBox.Size = new System.Drawing.Size(330, 171);
            this.ipRichTextBox.TabIndex = 3;
            this.ipRichTextBox.Text = "";
            this.ipRichTextBox.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "抓取地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "标题过滤";
            // 
            // titleText
            // 
            this.titleText.Location = new System.Drawing.Point(535, 130);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(227, 21);
            this.titleText.TabIndex = 2;
            this.titleText.Text = "<title>(.*)</title>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "URL";
            // 
            // URLText
            // 
            this.URLText.Location = new System.Drawing.Point(535, 12);
            this.URLText.Name = "URLText";
            this.URLText.Size = new System.Drawing.Size(207, 21);
            this.URLText.TabIndex = 4;
            this.URLText.Text = "http://www.xieejia.com/gkmh/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "总页数的正则表达式";
            // 
            // countText
            // 
            this.countText.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.countText.Location = new System.Drawing.Point(583, 164);
            this.countText.Name = "countText";
            this.countText.Size = new System.Drawing.Size(100, 21);
            this.countText.TabIndex = 8;
            this.countText.Text = "共([0-9]*)页";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(466, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "当前图片下载地址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "下张图片下载地址";
            // 
            // nextImageText
            // 
            this.nextImageText.Location = new System.Drawing.Point(468, 319);
            this.nextImageText.Name = "nextImageText";
            this.nextImageText.Size = new System.Drawing.Size(310, 21);
            this.nextImageText.TabIndex = 12;
            this.nextImageText.Text = "<a href=\'([0-9]*_?[0-9]*\\.html)\'>下一页</a>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "指定页数";
            // 
            // fixedCountText
            // 
            this.fixedCountText.Location = new System.Drawing.Point(535, 98);
            this.fixedCountText.Name = "fixedCountText";
            this.fixedCountText.Size = new System.Drawing.Size(133, 21);
            this.fixedCountText.TabIndex = 14;
            // 
            // imageURIText
            // 
            this.imageURIText.Location = new System.Drawing.Point(466, 246);
            this.imageURIText.Name = "imageURIText";
            this.imageURIText.Size = new System.Drawing.Size(312, 21);
            this.imageURIText.TabIndex = 10;
            this.imageURIText.Text = "<img.*src=(?:\'|\")(http.*?jpg)(?:\'|\")";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 522);
            this.Controls.Add(this.fixedCountText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nextImageText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageURIText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.countText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.URLText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button catchBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox URLText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox countText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox ipRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nextImageText;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fixedCountText;
        private System.Windows.Forms.TextBox imageURIText;
    }
}

