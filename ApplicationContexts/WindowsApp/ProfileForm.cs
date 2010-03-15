using System;
using Artech.ApplicationContexts;
namespace WindowsApp
{
    public partial class ProfileForm : System.Windows.Forms.Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ApplicationContext.Current.Profile.FirstName = this.textBoxFirstName.Text.Trim();
            ApplicationContext.Current.Profile.LastName = this.textBoxLastName.Text.Trim();
            ApplicationContext.Current.Profile.Age = (int)this.numericUpDownAge.Value;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBoxFirstName.Text = string.Empty;
            this.textBoxLastName.Text = string.Empty;
            this.numericUpDownAge.Value = 0;
        }

        private void buttonSyncGet_Click(object sender, EventArgs e)
        {
            this.textBoxFirstName.Text = ApplicationContext.Current.Profile.FirstName;
            this.textBoxLastName.Text = ApplicationContext.Current.Profile.LastName;
            this.numericUpDownAge.Value = ApplicationContext.Current.Profile.Age;
        }

        private void buttonAsyncGet_Click(object sender, EventArgs e)
        {
            GetProfile getProfileDel = () =>
                {
                    return ApplicationContext.Current.Profile;
                };
            IAsyncResult asynResult = getProfileDel.BeginInvoke(null, null);
            Profile profile = getProfileDel.EndInvoke(asynResult);
            this.textBoxFirstName.Text = profile.FirstName;
            this.textBoxLastName.Text = profile.LastName;
            this.numericUpDownAge.Value = profile.Age;
        }

        delegate Profile GetProfile();       
    }
}
