using System;
using Artech.ApplicationContexts;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        ApplicationContext.Current.Profile.FirstName = this.TextBoxFirstName.Text.Trim();
        ApplicationContext.Current.Profile.LastName = this.TextBoxLastName.Text.Trim();
        ApplicationContext.Current.Profile.Age = int.Parse(this.TextBoxAge.Text);
    }
    protected void ButtonClear_Click(object sender, EventArgs e)
    {
        this.TextBoxFirstName.Text = string.Empty;
        this.TextBoxLastName.Text = string.Empty;
        this.TextBoxAge.Text = string.Empty;
    }
    protected void ButtonSyncGet_Click(object sender, EventArgs e)
    {
        this.TextBoxFirstName.Text = ApplicationContext.Current.Profile.FirstName;
        this.TextBoxLastName.Text = ApplicationContext.Current.Profile.LastName;
        this.TextBoxAge.Text = ApplicationContext.Current.Profile.Age.ToString();
    }
    protected void ButtonAsynGet_Click(object sender, EventArgs e)
    {
        GetProfile getProfileDel = () =>
        {
            return ApplicationContext.Current.Profile;
        };
        IAsyncResult asynResult = getProfileDel.BeginInvoke(null, null);
        Profile profile = getProfileDel.EndInvoke(asynResult);
        this.TextBoxFirstName.Text = profile.FirstName;
        this.TextBoxLastName.Text = profile.LastName;
        this.TextBoxAge.Text = profile.Age.ToString();
    }
   
    delegate Profile GetProfile();
}
