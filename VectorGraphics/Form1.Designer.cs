namespace Diagrams
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.addBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.commentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addEdgeLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bringToFrontToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdDiagram = new System.Windows.Forms.SaveFileDialog();
            this.ofdDiagram = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.cmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddRect = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoundRectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRhombToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addParalelogrammToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSelectedFigure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEditText = new System.Windows.Forms.ToolStripMenuItem();
            this.incToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.decToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miAddLedgeLine = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbDiagram = new Diagrams.DiagramBox();
            this.menuStrip1.SuspendLayout();
            this.cmMain.SuspendLayout();
            this.cmSelectedFigure.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.addBlockToolStripMenuItem,
            this.cToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miLoad,
            this.toolStripSeparator2,
            this.miSave,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.miClose});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem1.Text = "Файл";
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(145, 22);
            this.miNew.Text = "Нова схема";
            this.miNew.Click += new System.EventHandler(this.miNewDiagram_Click);
            // 
            // miLoad
            // 
            this.miLoad.Name = "miLoad";
            this.miLoad.Size = new System.Drawing.Size(145, 22);
            this.miLoad.Text = "Відкрити";
            this.miLoad.Click += new System.EventHandler(this.miLoad_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(142, 6);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(145, 22);
            this.miSave.Text = "Зберегти";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveAsToolStripMenuItem.Text = "Зберегти як..";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(142, 6);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(145, 22);
            this.miClose.Text = "Вихід";
            this.miClose.Click += new System.EventHandler(this.miExit_Click);
            // 
            // addBlockToolStripMenuItem
            // 
            this.addBlockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRectangleToolStripMenuItem,
            this.addToolStripMenuItem,
            this.addToolStripMenuItem1,
            this.addToolStripMenuItem2,
            this.addToolStripMenuItem4,
            this.addToolStripMenuItem6,
            this.addToolStripMenuItem5,
            this.commentToolStripMenuItem1});
            this.addBlockToolStripMenuItem.Name = "addBlockToolStripMenuItem";
            this.addBlockToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.addBlockToolStripMenuItem.Text = "Додати Блок";
            // 
            // addRectangleToolStripMenuItem
            // 
            this.addRectangleToolStripMenuItem.Name = "addRectangleToolStripMenuItem";
            this.addRectangleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addRectangleToolStripMenuItem.Text = "Процес";
            this.addRectangleToolStripMenuItem.Click += new System.EventHandler(this.addRectangleToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addToolStripMenuItem.Text = "Початок";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.addToolStripMenuItem1.Text = "Рішення";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // addToolStripMenuItem2
            // 
            this.addToolStripMenuItem2.Name = "addToolStripMenuItem2";
            this.addToolStripMenuItem2.Size = new System.Drawing.Size(186, 22);
            this.addToolStripMenuItem2.Text = "Дані";
            this.addToolStripMenuItem2.Click += new System.EventHandler(this.addToolStripMenuItem2_Click);
            // 
            // addToolStripMenuItem4
            // 
            this.addToolStripMenuItem4.Name = "addToolStripMenuItem4";
            this.addToolStripMenuItem4.Size = new System.Drawing.Size(186, 22);
            this.addToolStripMenuItem4.Text = "Цикл";
            this.addToolStripMenuItem4.Click += new System.EventHandler(this.addToolStripMenuItem4_Click);
            // 
            // addToolStripMenuItem6
            // 
            this.addToolStripMenuItem6.Name = "addToolStripMenuItem6";
            this.addToolStripMenuItem6.Size = new System.Drawing.Size(186, 22);
            this.addToolStripMenuItem6.Text = "Зумовлений процес";
            this.addToolStripMenuItem6.Click += new System.EventHandler(this.addToolStripMenuItem6_Click);
            // 
            // addToolStripMenuItem5
            // 
            this.addToolStripMenuItem5.Name = "addToolStripMenuItem5";
            this.addToolStripMenuItem5.Size = new System.Drawing.Size(186, 22);
            this.addToolStripMenuItem5.Text = "З\'єднувач";
            this.addToolStripMenuItem5.Click += new System.EventHandler(this.addToolStripMenuItem5_Click);
            // 
            // commentToolStripMenuItem1
            // 
            this.commentToolStripMenuItem1.Name = "commentToolStripMenuItem1";
            this.commentToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.commentToolStripMenuItem1.Text = "Коментар";
            this.commentToolStripMenuItem1.Click += new System.EventHandler(this.commentToolStripMenuItem1_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTextToolStripMenuItem,
            this.incToolStripMenuItem,
            this.decToolStripMenuItem,
            this.toolStripSeparator4,
            this.addEdgeLineToolStripMenuItem,
            this.deleteBlockToolStripMenuItem,
            this.toolStripSeparator3,
            this.bringToFrontToolStripMenuItem1,
            this.sendToBackToolStripMenuItem1});
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.cToolStripMenuItem.Text = "Редагувати";
            // 
            // editTextToolStripMenuItem
            // 
            this.editTextToolStripMenuItem.Name = "editTextToolStripMenuItem";
            this.editTextToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.editTextToolStripMenuItem.Text = "Редагувати текст";
            this.editTextToolStripMenuItem.Click += new System.EventHandler(this.editTextToolStripMenuItem_Click_1);
            // 
            // incToolStripMenuItem
            // 
            this.incToolStripMenuItem.Name = "incToolStripMenuItem";
            this.incToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.incToolStripMenuItem.Text = "Збільшити текст";
            this.incToolStripMenuItem.Click += new System.EventHandler(this.incToolStripMenuItem_Click);
            // 
            // decToolStripMenuItem
            // 
            this.decToolStripMenuItem.Name = "decToolStripMenuItem";
            this.decToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.decToolStripMenuItem.Text = "Зменшити текст";
            this.decToolStripMenuItem.Click += new System.EventHandler(this.decToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(168, 6);
            // 
            // addEdgeLineToolStripMenuItem
            // 
            this.addEdgeLineToolStripMenuItem.Name = "addEdgeLineToolStripMenuItem";
            this.addEdgeLineToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addEdgeLineToolStripMenuItem.Text = "Додати лінію";
            this.addEdgeLineToolStripMenuItem.Click += new System.EventHandler(this.addEdgeLineToolStripMenuItem_Click);
            // 
            // deleteBlockToolStripMenuItem
            // 
            this.deleteBlockToolStripMenuItem.Name = "deleteBlockToolStripMenuItem";
            this.deleteBlockToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteBlockToolStripMenuItem.Text = "Видалити блок";
            this.deleteBlockToolStripMenuItem.Click += new System.EventHandler(this.deleteBlockToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // bringToFrontToolStripMenuItem1
            // 
            this.bringToFrontToolStripMenuItem1.Name = "bringToFrontToolStripMenuItem1";
            this.bringToFrontToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.bringToFrontToolStripMenuItem1.Text = "На передній план";
            this.bringToFrontToolStripMenuItem1.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem1_Click);
            // 
            // sendToBackToolStripMenuItem1
            // 
            this.sendToBackToolStripMenuItem1.Name = "sendToBackToolStripMenuItem1";
            this.sendToBackToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.sendToBackToolStripMenuItem1.Text = "На задній план";
            this.sendToBackToolStripMenuItem1.Click += new System.EventHandler(this.sendToBackToolStripMenuItem1_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.hELPToolStripMenuItem.Text = "Допомога";
            this.hELPToolStripMenuItem.Click += new System.EventHandler(this.hELPToolStripMenuItem_Click);
            // 
            // sfdDiagram
            // 
            this.sfdDiagram.DefaultExt = "diagram";
            this.sfdDiagram.Filter = "Diagram|*.diagram";
            // 
            // ofdDiagram
            // 
            this.ofdDiagram.DefaultExt = "diagram";
            this.ofdDiagram.Filter = "Diagram|*.diagram";
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "PNG Image(*.png)|*.png";
            // 
            // cmMain
            // 
            this.cmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddRect,
            this.addRoundRectToolStripMenuItem,
            this.addRhombToolStripMenuItem,
            this.addParalelogrammToolStripMenuItem,
            this.addCycleToolStripMenuItem,
            this.addCircleToolStripMenuItem,
            this.addProcessToolStripMenuItem,
            this.commentToolStripMenuItem});
            this.cmMain.Name = "cmMain";
            this.cmMain.Size = new System.Drawing.Size(187, 180);
            // 
            // miAddRect
            // 
            this.miAddRect.Name = "miAddRect";
            this.miAddRect.Size = new System.Drawing.Size(186, 22);
            this.miAddRect.Text = "Процес";
            this.miAddRect.Click += new System.EventHandler(this.miAddRect_Click);
            // 
            // addRoundRectToolStripMenuItem
            // 
            this.addRoundRectToolStripMenuItem.Name = "addRoundRectToolStripMenuItem";
            this.addRoundRectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addRoundRectToolStripMenuItem.Text = "Початок";
            this.addRoundRectToolStripMenuItem.Click += new System.EventHandler(this.addRoundRectToolStripMenuItem_Click);
            // 
            // addRhombToolStripMenuItem
            // 
            this.addRhombToolStripMenuItem.Name = "addRhombToolStripMenuItem";
            this.addRhombToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addRhombToolStripMenuItem.Text = "Ріщення";
            this.addRhombToolStripMenuItem.Click += new System.EventHandler(this.addRhombToolStripMenuItem_Click);
            // 
            // addParalelogrammToolStripMenuItem
            // 
            this.addParalelogrammToolStripMenuItem.Name = "addParalelogrammToolStripMenuItem";
            this.addParalelogrammToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addParalelogrammToolStripMenuItem.Text = "Дані";
            this.addParalelogrammToolStripMenuItem.Click += new System.EventHandler(this.addParalelogrammToolStripMenuItem_Click);
            // 
            // addCycleToolStripMenuItem
            // 
            this.addCycleToolStripMenuItem.Name = "addCycleToolStripMenuItem";
            this.addCycleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addCycleToolStripMenuItem.Text = "Цикл";
            this.addCycleToolStripMenuItem.Click += new System.EventHandler(this.addCycleToolStripMenuItem_Click);
            // 
            // addCircleToolStripMenuItem
            // 
            this.addCircleToolStripMenuItem.Name = "addCircleToolStripMenuItem";
            this.addCircleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addCircleToolStripMenuItem.Text = "З\'єднувач";
            this.addCircleToolStripMenuItem.Click += new System.EventHandler(this.addCircleToolStripMenuItem_Click);
            // 
            // addProcessToolStripMenuItem
            // 
            this.addProcessToolStripMenuItem.Name = "addProcessToolStripMenuItem";
            this.addProcessToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addProcessToolStripMenuItem.Text = "Зумовлений процес";
            this.addProcessToolStripMenuItem.Click += new System.EventHandler(this.addProcessToolStripMenuItem_Click);
            // 
            // commentToolStripMenuItem
            // 
            this.commentToolStripMenuItem.Name = "commentToolStripMenuItem";
            this.commentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.commentToolStripMenuItem.Text = "Коментар";
            this.commentToolStripMenuItem.Click += new System.EventHandler(this.commentToolStripMenuItem_Click);
            // 
            // cmSelectedFigure
            // 
            this.cmSelectedFigure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditText,
            this.incToolStripMenuItem1,
            this.decToolStripMenuItem1,
            this.toolStripSeparator1,
            this.miAddLedgeLine,
            this.miDelete,
            this.toolStripMenuItem1,
            this.bringToFrontToolStripMenuItem,
            this.sendToBackToolStripMenuItem});
            this.cmSelectedFigure.Name = "cmSelectedFigure";
            this.cmSelectedFigure.Size = new System.Drawing.Size(172, 170);
            // 
            // miEditText
            // 
            this.miEditText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.miEditText.Name = "miEditText";
            this.miEditText.Size = new System.Drawing.Size(171, 22);
            this.miEditText.Text = "Редагувати текст";
            this.miEditText.Click += new System.EventHandler(this.editTextToolStripMenuItem_Click);
            // 
            // incToolStripMenuItem1
            // 
            this.incToolStripMenuItem1.Name = "incToolStripMenuItem1";
            this.incToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.incToolStripMenuItem1.Text = "Збільшити текст";
            this.incToolStripMenuItem1.Click += new System.EventHandler(this.incToolStripMenuItem1_Click);
            // 
            // decToolStripMenuItem1
            // 
            this.decToolStripMenuItem1.Name = "decToolStripMenuItem1";
            this.decToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.decToolStripMenuItem1.Text = "Зменшити текст";
            this.decToolStripMenuItem1.Click += new System.EventHandler(this.decToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // miAddLedgeLine
            // 
            this.miAddLedgeLine.Name = "miAddLedgeLine";
            this.miAddLedgeLine.Size = new System.Drawing.Size(171, 22);
            this.miAddLedgeLine.Text = "Додати лінію";
            this.miAddLedgeLine.Click += new System.EventHandler(this.miAddLedgeLine_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(171, 22);
            this.miDelete.Text = "Видалити блок";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.bringToFrontToolStripMenuItem.Text = "На передній план";
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // sendToBackToolStripMenuItem
            // 
            this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.sendToBackToolStripMenuItem.Text = "На задній план";
            this.sendToBackToolStripMenuItem.Click += new System.EventHandler(this.sendToBackToolStripMenuItem_Click);
            // 
            // dbDiagram
            // 
            this.dbDiagram.AutoScroll = true;
            this.dbDiagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dbDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbDiagram.ContextMenuStrip = this.cmMain;
            this.dbDiagram.Diagram = null;
            this.dbDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbDiagram.Location = new System.Drawing.Point(0, 24);
            this.dbDiagram.Name = "dbDiagram";
            this.dbDiagram.SelectedFigure = null;
            this.dbDiagram.Size = new System.Drawing.Size(434, 259);
            this.dbDiagram.TabIndex = 3;
            this.dbDiagram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbDiagram_KeyDown);
            this.dbDiagram.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseDoubleClick);
            this.dbDiagram.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 283);
            this.Controls.Add(this.dbDiagram);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FlowChart Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmMain.ResumeLayout(false);
            this.cmSelectedFigure.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SaveFileDialog sfdDiagram;
        private System.Windows.Forms.OpenFileDialog ofdDiagram;
        private DiagramBox dbDiagram;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.ContextMenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem miAddRect;
        private System.Windows.Forms.ToolStripMenuItem addRoundRectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRhombToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addParalelogrammToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmSelectedFigure;
        private System.Windows.Forms.ToolStripMenuItem miEditText;
        private System.Windows.Forms.ToolStripMenuItem miAddLedgeLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEdgeLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miLoad;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem commentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem incToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem decToolStripMenuItem1;
    }
}

