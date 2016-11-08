using Commons.Collections;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;
using NVelocity.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swift.MVC.ViewEngine
{
    /// <summary>
    /// NVelocity模板工具类 VelocityHelper
    /// </summary>
    public class VelocityHelper
    {
        private VelocityEngine velocity = null;
        private IContext context = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="templatDir">模板文件夹路径</param>
        public VelocityHelper(string templatDir)
        {
            Init(templatDir);
        }

        /// <summary>
        /// 无参数构造函数
        /// </summary>
        public VelocityHelper() { }

        /// <summary>
        /// 初始话NVelocity模块
        /// </summary>
        public void Init(string templatDir)
        {
            //创建VelocityEngine实例对象
            velocity = new VelocityEngine();

            //使用设置初始化VelocityEngine
            ExtendedProperties props = new ExtendedProperties();
            props.AddProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            props.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, HttpContext.Current.Server.MapPath(templatDir));
            //props.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, Path.GetDirectoryName(HttpContext.Current.Request.PhysicalPath));
            props.AddProperty(RuntimeConstants.INPUT_ENCODING, "utf-8");
            props.AddProperty(RuntimeConstants.OUTPUT_ENCODING, "utf-8");

            //模板的缓存设置
            props.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_CACHE, true);              //是否缓存
            props.AddProperty("file.resource.loader.modificationCheckInterval", (Int64)30);    //缓存时间(秒)

            velocity.Init(props);

            //为模板变量赋值
            context = new VelocityContext();
        }

        /// <summary>
        /// 给模板变量赋值
        /// </summary>
        /// <param name="key">模板变量</param>
        /// <param name="value">模板变量值</param>
        public void Put(string key, object value)
        {
            if (context == null)
                context = new VelocityContext();
            context.Put(key, value);
        }

        /// <summary>
        /// 显示模板
        /// </summary>
        /// <param name="templatFileName">模板文件名</param>
        public void Display(string templatFileName)
        {
            //从文件中读取模板
            Template template = velocity.GetTemplate(templatFileName);
            //合并模板
            StringWriter writer = new StringWriter();
            template.Merge(context, writer);
            //输出
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(writer.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据模板生成静态页面
        /// </summary>
        /// <param name="templatFileName"></param>
        /// <param name="htmlpath"></param>
        public void CreateHtml(string templatFileName, string htmlpath)
        {
            //从文件中读取模板
            Template template = velocity.GetTemplate(templatFileName);
            //合并模板
            StringWriter writer = new StringWriter();
            template.Merge(context, writer);
            using (StreamWriter write2 = new StreamWriter(HttpContext.Current.Server.MapPath(htmlpath), false, Encoding.UTF8, 200))
            {
                write2.Write(writer);
                write2.Flush();
                write2.Close();
            }

        }

        /// <summary>
        /// 根据模板生成静态页面
        /// </summary>
        /// <param name="templatFileName"></param>
        /// <param name="htmlpath"></param>
        public void CreateJS(string templatFileName, string htmlpath)
        {
            //从文件中读取模板
            Template template = velocity.GetTemplate(templatFileName);
            //合并模板
            StringWriter writer = new StringWriter();
            template.Merge(context, writer);
            using (StreamWriter write2 = new StreamWriter(HttpContext.Current.Server.MapPath(htmlpath), false, Encoding.UTF8, 200))
            {
                //write2.Write(YZControl.Strings.Html2Js(YZControl.Strings.ZipHtml(writer.ToString())));
                write2.Flush();
                write2.Close();
            }

        }
    }

}
