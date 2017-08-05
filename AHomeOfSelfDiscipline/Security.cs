using System;
using System.Linq;
using AlumniPlatform.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AlumniPlatform
{
    /// <summary>
    /// 安全检查类
    /// </summary>
    public class Security
    {

        #region 检查数据合法性
        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        static public bool CheckLogin(string account, string password)
        {
            if (account == null || password == null)
            {
                return false;
            }
            if ((Regex.IsMatch(account, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$") || Regex.IsMatch(account, @"^[a-zA-Z0-9]{6,16}$")) && Regex.IsMatch(password, @"^[0-9a-zA-Z]{6,16}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查保存管理员信息是否合法
        /// </summary>
        /// <param name="manager">管理员实例</param>
        /// <returns></returns>
        static public bool CheckSaveAdmin(Manager manager)
        {
            if (manager == null || manager.Name == null || manager.Account == null || manager.Password == null)
            {
                return false;
            }
            else if (manager.Name.Trim().Length < 1 || manager.Name.Trim().Length > 10 || !Regex.IsMatch(manager.Account, "^[a-zA-Z0-9]{6,16}$") || !Regex.IsMatch(manager.Password, "^[a-zA-Z0-9]{6,16}$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 检查要保存用户信息是否合法
        /// </summary>
        /// <param name="grade">年级</param>
        /// <param name="major">专业</param>
        /// <param name="class">班级</param>
        /// <returns></returns>
        static public bool CheckUserInfo(int userGrade, string userMajor, int userClass)
        {

            if (string.IsNullOrWhiteSpace(userMajor))
            {
                return false;
            }
            string[] grades = new string[] { "2000-2015", "2013-2015", "2013-2015", "2013-2015", "2001-2009", "1994-1997", "1995-1996" };
            string[] majors = new string[] { "计算机科学与技术", "计算机科学与技术(教育)", "物联网工程", "信息管理与信息系统", "电子商务", "计算机应用与维修", "农业电气化自动化(计算机应用)" };
            string[] classes = new string[] { "1-9", "1-5", "1-5", "1-5", "1-5", "1-1", "1-1" };
            if (userMajor == "其它")
            {
                return true;
            }
            for (int i = 0; i < majors.Length; i++)
            {
                if (majors[i] == userMajor)
                {
                    if (CheckValue(grades[i], userGrade) && CheckValue(classes[i], userClass))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 检查值是否合法
        /// </summary>
        /// <param name="model">模板</param>
        /// <param name="value">数值</param>
        /// <returns></returns>
        static public bool CheckValue(string model, int value)
        {
            var strs = model.Split('-');
            int start = Convert.ToInt32(strs[0]);
            int end = Convert.ToInt32(strs[1]);
            if (value >= start && value <= end)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查要保存的用户信息是否合法
        /// </summary>
        /// <param name="user">用户实例</param>
        /// <returns></returns>
        static public bool CheckSaveUser(User user)
        {
            if (user == null || user.Account == null || user.Password == null || user.Name == null)
            {
                return false;
            }
            else if (Regex.IsMatch(user.Account, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$") && Regex.IsMatch(user.Password, @"^[0-9a-zA-Z]{6,16}$") && user.Name.Trim().Length > 0 && user.Name.Trim().Length < 11 && CheckUserInfo(user.Grade, user.Major, user.Class))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查用户家庭住址是否合法
        /// </summary>
        /// <param name="path">网站根目录</param>
        /// <param name="address">用户家庭住址</param>
        /// <returns></returns>
        static public bool CheckUserAddress(string path, string address)
        {
            if (Regex.IsMatch(address, @"^[\u4e00-\u9fa5]{2,4}-[\u4e00-\u9fa5]{2,8}-[\u4e00-\u9fa5]{2,10}$"))
            {
                var strs = address.Split('-');
                StreamReader sr = new StreamReader(Path.Combine(path, @"DataFile\Areas.txt"));
                string jsonStr1 = sr.ReadLine();
                string jsonStr2 = sr.ReadLine();
                sr.Close();
                var serializer = new JavaScriptSerializer();
                var provinces = serializer.Deserialize<List<Province>>(jsonStr1);
                var areas = serializer.Deserialize<List<Area>>(jsonStr2);
                var province = provinces.SingleOrDefault(m => m.name == strs[0]);
                if (provinces != null)
                {
                    var city = province.city.SingleOrDefault(m => m.name == strs[1]);
                    var area = areas.SingleOrDefault(m => m.name == strs[2]);
                    if (area != null && city != null && city.id == area.pid)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查用户行业信息是否合法
        /// </summary>
        /// <param name="trade">行业</param>
        /// <returns></returns>
        static public bool CheckUserTrade(string trade)
        {
            var trades = new string[] { "", "信息传输、计算机服务和软件业", "电信和其他信息传输服务业", "计算机服务业", "软件业", "电气机械及器材制造业", "通信设备、计算机及其他电子设备制造业", "其它" };
            if (trades.Contains(trade))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查要保存公告的信息是否合法
        /// </summary>
        /// <param name="notice">公告实例</param>
        /// <returns></returns>
        static public bool CheckSaveNotice(Notice notice)
        {
            if (notice == null || notice.Name == null || notice.Description == null)
            {
                return false;
            }
            if (notice.Name.Trim().Length < 1 || notice.Name.Trim().Length > 40 || notice.Description.Trim().Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
        /// <summary>
        /// 检查重置密码上传信息是否合法
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <param name="code">确认码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        static public bool CheckResetPassword(string email, string code, string newPassword)
        {
            if (Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$") && Regex.IsMatch(code, @"^[0-9a-zA-Z]{32}$") && Regex.IsMatch(newPassword, @"^[0-9a-zA-Z]{6,16}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查发送邮件信息是否合法
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="email">邮箱</param>
        /// <param name="phone">电话</param>
        /// <param name="subject">主题</param>
        /// <param name="message">内容</param>
        /// <returns></returns>
        static public bool CheckSendMail(string name, string email, string phone, string subject, string message)
        {
            if (!string.IsNullOrEmpty(phone) && !Regex.IsMatch(phone, @"^[0-9]{6,11}$"))
            {
                return false;
            }
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message) || name.Trim().Length > 10 || subject.Trim().Length > 50 || message.Trim().Length > 1000)
            {
                return false;
            }
            if (!Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查用户上传图片数量是否超出限制
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        static public bool PictureOverLimit(int id)
        {
            WebAppContext entity = new WebAppContext();
            int sum = entity.Pictures.Count(m => m.UserId == id);
            if (sum >= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查用户上传资源大小是否超出限制
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="fileSzie">上传文件大小</param>
        /// <returns></returns>
        static public bool ResourceOverLimit(int id, int fileSzie)
        {
            WebAppContext entity = new WebAppContext();
            var resources = entity.Resources.Where(m => m.UserId == id);
            int sum = 0;
            if (resources.Count() > 0)
            {
                sum = resources.Sum(m => m.FileSize);
            }
            if (sum + fileSzie > 1073741824)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 清理无用资源

        /// <summary>
        /// 清除多余的Code数据
        /// </summary>
        static public void ClearCodes()
        {
            WebAppContext entity = new WebAppContext();
            var codes = entity.Codes.Where(m => m.UserId == -1).ToList();
            int n = codes.Count();
            if (n > 0)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    if ((DateTime.Now - codes.ElementAt(i).CreateTime).TotalHours > 24)
                    {
                        entity.Codes.Remove(codes.ElementAt(i));//以及
                    }
                }
            }
            codes = entity.Codes.Where(m => m.Class == 0).ToList();
            n = codes.Count();
            if (n > 0)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    if ((DateTime.Now - codes.ElementAt(i).CreateTime).TotalMinutes > 30)
                    {
                        entity.Codes.Remove(codes.ElementAt(i));//以及
                    }
                }
            }
            entity.SaveChanges();
        }

        /// <summary>
        /// 清理网站本地资源本地
        /// </summary>
        /// <param name="path">网站根目录</param>
        /// <returns></returns>
        static public async Task<Boolean> ClearResource(string path)
        {
            return await Task.Run(
                  () =>
                  {
                      WebAppContext entity = new WebAppContext();
                      var allResources = entity.Resources;
                      var allPictures = entity.Pictures;
                      var allUsers = entity.Users;
                      DirectoryInfo folder;
                      string fileName = "";
                      string targetPath = Path.Combine(path, @"AlumniPlatform\Resource");
                      if (Directory.Exists(targetPath))
                      {
                          folder = new DirectoryInfo(targetPath);
                          var files = folder.EnumerateFiles();
                          for (int i = files.Count() - 1; i >= 0; i--)
                          {
                              fileName = files.ElementAt(i).Name;
                              if (allResources.Where(m => m.FilePath.Contains(fileName)).Count() == 0)
                              {
                                  files.ElementAt(i).Delete();
                              }
                          }
                      }
                      else
                      {
                          Directory.CreateDirectory(targetPath);
                      }
                      targetPath = Path.Combine(path, @"AlumniPlatform\Picture");
                      if (Directory.Exists(targetPath))
                      {
                          folder = new DirectoryInfo(targetPath);
                          var files = folder.EnumerateFiles();
                          for (int i = files.Count() - 1; i >= 0; i--)
                          {
                              fileName = files.ElementAt(i).Name;
                              if (allPictures.Where(m => m.FilePath.Contains(fileName)).Count() == 0)
                              {
                                  files.ElementAt(i).Delete();
                              }
                          }
                      }
                      else
                      {
                          Directory.CreateDirectory(targetPath);
                      }
                      targetPath = Path.Combine(path, @"AlumniPlatform\HeadPortrait");
                      if (Directory.Exists(targetPath))
                      {
                          folder = new DirectoryInfo(targetPath);
                          var files = folder.EnumerateFiles();
                          for (int i = files.Count() - 1; i >= 0; i--)
                          {
                              fileName = files.ElementAt(i).Name;
                              if (allUsers.Where(m => m.HeadPortrait == fileName).Count() == 0 && fileName != "Default.jpg")
                              {
                                  files.ElementAt(i).Delete();
                              }
                          }
                      }
                      else
                      {
                          Directory.CreateDirectory(targetPath);
                      }
                      return true;
                  });
        }

        #endregion

        #region 其它
        /// <summary>
        /// 获取指定url的返回结果
        /// </summary>
        /// <param name="url">目标url</param>
        /// <param name="data">post数据</param>
        /// <param name="method">访问方式</param>
        /// <returns></returns>
        static public String RequestUrl(String url, byte[] data, String method = "POST")
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = method;
                request.ContentType = "application/x-www-form-urlencoded";

                if (data != null && data.Length > 0)
                {
                    request.ContentLength = data.Length;
                    Stream newStream = request.GetRequestStream();
                    newStream.Write(data, 0, data.Length);
                    newStream.Close();
                }
                else
                {
                    request.ContentLength = 0;
                }

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                MemoryStream ms = new MemoryStream();
                long ChunkSize = 1024;
                byte[] buffer = new byte[ChunkSize];
                long dataLengthToRead = response.ContentLength;//获取响应数据的总大小
                while (dataLengthToRead > 0)
                {
                    int lengthRead = stream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小
                    ms.Write(buffer, 0, lengthRead);
                    dataLengthToRead = dataLengthToRead - lengthRead;
                }
                stream.Close();
                response.Close();

                string responseText = Encoding.UTF8.GetString(ms.ToArray());
                return responseText;
            }
            catch
            {
                return "";
            }
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
        }

        /// <summary>
        /// 更新轮播图
        /// </summary>
        /// <param name="path">网站根目录</param>
        static public void UpdateCarousel(string path)
        {
            WebAppContext entity = new WebAppContext();
            var pictures = entity.Pictures.Where(m => m.IsChecked && !m.IsForbidden).OrderByDescending(m => m.Id).ToList();
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek, i;
            int n = pictures.Count();
            if (n > 8)
            {
                string[] pics = new string[9];
                beginSeek = seekRand.Next(0, n);
                for (i = 0; i < 9; i++)
                {
                    if (beginSeek + i >= n)
                    {
                        beginSeek = -i;
                    }
                    pics[i] = pictures[beginSeek + i].FilePath.Split('\\').Last();
                }
                //模板一
                Image img = new Bitmap(new Bitmap(Path.Combine(path, @"image\Home\Index\model1.png")), 800, 450);
                Graphics g = Graphics.FromImage(img);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Point[] destPoints1 = {
                        new Point(453, 87),
                         new Point(638, 19),
                         new Point(497, 212)
                    };
                g.DrawImage(new Bitmap(Path.Combine(path, @"AlumniPlatform\Picture\" + pics[0])), destPoints1);
                g.DrawLines(new Pen(Brushes.Gray), new Point[] {
                         new Point(453, 87),
                         new Point(638, 19),
                         new Point(683, 144),
                         new Point(497, 212),
                         new Point(453, 87),
                    });
                Point[] destPoints2 = {
                        new Point(400, 158),
                        new Point(590, 203),
                        new Point(370, 287)
                    };
                g.DrawImage(new Bitmap(Path.Combine(path, @"AlumniPlatform\Picture\" + pics[1])), destPoints2);
                g.DrawLines(new Pen(Brushes.Gray), new Point[] {
                        new Point(400, 158),
                        new Point(590, 203),
                        new Point(559, 332),
                        new Point(370, 287),
                        new Point(400, 158),
                    });
                g.FillRectangle(Brushes.Gray, 525, 279, 201, 135);
                g.DrawImage(new Bitmap(Path.Combine(path, @"AlumniPlatform\Picture\" + pics[2])), 526, 280, 199, 133);
                img.Save(Path.Combine(path, @"image\Home\Index\bg1.png"));
                img.Dispose();
                g.Dispose();
                //模板二
                img = new Bitmap(new Bitmap(Path.Combine(path, @"image\Home\Index\model2.png")), 800, 450);
                g = Graphics.FromImage(img);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Point[] destPoints3 = {
                        new Point(420, 114),
                         new Point(591, 22),
                         new Point(482, 232)
                    };
                g.DrawImage(new Bitmap(Path.Combine(path, @"AlumniPlatform\Picture\" + pics[3])), destPoints3);
                g.DrawLines(new Pen(Brushes.Gray), new Point[] {
                         new Point(420, 114),
                         new Point(591, 22),
                         new Point(652, 140),
                         new Point(482, 232),
                         new Point(420, 114),
                    });
                Point[] destPoints4 = {
                        new Point(383, 253),
                        new Point(554, 161),
                        new Point(445, 371)
                    };
                g.DrawImage(new Bitmap(Path.Combine(path, @"AlumniPlatform\Picture\" + pics[4])), destPoints4);
                g.DrawLines(new Pen(Brushes.Gray), new Point[] {
                        new Point(383, 253),
                        new Point(554, 161),
                        new Point(618, 277),
                        new Point(445, 371),
                        new Point(383, 253),
                    });
                Point[] destPoints5 = {
                        new Point(519, 298),
                        new Point(690, 206),
                        new Point(581, 416)
                    };
                g.DrawImage(new Bitmap(Path.Combine(path, @"AlumniPlatform\Picture\" + pics[5])), destPoints5);
                g.DrawLines(new Pen(Brushes.Gray), new Point[] {
                        new Point(519, 298),
                        new Point(690, 206),
                          new Point(751, 323),
                        new Point(581, 416),
                         new Point(519, 298),
                    });
                img.Save(Path.Combine(path, @"image\Home\Index\bg2.png"));
                img.Dispose();
                g.Dispose();
                
                //模板三
                img = new Bitmap(new Bitmap(Path.Combine(path, @"image\Home\Index\model3.png")), 800, 450);
                g = Graphics.FromImage(img);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.Gray, 401, 44, 202, 138);
                g.DrawImage(new Bitmap(Path.Combine(path, @"AlumniPlatform\Picture\" + pics[6])), 402, 45, 200, 136);
                g.FillRectangle(Brushes.Gray, 515, 157, 202, 138);
                g.DrawImage(new Bitmap(Path.Combine(path, @"AlumniPlatform\Picture\" + pics[7])), 516, 158, 200, 136);
                g.FillRectangle(Brushes.Gray, 401, 268, 202, 138);
                g.DrawImage(new Bitmap(Path.Combine(path, @"AlumniPlatform\Picture\" + pics[8])), 402, 269, 200, 136);
                
                img.Save(Path.Combine(path, @"image\Home\Index\bg3.png"));
                img.Dispose();
                g.Dispose();
            }
            else
            {
                for (i = 1; i < 4; i++)
                {
                    var file = Path.Combine(path, @"image\Home\Index\init" + i.ToString() + ".png");
                    if (File.Exists(file))
                    {
                        File.Copy(file, Path.Combine(path, @"image\Home\Index\bg" + i.ToString() + ".png"), true);
                    }
                }
            }
        }

        /// <summary>
        /// 自定义前台显示信息
        /// </summary>
        /// <param name="title">主题</param>
        /// <param name="content">内容</param>
        /// <param name="func">附加执行语句</param>
        /// <returns>组合成的页面</returns>
        static public string SweetAlert(string title, string content, string func = null)
        {
            if (func == null)
            {
                return "<html><head><link href='/Content/Shared/sweetalert.css' rel='stylesheet'/><script src='/scripts/sweetalert-dev.js'></script></head><body><script>try{swal({title:'" + title + "', text:'" + content + "'},function(){location.href=document.referrer;});}catch(e){alert('" + title + ":" + content + "');location.href=document.referrer;}</script></body></html>";
            }
            else
            {
                return "<html><head><link href='/Content/Shared/sweetalert.css' rel='stylesheet'/><script src='/scripts/sweetalert-dev.js'></script></head><body><script>try{swal({title:'" + title + "', text:'" + content + "'},function(){" + func + "});}catch(e){alert('" + title + ":" + content + "');" + func + "}</script></body></html>";
            }
        }
        #endregion

    }
}