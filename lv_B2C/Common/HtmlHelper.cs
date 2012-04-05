using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace lv_Common
{
    /// <summary>
    /// HTML辅助类
    /// </summary>
    public static class HtmlHelper
    {
        /// <summary>
        /// Picking up text content from a html document. This function will remove:
        /// 1. <%=%>
        /// 2. script
        /// 3. style
        /// 4. html tags
        /// 6. &nbsp; and others
        /// 7. html comments
        /// After all above removed, \r\n will be replaced by an empty character.
        /// </summary>
        /// <param name="strHtml">string:Waiting for striping html,javascript, style elements</param>
        /// <returns>string: Stripped text</returns>
        public static string ExtractContent(string strHtml)
        {
            //All the regular expression for matching html, javascript, style elements and others.
            string[] aryRegex ={@"<%=[\w\W]*?%>",    @"<script[\w\W]*?</script>",     @"<style[\w\W]*?</style>",   @"<[/]?[\w\W]*?>",   @"([\r\n])[\s]+",
                                  @"&(nbsp|#160);",    @"&(iexcl|#161);",               @"&(cent|#162);",            @"&(pound|#163);",   @"&(copy|#169);",
                                  @"&#(\d+);",         @"-->",                          @"<!--.*\n"};
            //Corresponding replacment to the regular expressions.
            //string[] aryReplacment = { "", "", "", "", "", " ", "\xa1", "\xa2", "\xa3", "\xa9", "", "\r\n", "" };
            string[] aryReplacment = { "", "", "", "", "", " ", "", "", "", "", "", "", "" };
            string strStripped = strHtml;
            //Loop to replacing.
            for (int i = 0; i < aryRegex.Length; i++)
            {
                Regex regex = new Regex(aryRegex[i], RegexOptions.IgnoreCase);
                strStripped = regex.Replace(strStripped, aryReplacment[i]);
            }
            //Replace "\r\n" to an empty character.
            strStripped.Replace("\r\n", "");
            strStripped.Replace("\t", "");
            //Return stripped string.
            return strStripped;
        }

        /// <summary>
        /// 从一段HTML文本中提取出一定字数的纯文本
        /// </summary>
        /// <param name="instr">HTML代码</param>
        /// <param name="firstN">提取从头数多少个字</param>
        /// <param name="withLink">是否要链接里面的字</param>
        /// <returns>纯文本</returns>
        public static string GetFirstNchar(object instr, int firstN, bool withLink)
        {
            string strStripped;
            strStripped = instr.ToString().Clone() as string;
            strStripped = new Regex(@"(?m)<script[^>]*>(\w|\W)*?</script[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(strStripped, "");
            strStripped = new Regex(@"(?m)<style[^>]*>(\w|\W)*?</style[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(strStripped, "");
            strStripped = new Regex(@"(?m)<select[^>]*>(\w|\W)*?</select[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(strStripped, "");
            if (!withLink) strStripped = new Regex(@"(?m)<a[^>]*>(\w|\W)*?</a[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(strStripped, "");
            Regex objReg = new System.Text.RegularExpressions.Regex("(<[^>]+?>)|&nbsp;", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            strStripped = objReg.Replace(strStripped, "");
            Regex objReg2 = new System.Text.RegularExpressions.Regex("(\\s)+", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            strStripped = objReg2.Replace(strStripped, " ");
            return strStripped.Length > firstN ? strStripped.Substring(0, firstN) : strStripped;
        }

        public static string GetFirstNchar(string instr, int firstN)    
        {
            return GetFirstNchar(instr, firstN, false);
        }

        ///   <summary>   
        ///    取出文本中的图片地址   
        ///   </summary>   
        ///   <param    name="HTMLStr">HTMLStr</param>   
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
                    RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }

        public static string BuildA(string content, string href, string target, string id, string className, string title, string rel)
        {
            string html = string.Format(@"<a href='{1}' target='{2}' id='{3}' class='{4}' title='{5}' rel='{6}'>{0}</a>",
                 content, href, target, id, className, title, rel);
            return html;
        }

        public static string BuildA(string content, string href, string target, string id, string className)
        {
            string html = string.Format(@"<a href='{1}' target='{2}' id='{3}' class='{4}'>{0}</a>",
                 content, href, target, id, className);
            return html;
        }

        public static string BuildA(string content, string href, string target, string id)
        {
            string html = string.Format(@"<a href='{1}' target='{2}' id='{3}'>{0}</a>",
                 content, href, target, id);
            return html;
        }

        public static string BuildA(string content, string href, string target)
        {
            string html = string.Format(@"<a href='{1}' target='{2}'>{0}</a>",
                 content, href, target);
            return html;
        }

        public static string BuildA(string content, string href)
        {
            string html = string.Format(@"<a href='{0}'>{1}</a>",
                href, content);
            return html;
        }

        public static string BuildImg(string src, string alt, string width, string height, string className, string id)
        {
            string html = string.Format(@"<img src='{0}' alt='{1}' width='{2}' height='{3}' class='{4}' id='{5}'/>",
                src, alt, width, height, className, id);
            return html;
        }

        public static string BuildImg(string src, string alt, string width, string height)
        {
            string html = string.Format(@"<img src='{0}' alt='{1}' width='{2}' height='{3}'/>",
                src, alt, width, height);
            return html;
        }

        public static string BuildImg(string src, string alt)
        {
            string html = string.Format(@"<img src='{0}' alt='{1}'/>",
                src, alt);
            return html;
        }

        public static string BuildImg(string src)
        {
            string html = string.Format(@"<img src='{0}'/>",
                src);
            return html;
        }

        public static string BuildImgWithA(string href, string src, string width, string height, string alt, string target, string id, string className, string title, string rel)
        {
            string html = string.Format(@"<a href='{0}' target='{3}' id='{4}' class='{5}' title='{6}' rel='{7}'>
                                            <img src='{1}' alt='{2}' width='{8}' height='{9}'/>
                                          </a>",
                                        href, src, alt, target, id, className, title, rel, width, height);
            return html;
        }

        public static string BuildImgWithA(string href, string src, string width, string height, string alt, string target, string id, string className)
        {
            string html = string.Format(@"<a href='{0}' target='{3}' id='{4}' class='{5}'>
                                            <img src='{1}' alt='{2}' width='{6}' height='{7}'/>
                                          </a>",
                                        href, src, alt, target, id, className, width, height);
            return html;
        }

        public static string BuildImgWithA(string href, string src, string width, string height)
        {
            string html = string.Format(@"<a href='{0}'>
                                            <img src='{1}' width='{2}' height='{3}'/>
                                          </a>",
                                        href, src, width, height);
            return html;
        }

        public static string BuildImgWithA(string href, string src)
        {
            string html = string.Format(@"<a href='{0}'><img src='{1}'/></a>", href, src);
            return html;
        }
    }
}

