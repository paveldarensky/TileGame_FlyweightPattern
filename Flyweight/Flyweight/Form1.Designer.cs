namespace Flyweight
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.button_Reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Maps = new System.Windows.Forms.ComboBox();
            this.label_Map = new System.Windows.Forms.Label();
            this.panel_CreateNewCharacter = new System.Windows.Forms.Panel();
            this.label_CreateNewCharacter = new System.Windows.Forms.Label();
            this.button_CreateCharacter = new System.Windows.Forms.Button();
            this.label_CharacterSkin = new System.Windows.Forms.Label();
            this.textBox_NewCharacterName = new System.Windows.Forms.TextBox();
            this.comboBox_CharacterSkins = new System.Windows.Forms.ComboBox();
            this.panel_ViewSelectedCharacterSkin = new System.Windows.Forms.Panel();
            this.comboBox_CreatedCharacters = new System.Windows.Forms.ComboBox();
            this.button_StartGame = new System.Windows.Forms.Button();
            this.statusStrip_Info = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Info = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_GameSpace = new System.Windows.Forms.Panel();
            this.label_NewCharacterName = new System.Windows.Forms.Label();
            this.label_Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.panel_CreateNewCharacter.SuspendLayout();
            this.statusStrip_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.IsSplitterFixed = true;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.button_Reset);
            this.splitContainer_Main.Panel1.Controls.Add(this.label1);
            this.splitContainer_Main.Panel1.Controls.Add(this.comboBox_Maps);
            this.splitContainer_Main.Panel1.Controls.Add(this.label_Map);
            this.splitContainer_Main.Panel1.Controls.Add(this.panel_CreateNewCharacter);
            this.splitContainer_Main.Panel1.Controls.Add(this.comboBox_CreatedCharacters);
            this.splitContainer_Main.Panel1.Controls.Add(this.button_StartGame);
            this.splitContainer_Main.Panel1.Controls.Add(this.statusStrip_Info);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.label_Score);
            this.splitContainer_Main.Panel2.Controls.Add(this.panel_GameSpace);
            this.splitContainer_Main.Size = new System.Drawing.Size(1264, 761);
            this.splitContainer_Main.SplitterDistance = 360;
            this.splitContainer_Main.TabIndex = 0;
            // 
            // button_Reset
            // 
            this.button_Reset.AutoSize = true;
            this.button_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Reset.Enabled = false;
            this.button_Reset.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Reset.Location = new System.Drawing.Point(271, 664);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(42, 41);
            this.button_Reset.TabIndex = 9;
            this.button_Reset.Text = "↻";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(44, 562);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Созданные персонажи";
            // 
            // comboBox_Maps
            // 
            this.comboBox_Maps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_Maps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Maps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_Maps.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Maps.FormattingEnabled = true;
            this.comboBox_Maps.Items.AddRange(new object[] {
            "Волшебный Лес",
            "Лунная Пустошь",
            "Пещера Вечного Мрака",
            "Город Механических Чудес"});
            this.comboBox_Maps.Location = new System.Drawing.Point(44, 47);
            this.comboBox_Maps.Name = "comboBox_Maps";
            this.comboBox_Maps.Size = new System.Drawing.Size(271, 31);
            this.comboBox_Maps.TabIndex = 0;
            this.comboBox_Maps.SelectedIndexChanged += new System.EventHandler(this.comboBox_Maps_SelectedIndexChanged);
            // 
            // label_Map
            // 
            this.label_Map.AutoSize = true;
            this.label_Map.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Map.Location = new System.Drawing.Point(44, 18);
            this.label_Map.Name = "label_Map";
            this.label_Map.Size = new System.Drawing.Size(138, 21);
            this.label_Map.TabIndex = 7;
            this.label_Map.Text = "Выберите карту";
            // 
            // panel_CreateNewCharacter
            // 
            this.panel_CreateNewCharacter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_CreateNewCharacter.Controls.Add(this.label_NewCharacterName);
            this.panel_CreateNewCharacter.Controls.Add(this.label_CreateNewCharacter);
            this.panel_CreateNewCharacter.Controls.Add(this.button_CreateCharacter);
            this.panel_CreateNewCharacter.Controls.Add(this.label_CharacterSkin);
            this.panel_CreateNewCharacter.Controls.Add(this.textBox_NewCharacterName);
            this.panel_CreateNewCharacter.Controls.Add(this.comboBox_CharacterSkins);
            this.panel_CreateNewCharacter.Controls.Add(this.panel_ViewSelectedCharacterSkin);
            this.panel_CreateNewCharacter.Location = new System.Drawing.Point(21, 97);
            this.panel_CreateNewCharacter.Name = "panel_CreateNewCharacter";
            this.panel_CreateNewCharacter.Size = new System.Drawing.Size(317, 426);
            this.panel_CreateNewCharacter.TabIndex = 7;
            // 
            // label_CreateNewCharacter
            // 
            this.label_CreateNewCharacter.AutoSize = true;
            this.label_CreateNewCharacter.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CreateNewCharacter.Location = new System.Drawing.Point(8, 10);
            this.label_CreateNewCharacter.Name = "label_CreateNewCharacter";
            this.label_CreateNewCharacter.Size = new System.Drawing.Size(301, 27);
            this.label_CreateNewCharacter.TabIndex = 9;
            this.label_CreateNewCharacter.Text = "Создание нового персонажа";
            // 
            // button_CreateCharacter
            // 
            this.button_CreateCharacter.AutoSize = true;
            this.button_CreateCharacter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CreateCharacter.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CreateCharacter.Location = new System.Drawing.Point(83, 373);
            this.button_CreateCharacter.Name = "button_CreateCharacter";
            this.button_CreateCharacter.Size = new System.Drawing.Size(147, 32);
            this.button_CreateCharacter.TabIndex = 8;
            this.button_CreateCharacter.Text = "Создать";
            this.button_CreateCharacter.UseVisualStyleBackColor = true;
            this.button_CreateCharacter.Click += new System.EventHandler(this.button_CreateCharacter_Click);
            // 
            // label_CharacterSkin
            // 
            this.label_CharacterSkin.AutoSize = true;
            this.label_CharacterSkin.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CharacterSkin.Location = new System.Drawing.Point(19, 72);
            this.label_CharacterSkin.Name = "label_CharacterSkin";
            this.label_CharacterSkin.Size = new System.Drawing.Size(223, 21);
            this.label_CharacterSkin.TabIndex = 8;
            this.label_CharacterSkin.Text = "Выберите скин персонажа";
            // 
            // textBox_NewCharacterName
            // 
            this.textBox_NewCharacterName.ForeColor = System.Drawing.Color.Black;
            this.textBox_NewCharacterName.Location = new System.Drawing.Point(22, 327);
            this.textBox_NewCharacterName.Name = "textBox_NewCharacterName";
            this.textBox_NewCharacterName.Size = new System.Drawing.Size(271, 26);
            this.textBox_NewCharacterName.TabIndex = 6;
            // 
            // comboBox_CharacterSkins
            // 
            this.comboBox_CharacterSkins.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_CharacterSkins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CharacterSkins.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_CharacterSkins.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_CharacterSkins.FormattingEnabled = true;
            this.comboBox_CharacterSkins.Items.AddRange(new object[] {
            "Медведь",
            "Капибара",
            "Горилла",
            "Рыцарь",
            "Священик",
            "Маг"});
            this.comboBox_CharacterSkins.Location = new System.Drawing.Point(22, 101);
            this.comboBox_CharacterSkins.Name = "comboBox_CharacterSkins";
            this.comboBox_CharacterSkins.Size = new System.Drawing.Size(271, 31);
            this.comboBox_CharacterSkins.TabIndex = 2;
            this.comboBox_CharacterSkins.SelectedIndexChanged += new System.EventHandler(this.comboBox_CharacterSkins_SelectedIndexChanged);
            // 
            // panel_ViewSelectedCharacterSkin
            // 
            this.panel_ViewSelectedCharacterSkin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_ViewSelectedCharacterSkin.Location = new System.Drawing.Point(88, 147);
            this.panel_ViewSelectedCharacterSkin.Name = "panel_ViewSelectedCharacterSkin";
            this.panel_ViewSelectedCharacterSkin.Size = new System.Drawing.Size(128, 128);
            this.panel_ViewSelectedCharacterSkin.TabIndex = 3;
            // 
            // comboBox_CreatedCharacters
            // 
            this.comboBox_CreatedCharacters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_CreatedCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CreatedCharacters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_CreatedCharacters.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_CreatedCharacters.FormattingEnabled = true;
            this.comboBox_CreatedCharacters.Location = new System.Drawing.Point(44, 593);
            this.comboBox_CreatedCharacters.Name = "comboBox_CreatedCharacters";
            this.comboBox_CreatedCharacters.Size = new System.Drawing.Size(271, 31);
            this.comboBox_CreatedCharacters.TabIndex = 5;
            // 
            // button_StartGame
            // 
            this.button_StartGame.AutoSize = true;
            this.button_StartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_StartGame.Enabled = false;
            this.button_StartGame.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_StartGame.Location = new System.Drawing.Point(105, 668);
            this.button_StartGame.Name = "button_StartGame";
            this.button_StartGame.Size = new System.Drawing.Size(147, 32);
            this.button_StartGame.TabIndex = 4;
            this.button_StartGame.Text = "Начать играть";
            this.button_StartGame.UseVisualStyleBackColor = true;
            this.button_StartGame.Click += new System.EventHandler(this.button_StartGame_Click);
            // 
            // statusStrip_Info
            // 
            this.statusStrip_Info.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Info});
            this.statusStrip_Info.Location = new System.Drawing.Point(0, 735);
            this.statusStrip_Info.Name = "statusStrip_Info";
            this.statusStrip_Info.Size = new System.Drawing.Size(358, 24);
            this.statusStrip_Info.TabIndex = 1;
            this.statusStrip_Info.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Info
            // 
            this.toolStripStatusLabel_Info.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel_Info.Name = "toolStripStatusLabel_Info";
            this.toolStripStatusLabel_Info.Size = new System.Drawing.Size(168, 19);
            this.toolStripStatusLabel_Info.Text = "Инициализация игры...";
            // 
            // panel_GameSpace
            // 
            this.panel_GameSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_GameSpace.Location = new System.Drawing.Point(127, 60);
            this.panel_GameSpace.Name = "panel_GameSpace";
            this.panel_GameSpace.Size = new System.Drawing.Size(640, 640);
            this.panel_GameSpace.TabIndex = 0;
            // 
            // label_NewCharacterName
            // 
            this.label_NewCharacterName.AutoSize = true;
            this.label_NewCharacterName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_NewCharacterName.Location = new System.Drawing.Point(19, 299);
            this.label_NewCharacterName.Name = "label_NewCharacterName";
            this.label_NewCharacterName.Size = new System.Drawing.Size(202, 21);
            this.label_NewCharacterName.TabIndex = 10;
            this.label_NewCharacterName.Text = "Введите имя персонажа";
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Score.Location = new System.Drawing.Point(406, 20);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(85, 27);
            this.label_Score.TabIndex = 11;
            this.label_Score.Text = "Счёт: 0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.splitContainer_Main);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel1.PerformLayout();
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            this.splitContainer_Main.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.panel_CreateNewCharacter.ResumeLayout(false);
            this.panel_CreateNewCharacter.PerformLayout();
            this.statusStrip_Info.ResumeLayout(false);
            this.statusStrip_Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.ComboBox comboBox_Maps;
        private System.Windows.Forms.Panel panel_GameSpace;
        private System.Windows.Forms.StatusStrip statusStrip_Info;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Info;
        private System.Windows.Forms.Button button_StartGame;
        private System.Windows.Forms.Panel panel_ViewSelectedCharacterSkin;
        private System.Windows.Forms.ComboBox comboBox_CharacterSkins;
        private System.Windows.Forms.TextBox textBox_NewCharacterName;
        private System.Windows.Forms.ComboBox comboBox_CreatedCharacters;
        private System.Windows.Forms.Panel panel_CreateNewCharacter;
        private System.Windows.Forms.Label label_Map;
        private System.Windows.Forms.Button button_CreateCharacter;
        private System.Windows.Forms.Label label_CharacterSkin;
        private System.Windows.Forms.Label label_CreateNewCharacter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Label label_NewCharacterName;
        private System.Windows.Forms.Label label_Score;
    }
}

