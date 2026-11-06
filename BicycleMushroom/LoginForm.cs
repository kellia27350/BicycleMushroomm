using System;
using System.Windows.Forms;

public class LoginForm : Form
{
    TextBox txtUser = new TextBox();
    TextBox txtPass = new TextBox();
    Button btnLogin = new Button();

    public LoginForm()
    {
        Text = "Login";
        ClientSize = new System.Drawing.Size(300, 170);
        StartPosition = FormStartPosition.CenterScreen;

        Label l1 = new Label { Text = "Username:", Left = 20, Top = 20, Width = 80 };
        txtUser.SetBounds(110, 18, 160, 25);

        Label l2 = new Label { Text = "Password:", Left = 20, Top = 60, Width = 80 };
        txtPass.SetBounds(110, 58, 160, 25);
        txtPass.UseSystemPasswordChar = true;   // shows dots

        btnLogin.Text = "Login";
        btnLogin.SetBounds(110, 105, 100, 30);
        btnLogin.Click += btnLogin_Click;
        AcceptButton = btnLogin;                // Enter key = Login

        Controls.AddRange(new Control[] { l1, txtUser, l2, txtPass, btnLogin });

        // Clear the boxes every time the form comes back (after Logout)
        VisibleChanged += (s, e) =>
        {
            if (Visible) { txtUser.Clear(); txtPass.Clear(); txtUser.Focus(); }
        };
    }

    void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUser.Text.Trim() == "" || txtPass.Text.Trim() == "")
        {
            MessageBox.Show("Username and Password cannot be empty.");
            return;
        }

        Hide();                       // hide Login (we do not close it)
        new ChooseForm().Show();      // go to Choose
    }
}