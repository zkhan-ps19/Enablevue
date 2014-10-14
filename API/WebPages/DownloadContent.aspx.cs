using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using BLL;
using Model;
using Novacode;

namespace RESTfulAPI.WebPages
{
    public partial class DownloadContent : System.Web.UI.Page
    {
        string strFilePath = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Session Validation
            UserInfo objUser = (UserInfo)Session["loginUser"];

            if (objUser == null)
            {
                Response.Redirect("~/WebPages/Login.aspx", true);
            }
            #endregion

            strFilePath = Request.PhysicalApplicationPath + "download\\";

            //Response.Write(strFilePath);

            // reference to the executing assembly - will 
            // be used to obtain embedded resources per 
            // the original example.  
            Assembly gAssembly;

            // reference to the working document.
            DocX gDocument;

            // set a global reference to the executing assembly
            gAssembly = Assembly.GetExecutingAssembly();

            try
            {

                if (File.Exists(strFilePath + "Template.docx"))
                {
                    // set a global reference to the template;
                    // note the template is just a document and
                    // not actually a template
                    gDocument = DocX.Load(strFilePath + "Template.docx");

                    // once we have the document, we will populate it
                    // in code, this will create the document we want
                    // to send out or print.
                    gDocument =
                        CreateInvoiceFromTemplate(DocX.Load(strFilePath + "Template.docx"));

                    // Save the current working document so as not 
                    // to overwrite the template document that we 
                    // will want to reuse many times
                    strFilePath += objUser.Userid + "DownloadContent.docx";

                    gDocument.SaveAs(strFilePath);
                }
                else
                {
                    // Create a store a global reference to the 
                    // template 'Template.docx'.
                    gDocument = CreateTemplate();

                    // Save the template 'Template.docx'.               
                    gDocument.Save();

                    // I will be lazy and just call the 
                    // same code again now that we have
                    // a working template saved and so 
                    // the user does not have to restart
                    // the appication is the template was
                    // originally missing

                    // set a global reference to the template
                    // just created
                    gDocument = DocX.Load(strFilePath + "Template.docx");

                    // populate the document with data so we 
                    // can print it or email it off to a 
                    // recipient
                    gDocument =
                        CreateInvoiceFromTemplate(DocX.Load(strFilePath + "Template.docx"));

                    // Save the current working document so as not 
                    // to overwrite the template document that we 
                    // will want to reuse many times
                    strFilePath += objUser.Userid + "DownloadContent.docx";

                    gDocument.SaveAs(strFilePath);
                }

                fileDownload("RequestContent.docx", strFilePath);
            }
            catch (Exception exe)
            {
                Response.Write(exe.Message); ;
            }
        }

        /// <summary>
        /// Take the document template and populate it with 
        /// variable data to ready it for one specific 
        /// billing target
        /// 
        /// This addresses putting custom data into various
        /// regions of the document, demonstrating how to 
        /// fully populate the template.  Examine each 
        /// defined region to see how to put in text, images, 
        /// and tabular data.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        private DocX CreateInvoiceFromTemplate(DocX template)
        {
            IList<ContentInfo> lstContInfo = Admin.Content.SelectAllWhereCustom("ContentRequestId =" + Request.QueryString["rId"], "ContentId desc");

            if (lstContInfo.Count > 0)
            {
                template.InsertParagraph("Author: " + lstContInfo[0].AuthorFullname);

                template.InsertParagraph();

                template.InsertParagraph("Title: " + lstContInfo[0].Title);

                template.InsertParagraph();

                template.InsertParagraph("Content: " + lstContInfo[0].Contentdetail);

                template.InsertParagraph();

                template.InsertParagraph("Source: " + lstContInfo[0].Source);

                template.InsertParagraph();

                template.InsertParagraph("Category: " + lstContInfo[0].Category);

                template.InsertParagraph();

            }

            return template;

        }

        /// <summary>
        /// Create a template 
        /// 
        /// This method is called whenever the template does not
        /// exist.  The purpose of the method is to create the 
        /// template so that it might be used as the basis for 
        /// creating data specific versions of the invoice
        /// document
        /// 
        /// In general, the template defines locations and 
        /// custom properties that will be used by the process
        /// used to populate the document with actual data.
        /// 
        /// In that process, the code will find each specific 
        /// location and property and replace the default 
        /// text assigned here with actual information
        /// </summary>
        /// <returns></returns>
        private DocX CreateTemplate()
        {
            // Create a new document with the canned 
            // document title.  Note this is really just 
            // a document and not an actual template
            return DocX.Create("Template.docx");
        }

        private void fileDownload(string fileName, string fileUrl)
        {
            Page.Response.Clear();

            bool success = ResponseFile(Request, Response, fileName, fileUrl, 1024000);

            if (!success)
            {
                Response.Write("Downloading Error!" + fileUrl);
            }

            Page.Response.End();
            Page.Response.Flush();
        }

        public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
        {
            try
            {
                FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(myFile);
                try
                {
                    _Response.AddHeader("Accept-Ranges", "bytes");
                    _Response.Buffer = false;
                    long fileLength = myFile.Length;
                    long startBytes = 0;

                    int pack = 10240;
                    //10K bytes
                    int sleep = Convert.ToInt32(Math.Floor(Convert.ToDouble(1000 * pack / _speed))) + 1;
                    if (_Request.Headers["Range"] != null)
                    {
                        _Response.StatusCode = 206;
                        string[] range = _Request.Headers["Range"].Split(new char[] {
						'=',
						'-'
					});
                        startBytes = Convert.ToInt64(range[1]);
                    }
                    _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                    if (startBytes != 0)
                    {
                        _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                    }
                    _Response.AddHeader("Connection", "Keep-Alive");
                    _Response.ContentType = "application/octet-stream";

                    string userAgent = _Request.Headers.Get("User-Agent");
                    if ((userAgent.Contains("MSIE 7.0")))
                    {
                        _fileName = _fileName.Replace(" ", "%20");
                    }

                    _Response.AddHeader("Content-Disposition", "attachment;filename=\"" + _fileName + "\"");

                    br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                    int maxCount = Convert.ToInt32(Math.Floor(Convert.ToDouble((fileLength - startBytes) / pack))) + 1;

                    for (int i = 0; i <= maxCount - 1; i++)
                    {
                        if (_Response.IsClientConnected)
                        {
                            _Response.BinaryWrite(br.ReadBytes(pack));
                            System.Threading.Thread.Sleep(sleep);
                        }
                        else
                        {
                            i = maxCount;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    br.Close();
                    myFile.Close();
                }
            }
            catch
            {
                //Return e.Message
                return false;
            }
            return true;
        }

    }
}