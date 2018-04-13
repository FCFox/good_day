using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using System.IO.Compression;
using System.Threading.Tasks;


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
                string URI = URLText.Text.Trim();
                int lastSplitIndex = URI.LastIndexOf('/');
                string url = URI.Substring(0, lastSplitIndex + 1).Trim();
                string fileName = URI.Substring(lastSplitIndex).Split(new char[] { '.' })[0];

#region Head头
                Uri ur = new Uri(URI);

                
                HttpRequestHeaders headers = client.DefaultRequestHeaders;
                headers.AcceptEncoding.ParseAdd("gzip,deflate");
                headers.AcceptCharset.TryParseAdd("utf-8,gbk,gb2312");
                headers.Accept.TryParseAdd("*/*");
                headers.Add("Referer",ur.Scheme+"://"+ur.Host);
               
#endregion
                var response = await client.GetAsync(URI);
                byte[] contentArray = await DownloadFileAsync(response);
                string charset = Encoding.Default.BodyName;
                string response_charset = response.Content.Headers.ContentType.CharSet;
                if (string.IsNullOrEmpty(response_charset)|| response_charset.ToLower()!= Encoding.Default.BodyName)
                {
                    charset = GetCharset(contentArray);
                }

                string content = FixedContent(charset, contentArray);


                #region 正则表达式
                //匹配正则 图片标题
                 string regTitle = titleText.Text.Trim();

               
                string name = Regex.Match(content, regTitle).Groups[1].ToString(); //只取第一个匹配到的标题作为图片名字
                string regFileName = "<>:\\/|*\"?";
                for (int i = 0; i < regFileName.Length; i++)
                {
                    char ch = regFileName[i];
                    int index = -1;
                    if ((index = name.IndexOf(ch)) != -1)
                    {
                        name = name.Remove(index, 1);
                    }
                }
                //获取总数量

                string countStr = string.Empty;
                if (fixedCountText.Text.Trim() != string.Empty)
                {
                    countStr = fixedCountText.Text.Trim();
                }
                else
                {

                    string regCount = countText.Text.Trim();

                    countStr = Regex.Match(content, regCount).Groups[1].ToString();
                }
               
     
                 //图片
                 string regImage = imageURIText.Text.Trim();
                 string imageURI = Regex.Match(content, regImage).Groups[1].ToString().Trim(new char[] { '"', ' ' });

                 

                 if (name == string.Empty || countStr == string.Empty||imageURI==string.Empty)
                 {
                    ipRichTextBox.Text = string.Format("标题:{0}\n总页数:{1}\n图片URL:{2}\n上面有为空的项，请检查相关正则表达式",name,countStr,imageURI);
                     return;
                 }

                int count = 0;
                int.TryParse(countStr,out count);
                if(count==0)
                {
                    ipRichTextBox.Text = "总页数为0，无法抓取";
                    return;
                }
                //下载图片

                #endregion
                List<string> imageUriList = new List<string>();
                #region 匹配缓存资源
                imageUriList = await GetImageURL(client, response, content, count, url, charset);


                #endregion


                #region 下载资源
                ipRichTextBox.Text = "\n缓存完成，准备下载";
                

                
                 string filePath = savePathTextBox.Text + "\\" + name;
                
                 if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

                for (int i = 0; i < imageUriList.Count; i++)
                {
                    ipRichTextBox.Text = string.Format("\n正在下载:{0}/{1}\n正在下载的资源：{2}", i + 1, imageUriList.Count,imageUriList[i]);
                    string imageUri = imageUriList[i];

                    string suffix = imageUriList[i].Substring(imageUriList[i].LastIndexOf("."));

                    //await webClient.DownloadFileTaskAsync(imageUri, filePath + "\\" + i + suffix);

                    if (imageUri.StartsWith("http"))
                    {
                       
                    }
                    else
                    {
                        imageUri = "http://"+client.DefaultRequestHeaders.Host + imageUri;
                    }
                   
                    byte[] imageArray = null;
                   
                    try
                    {
                        imageArray = await client.GetByteArrayAsync(imageUri);
                        
                        
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            imageArray = await client.GetByteArrayAsync(imageUri);
                        }
                        catch (Exception ex1)
                        {
                            
                        }
                        
                    }
                    
                    if (imageArray == null) continue;

                    File.WriteAllBytes(filePath + "\\" + (i + 1) + "."+suffix, imageArray);
                }
                ipRichTextBox.Text += "\n下载完成:" + name;
               
                imageUriList.Clear();
                
                 #endregion
            }
        }
        async private Task<List<string>> GetImageURL(HttpClient client,HttpResponseMessage response,
            string content,int count,string url,string charset)
        {
            List<string> imageUriList = new List<string>();

            //下一张图片
            string regNextImage = nextImageText.Text.Trim();
            string nextImage = "";
            string imageURI = string.Empty;
            string regImage = imageURIText.Text.Trim();
            for (int num = 1; num <= count; num++)
            {
                //获取图片和下一个图片地址

                nextImage = Regex.Match(content, regNextImage).Groups[1].ToString();
                GroupCollection result = Regex.Match(content, regImage).Groups;
                imageURI = result[1].Value;
                if (num != count && (nextImage == string.Empty || imageURI == string.Empty))
                {
                    ipRichTextBox.Text += "\n error: nextImage:" + nextImage + "\n imageURI" + imageURI;
                    break;
                }
                imageUriList.Add(imageURI);

                if (num < count)
                {
                    try
                    {
                        //得到内容
                        response = await client.GetAsync(url + nextImage);
                        byte[] contentArray = await DownloadFileAsync(response);
                        response.Dispose();

                        content = FixedContent(charset, contentArray);
                    }
                    catch (Exception ex)
                    {
                        //failedURIList.Add(url + resource);
                    }
                }
                ipRichTextBox.Text = string.Format("\n正在缓存数据:{0}/{1}\n当前缓存的资源{2}", num, count,imageURI);


            }

            return imageUriList;
        }
        async private Task<byte[]> DownloadFileAsync(HttpResponseMessage response)
        {
           
            if (!response.IsSuccessStatusCode) return null;

            byte[] contentArray = null;

            if (response.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                using (MemoryStream ms = new MemoryStream())
                {
                    await new GZipStream(stream, CompressionMode.Decompress).CopyToAsync(ms,10240); //固定长度

                    contentArray = ms.ToArray();
                }
                
            }
            else
            {
                contentArray = await response.Content.ReadAsByteArrayAsync();
                
            }
            
            
            return contentArray;
        }
        /// <summary>
        /// 根据编码正确返回内容
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="content"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        private string FixedContent(string charset,byte[] content)
        {
            return Encoding.GetEncoding(charset).GetString(content);
        }

        private string GetCharset(byte[] content)
        {
            string reg = @"charset=([\w]*-?[\d]*)";

            string findCharsetStr = Encoding.Default.GetString(content);
            string charset = Regex.Match(findCharsetStr, reg).Groups[1].ToString();
            return charset;
        }
    }

}
