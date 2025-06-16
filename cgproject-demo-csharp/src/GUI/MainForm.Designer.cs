namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.SelectColorDialog = new System.Windows.Forms.ColorDialog();
            this.drawElipseSpeedButton = new System.Windows.Forms.Button();
            this.selectColor = new System.Windows.Forms.Button();
            this.SelectBorderColorDialog = new System.Windows.Forms.ColorDialog();
            this.selectBorderColor = new System.Windows.Forms.Button();
            this.borderWidthControl = new System.Windows.Forms.NumericUpDown();
            this.transparencyChanger = new System.Windows.Forms.TrackBar();
            this.DrawCircleButton = new System.Windows.Forms.Button();
            this.DrawHexagonShape = new System.Windows.Forms.Button();
            this.DrawSquareShape = new System.Windows.Forms.Button();
            this.DrawComplexStarShape = new System.Windows.Forms.Button();
            this.DrawTriangleShape = new System.Windows.Forms.Button();
            this.DrawStarShape = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.RotationBar = new System.Windows.Forms.TrackBar();
            this.ScalingTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupButton = new System.Windows.Forms.Button();
            this.UngroupButton = new System.Windows.Forms.Button();
            this.DeleteShapeButton = new System.Windows.Forms.Button();
            this.CopyShapeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyChanger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScalingTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1782, 28);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            this.mainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainMenu_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 499);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(1782, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // speedMenu
            // 
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawRectangleSpeedButton,
            this.pickUpSpeedButton});
            this.speedMenu.Location = new System.Drawing.Point(0, 28);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(1782, 27);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawRectangleSpeedButton.Text = "DrawRectangleButton";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.pickUpSpeedButton.Text = "toolStripButton1";
            // 
            // drawElipseSpeedButton
            // 
            this.drawElipseSpeedButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("drawElipseSpeedButton.BackgroundImage")));
            this.drawElipseSpeedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawElipseSpeedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.drawElipseSpeedButton.Location = new System.Drawing.Point(71, 31);
            this.drawElipseSpeedButton.Name = "drawElipseSpeedButton";
            this.drawElipseSpeedButton.Size = new System.Drawing.Size(42, 30);
            this.drawElipseSpeedButton.TabIndex = 5;
            this.drawElipseSpeedButton.UseVisualStyleBackColor = true;
            this.drawElipseSpeedButton.Click += new System.EventHandler(this.drawElipseSpeedButton_Click_1);
            // 
            // selectColor
            // 
            this.selectColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("selectColor.BackgroundImage")));
            this.selectColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectColor.Location = new System.Drawing.Point(715, 28);
            this.selectColor.Name = "selectColor";
            this.selectColor.Size = new System.Drawing.Size(36, 35);
            this.selectColor.TabIndex = 6;
            this.selectColor.UseVisualStyleBackColor = true;
            this.selectColor.Click += new System.EventHandler(this.selectColor_Click);
            // 
            // selectBorderColor
            // 
            this.selectBorderColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("selectBorderColor.BackgroundImage")));
            this.selectBorderColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectBorderColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectBorderColor.Location = new System.Drawing.Point(757, 27);
            this.selectBorderColor.Name = "selectBorderColor";
            this.selectBorderColor.Size = new System.Drawing.Size(35, 35);
            this.selectBorderColor.TabIndex = 7;
            this.selectBorderColor.UseVisualStyleBackColor = true;
            this.selectBorderColor.Click += new System.EventHandler(this.selectBorderColor_Click);
            // 
            // borderWidthControl
            // 
            this.borderWidthControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.borderWidthControl.Location = new System.Drawing.Point(808, 33);
            this.borderWidthControl.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.borderWidthControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.borderWidthControl.Name = "borderWidthControl";
            this.borderWidthControl.Size = new System.Drawing.Size(57, 22);
            this.borderWidthControl.TabIndex = 8;
            this.borderWidthControl.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.borderWidthControl.ValueChanged += new System.EventHandler(this.borderWidthControl_ValueChanged);
            // 
            // transparencyChanger
            // 
            this.transparencyChanger.Location = new System.Drawing.Point(1108, 28);
            this.transparencyChanger.Maximum = 255;
            this.transparencyChanger.Name = "transparencyChanger";
            this.transparencyChanger.Size = new System.Drawing.Size(143, 56);
            this.transparencyChanger.TabIndex = 9;
            this.transparencyChanger.Value = 255;
            this.transparencyChanger.Scroll += new System.EventHandler(this.transparentcyChanger_Scroll);
            // 
            // DrawCircleButton
            // 
            this.DrawCircleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DrawCircleButton.BackgroundImage")));
            this.DrawCircleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DrawCircleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawCircleButton.Location = new System.Drawing.Point(119, 30);
            this.DrawCircleButton.Name = "DrawCircleButton";
            this.DrawCircleButton.Size = new System.Drawing.Size(39, 32);
            this.DrawCircleButton.TabIndex = 10;
            this.DrawCircleButton.UseVisualStyleBackColor = true;
            this.DrawCircleButton.Click += new System.EventHandler(this.DrawCircleButton_Click);
            // 
            // DrawHexagonShape
            // 
            this.DrawHexagonShape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DrawHexagonShape.BackgroundImage")));
            this.DrawHexagonShape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DrawHexagonShape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawHexagonShape.Location = new System.Drawing.Point(164, 30);
            this.DrawHexagonShape.Name = "DrawHexagonShape";
            this.DrawHexagonShape.Size = new System.Drawing.Size(39, 33);
            this.DrawHexagonShape.TabIndex = 11;
            this.DrawHexagonShape.UseVisualStyleBackColor = true;
            this.DrawHexagonShape.Click += new System.EventHandler(this.DrawHexagonShape_Click);
            // 
            // DrawSquareShape
            // 
            this.DrawSquareShape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DrawSquareShape.BackgroundImage")));
            this.DrawSquareShape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DrawSquareShape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawSquareShape.Location = new System.Drawing.Point(209, 32);
            this.DrawSquareShape.Name = "DrawSquareShape";
            this.DrawSquareShape.Size = new System.Drawing.Size(30, 30);
            this.DrawSquareShape.TabIndex = 14;
            this.DrawSquareShape.UseVisualStyleBackColor = true;
            this.DrawSquareShape.Click += new System.EventHandler(this.DrawSquareShape_Click);
            // 
            // DrawComplexStarShape
            // 
            this.DrawComplexStarShape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DrawComplexStarShape.BackgroundImage")));
            this.DrawComplexStarShape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DrawComplexStarShape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawComplexStarShape.Location = new System.Drawing.Point(245, 31);
            this.DrawComplexStarShape.Name = "DrawComplexStarShape";
            this.DrawComplexStarShape.Size = new System.Drawing.Size(38, 34);
            this.DrawComplexStarShape.TabIndex = 15;
            this.DrawComplexStarShape.UseVisualStyleBackColor = true;
            this.DrawComplexStarShape.Click += new System.EventHandler(this.DrawComplexStarShape_Click);
            // 
            // DrawTriangleShape
            // 
            this.DrawTriangleShape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DrawTriangleShape.BackgroundImage")));
            this.DrawTriangleShape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DrawTriangleShape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawTriangleShape.Location = new System.Drawing.Point(289, 31);
            this.DrawTriangleShape.Name = "DrawTriangleShape";
            this.DrawTriangleShape.Size = new System.Drawing.Size(36, 36);
            this.DrawTriangleShape.TabIndex = 16;
            this.DrawTriangleShape.UseVisualStyleBackColor = true;
            this.DrawTriangleShape.Click += new System.EventHandler(this.DrawTriangleShape_Click);
            // 
            // DrawStarShape
            // 
            this.DrawStarShape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DrawStarShape.BackgroundImage")));
            this.DrawStarShape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DrawStarShape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawStarShape.Location = new System.Drawing.Point(331, 32);
            this.DrawStarShape.Name = "DrawStarShape";
            this.DrawStarShape.Size = new System.Drawing.Size(38, 35);
            this.DrawStarShape.TabIndex = 17;
            this.DrawStarShape.UseVisualStyleBackColor = true;
            this.DrawStarShape.Click += new System.EventHandler(this.DrawStarShape_Click);
            // 
            // RotationBar
            // 
            this.RotationBar.Location = new System.Drawing.Point(1272, 28);
            this.RotationBar.Maximum = 360;
            this.RotationBar.Name = "RotationBar";
            this.RotationBar.Size = new System.Drawing.Size(104, 56);
            this.RotationBar.TabIndex = 18;
            this.RotationBar.Value = 1;
            this.RotationBar.Scroll += new System.EventHandler(this.RotationBar_Scroll);
            // 
            // ScalingTrackBar
            // 
            this.ScalingTrackBar.Location = new System.Drawing.Point(1399, 28);
            this.ScalingTrackBar.Maximum = 200;
            this.ScalingTrackBar.Minimum = 10;
            this.ScalingTrackBar.Name = "ScalingTrackBar";
            this.ScalingTrackBar.Size = new System.Drawing.Size(104, 56);
            this.ScalingTrackBar.TabIndex = 19;
            this.ScalingTrackBar.Value = 100;
            this.ScalingTrackBar.Scroll += new System.EventHandler(this.ScalingTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1127, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Transperancy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1297, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Rotation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1422, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Scaling";
            // 
            // GroupButton
            // 
            this.GroupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GroupButton.Location = new System.Drawing.Point(548, 30);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.Size = new System.Drawing.Size(70, 32);
            this.GroupButton.TabIndex = 23;
            this.GroupButton.Text = "Group";
            this.GroupButton.UseVisualStyleBackColor = true;
            this.GroupButton.Click += new System.EventHandler(this.GroupButton_Click);
            // 
            // UngroupButton
            // 
            this.UngroupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UngroupButton.Location = new System.Drawing.Point(624, 29);
            this.UngroupButton.Name = "UngroupButton";
            this.UngroupButton.Size = new System.Drawing.Size(75, 33);
            this.UngroupButton.TabIndex = 24;
            this.UngroupButton.Text = "Ungroup";
            this.UngroupButton.UseVisualStyleBackColor = true;
            this.UngroupButton.Click += new System.EventHandler(this.UngroupButton_Click);
            // 
            // DeleteShapeButton
            // 
            this.DeleteShapeButton.BackColor = System.Drawing.Color.IndianRed;
            this.DeleteShapeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteShapeButton.BackgroundImage")));
            this.DeleteShapeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteShapeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteShapeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteShapeButton.ForeColor = System.Drawing.Color.Maroon;
            this.DeleteShapeButton.Location = new System.Drawing.Point(887, 30);
            this.DeleteShapeButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteShapeButton.Name = "DeleteShapeButton";
            this.DeleteShapeButton.Size = new System.Drawing.Size(39, 35);
            this.DeleteShapeButton.TabIndex = 25;
            this.DeleteShapeButton.UseVisualStyleBackColor = false;
            this.DeleteShapeButton.Click += new System.EventHandler(this.DeleteShapeButton_Click);
            // 
            // CopyShapeButton
            // 
            this.CopyShapeButton.BackColor = System.Drawing.Color.SandyBrown;
            this.CopyShapeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CopyShapeButton.BackgroundImage")));
            this.CopyShapeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyShapeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyShapeButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.CopyShapeButton.Location = new System.Drawing.Point(936, 28);
            this.CopyShapeButton.Margin = new System.Windows.Forms.Padding(0);
            this.CopyShapeButton.Name = "CopyShapeButton";
            this.CopyShapeButton.Size = new System.Drawing.Size(54, 37);
            this.CopyShapeButton.TabIndex = 26;
            this.CopyShapeButton.UseVisualStyleBackColor = false;
            this.CopyShapeButton.Click += new System.EventHandler(this.CopyShapeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Olive;
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(1662, 34);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 32);
            this.saveButton.TabIndex = 27;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.Khaki;
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.loadButton.Location = new System.Drawing.Point(1572, 33);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 32);
            this.loadButton.TabIndex = 28;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(375, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 35);
            this.button1.TabIndex = 29;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(425, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 33);
            this.button2.TabIndex = 30;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.viewPort.Location = new System.Drawing.Point(0, 55);
            this.viewPort.Margin = new System.Windows.Forms.Padding(5);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(1782, 444);
            this.viewPort.TabIndex = 4;
            this.viewPort.Load += new System.EventHandler(this.viewPort_Load);
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(465, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 54);
            this.button3.TabIndex = 31;
            this.button3.Text = "New Trapeze";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1782, 521);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.CopyShapeButton);
            this.Controls.Add(this.DeleteShapeButton);
            this.Controls.Add(this.UngroupButton);
            this.Controls.Add(this.GroupButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScalingTrackBar);
            this.Controls.Add(this.RotationBar);
            this.Controls.Add(this.DrawStarShape);
            this.Controls.Add(this.DrawTriangleShape);
            this.Controls.Add(this.DrawComplexStarShape);
            this.Controls.Add(this.DrawSquareShape);
            this.Controls.Add(this.DrawHexagonShape);
            this.Controls.Add(this.DrawCircleButton);
            this.Controls.Add(this.transparencyChanger);
            this.Controls.Add(this.borderWidthControl);
            this.Controls.Add(this.selectBorderColor);
            this.Controls.Add(this.selectColor);
            this.Controls.Add(this.drawElipseSpeedButton);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderWidthControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyChanger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScalingTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ColorDialog SelectColorDialog;
        private System.Windows.Forms.Button drawElipseSpeedButton;
        private System.Windows.Forms.Button selectColor;
        private System.Windows.Forms.ColorDialog SelectBorderColorDialog;
        private System.Windows.Forms.Button selectBorderColor;
        private System.Windows.Forms.NumericUpDown borderWidthControl;
        private System.Windows.Forms.TrackBar transparencyChanger;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button DrawCircleButton;
        private System.Windows.Forms.Button DrawHexagonShape;
        private System.Windows.Forms.Button DrawSquareShape;
        private System.Windows.Forms.Button DrawComplexStarShape;
        private System.Windows.Forms.Button DrawTriangleShape;
        private System.Windows.Forms.Button DrawStarShape;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TrackBar RotationBar;
        private System.Windows.Forms.TrackBar ScalingTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.Button UngroupButton;
        private System.Windows.Forms.Button DeleteShapeButton;
        private System.Windows.Forms.Button CopyShapeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
