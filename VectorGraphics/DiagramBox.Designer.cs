namespace VectorGraphics
{
    partial class DiagramBox
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
            this.cmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddRect = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoundRectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRhombToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addParalelogrammToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSelectedFigure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miEditText = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddLine = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmMain.SuspendLayout();
            this.cmSelectedFigure.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmMain
            // 
            this.cmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddRect,
            this.addRoundRectToolStripMenuItem,
            this.addRhombToolStripMenuItem,
            this.addParalelogrammToolStripMenuItem,
            this.addEllipseToolStripMenuItem,
            this.addStackToolStripMenuItem,
            this.addFrameToolStripMenuItem});
            this.cmMain.Name = "cmMain";
            this.cmMain.Size = new System.Drawing.Size(181, 158);
            // 
            // miAddRect
            // 
            this.miAddRect.Name = "miAddRect";
            this.miAddRect.Size = new System.Drawing.Size(180, 22);
            this.miAddRect.Text = "Add Rectangle";
            this.miAddRect.Click += new System.EventHandler(this.miAddRect_Click);
            // 
            // addRoundRectToolStripMenuItem
            // 
            this.addRoundRectToolStripMenuItem.Name = "addRoundRectToolStripMenuItem";
            this.addRoundRectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addRoundRectToolStripMenuItem.Text = "Add RoundRect";
            this.addRoundRectToolStripMenuItem.Click += new System.EventHandler(this.addRoundRectToolStripMenuItem_Click);
            // 
            // addRhombToolStripMenuItem
            // 
            this.addRhombToolStripMenuItem.Name = "addRhombToolStripMenuItem";
            this.addRhombToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addRhombToolStripMenuItem.Text = "Add Rhomb";
            this.addRhombToolStripMenuItem.Click += new System.EventHandler(this.addRhombToolStripMenuItem_Click);
            // 
            // addParalelogrammToolStripMenuItem
            // 
            this.addParalelogrammToolStripMenuItem.Name = "addParalelogrammToolStripMenuItem";
            this.addParalelogrammToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addParalelogrammToolStripMenuItem.Text = "Add Paralelogramm";
            this.addParalelogrammToolStripMenuItem.Click += new System.EventHandler(this.addParalelogrammToolStripMenuItem_Click);
            // 
            // addEllipseToolStripMenuItem
            // 
            this.addEllipseToolStripMenuItem.Name = "addEllipseToolStripMenuItem";
            this.addEllipseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addEllipseToolStripMenuItem.Text = "Add Ellipse";
            this.addEllipseToolStripMenuItem.Click += new System.EventHandler(this.addEllipseToolStripMenuItem_Click);
            // 
            // addStackToolStripMenuItem
            // 
            this.addStackToolStripMenuItem.Name = "addStackToolStripMenuItem";
            this.addStackToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addStackToolStripMenuItem.Text = "Add Stack";
            this.addStackToolStripMenuItem.Click += new System.EventHandler(this.addStackToolStripMenuItem_Click);
            // 
            // addFrameToolStripMenuItem
            // 
            this.addFrameToolStripMenuItem.Name = "addFrameToolStripMenuItem";
            this.addFrameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addFrameToolStripMenuItem.Text = "Add Frame";
            this.addFrameToolStripMenuItem.Click += new System.EventHandler(this.addFrameToolStripMenuItem_Click);
            // 
            // cmSelectedFigure
            // 
            this.cmSelectedFigure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditText,
            this.miAddLine,
            this.miDelete,
            this.toolStripMenuItem1,
            this.bringToFrontToolStripMenuItem,
            this.sendToBackToolStripMenuItem});
            this.cmSelectedFigure.Name = "cmSelectedFigure";
            this.cmSelectedFigure.Size = new System.Drawing.Size(153, 142);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bringToFrontToolStripMenuItem.Text = "Bring to Front";
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // sendToBackToolStripMenuItem
            // 
            this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sendToBackToolStripMenuItem.Text = "Send to Back";
            this.sendToBackToolStripMenuItem.Click += new System.EventHandler(this.sendToBackToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // miEditText
            // 
            this.miEditText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.miEditText.Name = "miEditText";
            this.miEditText.Size = new System.Drawing.Size(152, 22);
            this.miEditText.Text = "Edit text ...";
            this.miEditText.Click += new System.EventHandler(this.editTextToolStripMenuItem_Click);
            // 
            // miAddLine
            // 
            this.miAddLine.Name = "miAddLine";
            this.miAddLine.Size = new System.Drawing.Size(152, 22);
            this.miAddLine.Text = "Add line";
            this.miAddLine.Click += new System.EventHandler(this.miAddLine_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(152, 22);
            this.miDelete.Text = "Delete figure";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // DiagramBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DiagramBox";
            this.cmMain.ResumeLayout(false);
            this.cmSelectedFigure.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem miAddRect;
        private System.Windows.Forms.ToolStripMenuItem addRoundRectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRhombToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addParalelogrammToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEllipseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmSelectedFigure;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miEditText;
        private System.Windows.Forms.ToolStripMenuItem miAddLine;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
    }
}
