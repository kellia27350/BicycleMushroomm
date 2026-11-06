using System;
using System.Windows.Forms;

public class BicycleForm : Form
{
    TextBox txtStart = new TextBox();
    TextBox txtEnd = new TextBox();
    TextBox txtTotal = new TextBox();

    public BicycleForm()
    {
        Text = "Bicycle Rental";
        ClientSize = new System.Drawing.Size(320, 270);
        StartPosition = FormStartPosition.CenterScreen;

        Label l1 = new Label { Text = "Start hour (0-23):", Left = 20, Top = 25, Width = 120 };
        txtStart.SetBounds(150, 22, 130, 25);

        Label l2 = new Label { Text = "End hour (1-24):", Left = 20, Top = 65, Width = 120 };
        txtEnd.SetBounds(150, 62, 130, 25);

        Button btnCalc = new Button { Text = "Calculate", Left = 150, Top = 100, Width = 130, Height = 30 };
        btnCalc.Click += btnCalc_Click;

        Label l3 = new Label { Text = "Total (RWF):", Left = 20, Top = 150, Width = 120 };
        txtTotal.SetBounds(150, 147, 130, 25);
        txtTotal.ReadOnly = true;

        Button btnBack = new Button { Text = "Back", Left = 40, Top = 210, Width = 100, Height = 30 };
        Button btnLogout = new Button { Text = "Logout", Left = 180, Top = 210, Width = 100, Height = 30 };

        btnBack.Click += (s, e) => { new ChooseForm().Show(); Close(); };
        btnLogout.Click += (s, e) => { Program.Login.Show(); Close(); };

        Controls.AddRange(new Control[] { l1, txtStart, l2, txtEnd, btnCalc, l3, txtTotal, btnBack, btnLogout });

        FormClosed += (s, e) =>
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        };
    }

    void btnCalc_Click(object sender, EventArgs e)
    {
        int start, end;

        // Only whole numbers are accepted
        if (!int.TryParse(txtStart.Text, out start) || !int.TryParse(txtEnd.Text, out end))
        {
            MessageBox.Show("Please enter whole numbers only.");
            return;
        }

        if (start < 0 || start > 23 || end < 1 || end > 24 || start >= end)
        {
            MessageBox.Show("Start must be 0-23, End must be 1-24, and Start must be less than End.");
            return;
        }

        int total = 0;

        for (int hour = start; hour < end; hour++)
        {
            if (hour < 7 || hour >= 21)
                total += 500;       // 0-7 and 21-24
            else if (hour < 14 || hour >= 19)
                total += 1000;      // 7-14 and 19-21
            else
                total += 1500;      // 14-19
        }

        txtTotal.Text = total.ToString();
    }
}