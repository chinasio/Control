using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using FreeTextBoxControls;
namespace Maticsoft.Web.Admin.Product
{

    public partial class Add : System.Web.UI.Page
    {
        string ProductImageFolder = "..\\..\\ProductImages\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtDescn.AutoConfigure = AutoConfigure.EnableAll;
                this.txtDescn.HelperFilesPath = "HelperScripts";
                //this.FreeTextBox1.ImageGalleryPath="images";
                string UpNewsImageFolder = LTP.Common.ConfigHelper.GetConfigString("UpNewsImageFolder");
                this.txtDescn.ImageGalleryPath = UpNewsImageFolder;

                ProductImageFolder = "..\\..\\" + LTP.Common.ConfigHelper.GetConfigString("ProductImageFolder") + "\\";

                //��������˵�
                BiudCategory();
                if (dropCategory.Items.Count > 0)
                {
                    BiudBrand(dropCategory.Items[0].Value);
                }
            }
        }
        private void BiudBrand(string CategoryId)
        {
            Maticsoft.BLL.Products.Brand bll = new Maticsoft.BLL.Products.Brand();
            DataSet ds = bll.GetlistByCategoryId(CategoryId);
            this.dropBrand.DataSource = ds.Tables[0].DefaultView;
            this.dropBrand.DataTextField = "Name";
            this.dropBrand.DataValueField = "BrandId";
            this.dropBrand.DataBind();
        }
        private void BiudCategory()
        {
            Maticsoft.BLL.Products.Category bll = new Maticsoft.BLL.Products.Category();
            DataSet ds = bll.GetAllList();
            this.dropCategory.DataSource = ds.Tables[0].DefaultView;
            this.dropCategory.DataTextField = "Name";
            this.dropCategory.DataValueField = "CategoryId";
            this.dropCategory.DataBind();
        }


        protected void dropCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CategoryId = dropCategory.SelectedValue;
            BiudBrand(CategoryId);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.Products.Product bll = new Maticsoft.BLL.Products.Product();

            string ProductId = this.txtProductId.Text;
            string BrandId = this.dropBrand.SelectedValue;
            string CategoryId = this.dropCategory.SelectedValue;
            string Name = this.txtName.Text;
            string Descn = this.txtDescn.Text;
            string Price = this.txtPrice.Text;
            string vipPrice = this.txtvipPrice.Text;

            if (bll.Exists(ProductId))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "����Ѿ����ڣ�";
                return;
            }

            Maticsoft.Model.Product model = new Maticsoft.Model.Product();
            model.ProductId = ProductId;
            model.BrandId = BrandId;
            model.CategoryId = CategoryId;
            model.Name = Name;
            model.Descn = Descn;
            if (Price != "")
            {
                model.Price = decimal.Parse(Price);
            }
            if (vipPrice != "")
            {
                model.VipPrice = decimal.Parse(vipPrice);
            }
            if (radbtn_Cheap.Checked)
            {
                model.Cheapness = 1;
            }


            #region �ϴ�����ͼ�ļ�

            //if (this.FileUpSmall.PostedFile != null)
            //{
            //    string strErr = "";
            //    int size = this.FileUpSmall.PostedFile.ContentLength;//��С
            //    if (size >1)
            //    {
            //        if (size > 1024000)
            //        {
            //            strErr += "�Բ����ļ���С���ܴ���1M��\\n";
            //        }

            //        if (strErr != "")
            //        {
            //            LTP.Common.MessageBox.Show(this, strErr);
            //            return;
            //        }

            //        string UploadFileType1 = this.FileUpSmall.PostedFile.ContentType;
            //        string UploadFilePath1 = this.FileUpSmall.PostedFile.FileName;
            //        int start1 = UploadFilePath1.LastIndexOf("\\");

            //        string filename1 = UploadFilePath1.Substring(start1 + 1);
            //        filename1 = DateTime.Now.ToString("yyyyMMddHHmmss") + "Small" + filename1;

            //        model.ImageSmall = filename1;

            //        Stream StreamObject1 = this.FileUpSmall.PostedFile.InputStream;//��������������
            //        switch (UploadFileType1)
            //        {
            //            case "image/gif":
            //            case "image/bmp":
            //            case "image/pjpeg":
            //                {
            //                    System.Drawing.Image myImage = System.Drawing.Image.FromStream(StreamObject1);
            //                    int w = myImage.Width;
            //                    int h = myImage.Height;

            //                }
            //                break;
            //            case "application/x-shockwave-flash":
            //                break;
            //            case "video/x-ms-wmv":
            //            case "video/mpeg":
            //            case "video/x-ms-asf":
            //            case "video/avi":
            //            case "audio/mpeg":
            //            case "audio/mid":
            //            case "audio/wav":
            //            case "audio/x-ms-wma":
            //                break;
            //            default:
            //                strErr += "�Բ��𣬲�������ļ���ʽ�ϴ���\\n";
            //                break;
            //        }


            //        string path1 = ProductImageFolder + filename1;
            //        path1 = Server.MapPath(path1);
            //        try
            //        {
            //            this.FileUpSmall.PostedFile.SaveAs(path1); //�������ע��UploadFileĿ¼�ķ���Ȩ��
            //        }
            //        catch (System.Exception ex)
            //        {
            //            Response.Write("��ȷ��" + ProductImageFolder + "Ŀ¼����д��Ȩ�ޡ�" + ex.Message);
            //            return;
            //        }
            //    }

            //}



            #endregion


            #region �ϴ�ͼƬ�ļ�

            if (this.FileUp.PostedFile != null)
            {
                string strErr = "";
                int size1 = this.FileUp.PostedFile.ContentLength;//��С
                if (size1 > 1)
                {
                    if (size1 > 1024000)
                    {
                        strErr += "�Բ����ļ���С���ܴ���1M��\\n";
                    }

                    if (strErr != "")
                    {
                        LTP.Common.MessageBox.Show(this, strErr);
                        return;
                    }

                    string UploadFileType = this.FileUp.PostedFile.ContentType;
                    string UploadFilePath = this.FileUp.PostedFile.FileName;
                    int start = UploadFilePath.LastIndexOf("\\");

                    string filename = UploadFilePath.Substring(start + 1);
                    filename = DateTime.Now.ToString("yyyyMMddHHmmss") + filename;

                    model.Image = filename;

                    Stream StreamObject = this.FileUp.PostedFile.InputStream;//��������������
                    switch (UploadFileType)
                    {
                        case "image/gif":
                        case "image/bmp":
                        case "image/pjpeg":
                            {
                                System.Drawing.Image myImage = System.Drawing.Image.FromStream(StreamObject);
                                int w = myImage.Width;
                                int h = myImage.Height;


                            }
                            break;
                        case "application/x-shockwave-flash":
                            break;
                        case "video/x-ms-wmv":
                        case "video/mpeg":
                        case "video/x-ms-asf":
                        case "video/avi":
                        case "audio/mpeg":
                        case "audio/mid":
                        case "audio/wav":
                        case "audio/x-ms-wma":
                            break;
                        default:
                            strErr += "�Բ��𣬲�������ļ���ʽ�ϴ���\\n";
                            break;
                    }

                    if (strErr != "")
                    {
                        LTP.Common.MessageBox.Show(this, strErr);
                        return;
                    }

                    string path = ProductImageFolder + filename;
                    path = Server.MapPath(path);
                    try
                    {
                        this.FileUp.PostedFile.SaveAs(path); //�������ע��UploadFileĿ¼�ķ���Ȩ��
                    }
                    catch //(System.Exception ex)
                    {
                        Response.Write("��ȷ��" + ProductImageFolder + "Ŀ¼����д��Ȩ�ޡ�");
                        return;
                    }
                }
            }            
            #endregion
            bll.Add(model);
            if (chkAddContinue.Checked)
            {
                Response.Redirect("Add.aspx");
            }
            else
            {
                Response.Redirect("index.aspx");
            }


        }
    }
}
