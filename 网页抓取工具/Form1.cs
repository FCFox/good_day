using System;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace 网页抓取工具
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void SavePathBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                savePathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
           
        }
        

        async private void CatchBtn_Click(object sender, EventArgs e)
        {
           
            using (var client = new HttpClient())
            {

                #region 正则表达式

                
                string url = URLText.Text.Trim();
                string resource = resText.Text.Trim();
                
                var responseString = await client.GetByteArrayAsync(url+resource);

                string content = Encoding.GetEncoding(Encoding.UTF8.BodyName).GetString(responseString);//得到内容
                ipRichTextBox.Text = content;
                //匹配正则 图片标题
                string regTitle = titleText.Text.Trim();
               
                string name = Regex.Match(content, regTitle).Groups[1].ToString(); //只取第一个匹配到的标题作为图片名字
                
                //获取总数量
                string regCount = countText.Text.Trim();
              
                string countStr = Regex.Match(content, regCount).Groups[1].ToString();
                int count = int.Parse(countStr);

                //图片
                string regImage = imageURIText.Text.Trim();
                string imageURI = Regex.Match(content, regImage).Groups[1].ToString().Trim(new char[] { '"', ' ' });

                //下一张图片
                string regNextImage = nextImageText.Text.Trim();
                string nextImage = Regex.Match(content, regNextImage).Groups[1].ToString();
                
                if (name == string.Empty || countStr == string.Empty||resource==string.Empty||imageURI==string.Empty)
                {
                    ipRichTextBox.Text = "文件名:" + name + "\n" + "总页数:" + countStr + "\n下一张图片：" + resource + "\n图片：" + imageURI;
                    return;
                }
                //下载图片

                #endregion

                #region 匹配缓存资源


                List<string> imageUriList = new List<string>();


                int x = 1;
                for (int num = 1; num <=count; num++)
                {
                    //获取图片和下一个图片地址

                    nextImage = Regex.Match(content, regNextImage).Groups[1].ToString();
                    imageURI = Regex.Match(content, regImage).Groups[1].ToString().Trim(new char[] { '"', ' ' });

                    if (num!=count&&(nextImage == string.Empty || imageURI == string.Empty))
                    {
                        ipRichTextBox.Text += "\n error: nextImage:" + nextImage + "imageURI" + imageURI;
                        continue;
                    }
                    imageUriList.Add(imageURI);

                    if (num < count)
                    {
                        try
                        {
                            responseString = await client.GetByteArrayAsync(url + nextImage);

                            content = Encoding.GetEncoding(encodeText.Text.Trim()).GetString(responseString);//得到内容

                        }
                        catch (Exception ex)
                        {
                            //failedURIList.Add(url + resource);
                        }
                    }
                    ipRichTextBox.Text = string.Format("正在缓存数据:{0}/{1}",num,count);

               
                }

                #endregion


                #region 下载资源
                ipRichTextBox.Text = "缓存完成，准备下载";
                WebClient webClient = new WebClient();
                string filePath = savePathTextBox.Text + "\\" + name;
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

               
                for (int i = 0; i <imageUriList.Count; i++)
                {
                    string imageUri = imageUriList[i];
                    
                    await webClient.DownloadFileTaskAsync(imageUri, filePath + "\\" + (i+1)
                        + imageUri.Substring(imageUri.LastIndexOf(".")));

                    ipRichTextBox.Text =string.Format("正在下载:{0}/{1}", i+1 ,imageUriList.Count) ;
                }
                webClient.Dispose();
                imageUriList.Clear();
                ipRichTextBox.Text = "下载完成";

                #endregion
            }
        }

        

   
    }

}
