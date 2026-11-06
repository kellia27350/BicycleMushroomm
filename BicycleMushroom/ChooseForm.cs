using System;
using System.Windows.Forms;

public class ChooseForm : Form
{
    public ChooseForm()
    {
        Text = "Choose";
        ClientSize = new System.Drawing.Size(300, 150);
        StartPosition = FormStartPosition.CenterScreen;

        Button btnBike = new Button { Text = "Bicycle", Left = 80, Top = 25, Width = 140, Height = 40 };
        Button btnMush = new Button { Text = "Mushroom", Left = 80, Top = 80, Width = 140, Height = 40 };

        btnBike.Click += (s, e) => { new BicycleForm().Show(); Close(); };
        btnMush.Click += (s, e) => { new MushroomForm().Show(); Close(); };

        Controls.Add(btnBike);
        Controls.Add(btnMush);

        // If the user clicks the X button, close the whole program
        FormClosed += (s, e) =>
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        };
    }
}