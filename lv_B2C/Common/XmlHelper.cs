﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;

namespace lv_Common
{
    /// <summary>
    /// Xml操作帮助类
    /// </summary>
    public static class XmlHelper
    {
        const string VERSION = "1.0"; //默认xml版本
        const string ENCODING = "utf-8";//默认xml编码

        #region Get
        /// <summary>
        /// 获取一个节点的值
        /// </summary>
        /// <param name="strXml">xml格式字符串</param>
        /// <param name="Node">节点名称</param>
        /// <returns>节点值</returns>
        public static string GetXmlNodeVlaue(string strXml, string Node)
        {
            XmlDocument docXml = new XmlDocument();
            docXml.LoadXml(strXml);
            XmlNodeList xn = docXml.GetElementsByTagName(Node);
            return xn.Item(0).InnerText.ToString();
        }

        /// <summary>
        /// 获取一个节点
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="xPath">查询该节点的XPath路径</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static XmlNode GetXmlNode(string fileName, string xPath)
        {
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(fileName);
                XmlNode node = document.SelectSingleNode(xPath);
                return node;
            }
            catch (XmlException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取多个节点
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="xPath">查询多个节点的XPath路径</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static XmlNodeList GetXmlNodeList(string fileName, string xPath)
        {
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(fileName);
                XmlNodeList nodeList = document.SelectNodes(xPath);
                return nodeList;
            }
            catch (XmlException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="xPath">查询该属性节点的XPath路径</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static XmlAttribute GetXmlAttribute(string fileName, string xPath, string name)
        {
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(fileName);
                XmlNode node = document.SelectSingleNode(xPath);
                if (node != null)
                {
                    if (node.Attributes != null && node.Attributes.Count > 0 && node.Attributes[name] != null)
                    {
                        return node.Attributes[name];
                    }
                }
                return null;
            }
            catch (XmlException ex)
            {
                return null;
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// 创建XML文件
        /// </summary>
        /// <param name="fileName">创建文件的完全限定名(包含路径)</param>
        /// <param name="rootNodeName">根节点名称</param>
        /// <param name="encoding">xml文档编码 (默认:utf-8)</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static bool CreateXmlDocument(string fileName, string rootNodeName, string encoding)
        {
            bool success = false;
            try
            {
                XmlDocument document = new XmlDocument();
                XmlDeclaration declaration = document.CreateXmlDeclaration(VERSION, encoding, "yes");
                XmlNode root = document.CreateElement(rootNodeName);
                document.AppendChild(declaration);
                document.AppendChild(root);
                document.Save(fileName);
                success = true;
            }
            catch (XmlException ex)
            {
                success = false;
            }
            return success;
        }
        /// <summary>
        /// 创建XML文件
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="rootNodeName">根节点名称</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static bool CreateXmlDocument(string fileName, string rootNodeName)
        {
            return CreateXmlDocument(fileName, rootNodeName, ENCODING);
        }

        /// <summary>
        /// 创建一个子节点
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="xPath">查询父节点的XPath路径</param>
        /// <param name="xmlNodeName">创建的节点名称</param>
        /// <param name="innerXml">创建的节点内xml文字</param>
        /// <param name="attributes">需要创建的属性字典(为NULL,则不创建属性)</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static bool CreateXmlNode(string fileName, string xPath, string xmlNodeName, string innerXml, Dictionary<string, string> attributes)
        {
            bool success = false;

            XmlDocument document = new XmlDocument();
            try
            {
                //加载文档
                document.Load(fileName);

                XmlNode node = document.SelectSingleNode(xPath);
                if (node != null)
                {
                    XmlElement element = document.CreateElement(xmlNodeName);
                    if (innerXml != null) { element.InnerXml = innerXml; }

                    //添加属性
                    if (attributes != null && attributes.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> attribute in attributes)
                        {
                            if ((!string.IsNullOrEmpty(attribute.Key)) && (!string.IsNullOrEmpty(attribute.Value)))
                            {
                                XmlAttribute attr = document.CreateAttribute(attribute.Key);
                                attr.Value = attribute.Value;

                                element.Attributes.Append(attr);
                            }
                        }
                    }

                    node.AppendChild(element);
                }

                document.Save(fileName);

                success = true;
            }
            catch (XmlException ex)
            {
                success = false;
                throw ex;
            }

            return success;
        }

        /// <summary>
        /// 创建或修改一个子节点
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="xPath">查询父节点的XPath路径</param>
        /// <param name="xmlNodeName">创建的节点名称</param>
        /// <param name="innerXml">创建的节点内xml文字</param>
        /// <param name="attributes">需要创建的属性字典(为NULL,则不创建属性)</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static bool CreateOrUpdateXmlNode(string fileName, string xPath, string xmlNodeName, string innerXml, Dictionary<string, string> attributes)
        {
            bool success = false;
            bool exsit = false;//标示是否已经存在该节点
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(fileName);

                XmlNode node = document.SelectSingleNode(xPath);

                if (node != null)
                {

                    foreach (XmlNode item in node.ChildNodes)
                    {
                        if (item.Name.ToLower() == xmlNodeName.ToLower())
                        {
                            //存在 执行更新
                            if (innerXml != null) { node.InnerXml = innerXml; }
                            //添加属性
                            if (attributes != null && attributes.Count > 0)
                            {
                                foreach (KeyValuePair<string, string> attribute in attributes)
                                {
                                    if ((!string.IsNullOrEmpty(attribute.Key)) && (!string.IsNullOrEmpty(attribute.Value)))
                                    {
                                        if (item.Attributes[attribute.Key] != null)
                                        {
                                            //存在该属性，更新
                                            item.Attributes[attribute.Key].Value = attribute.Value;
                                        }
                                        else
                                        {
                                            //不存在该属性，新增
                                            XmlAttribute nodeAttribute = document.CreateAttribute(attribute.Key);
                                            nodeAttribute.Value = attribute.Value;
                                            item.Attributes.Append(nodeAttribute);
                                        }
                                    }
                                }
                            }
                            exsit = true;
                            break;
                        }
                    }
                    if (!exsit)
                    {
                        //不存在，执行添加
                        //TODO:: success??
                        success = CreateXmlNode(fileName, xPath, xmlNodeName, innerXml, attributes);
                    }
                }

                success = true;
            }
            catch (XmlException ex)
            {
                success = false;
                throw ex;

            }
            return success;
        }
        #endregion

        #region CreateOrUpdate
        /// <summary>
        /// 创建或修改一个属性
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="xPath">查询该属性节点的XPath路径</param>
        /// <param name="name">创建或修改的属性名称</param>
        /// <param name="value">创建或修改的属性值</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static bool CreateOrUpdateAttribute(string fileName, string xPath, string name, string value)
        {
            bool success = false;
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(fileName);
                XmlNode node = document.SelectSingleNode(xPath);

                if (node != null)
                {
                    XmlAttributeCollection attributes = node.Attributes;
                    if (attributes != null)
                    {
                        if (attributes[name] != null)
                        {
                            //存在属性 更新
                            attributes[name].Value = value;
                        }
                        else
                        {
                            //不存在属性 创建
                            XmlAttribute atr = document.CreateAttribute(name);
                            atr.Value = value;
                            node.Attributes.Append(atr);
                        }
                    }
                    else
                    {
                        //不存在属性 创建
                        XmlAttribute atr = document.CreateAttribute(name);
                        atr.Value = value;
                        node.Attributes.Append(atr);
                    }
                }
                document.Save(fileName);
                success = true;
            }
            catch (XmlException ex)
            {
                success = false;
                throw ex;
            }

            return success;
        }

        //创建或更新多个属性
        public static bool CreateOrUpdateAttribute(string fileName, string xPath, Dictionary<string, string> attrs)
        {
            bool success = false;
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(fileName);
                XmlNode node = document.SelectSingleNode(xPath);

                if (node != null)
                {
                    XmlAttributeCollection attributes = node.Attributes;
                    if (attributes != null)
                    {
                        foreach (var attr in attrs)
                        {
                            if (attributes[attr.Key] != null)
                            {
                                //存在属性 更新
                                attributes[attr.Key].Value = attr.Value;
                            }
                            else
                            {
                                //不存在属性 创建
                                XmlAttribute atr = document.CreateAttribute(attr.Key);
                                atr.Value = attr.Value;
                                node.Attributes.Append(atr);
                            }
                        }
                    }
                    else
                    {
                        foreach (var attr in attrs)
                        {
                            XmlAttribute atr = document.CreateAttribute(attr.Key);
                            atr.Value = attr.Value;
                            node.Attributes.Append(atr);
                        }
                    }
                }
                document.Save(fileName);
                success = true;
            }
            catch (XmlException ex)
            {
                success = false;
                throw ex;
            }

            return success;
        } 
        #endregion

        #region Delete
        /// <summary>
        /// 删除一个节点
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="xPath">查询该节点的XPath路径</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static bool DeleteXmlNode(string fileName, string xPath)
        {
            bool success = true;
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(fileName);
                XmlNode node = document.SelectSingleNode(xPath);
                if (node != null)
                {
                    //删除节点
                    node.ParentNode.RemoveChild(node);
                }
                document.Save(fileName);
                success = true;
            }
            catch (XmlException ex)
            {
                success = false;
                throw;
            }
            return success;
        }
        /// <summary>
        /// 批量删除节点
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="xPath">查询节点集合的XPath路径</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static bool BatchDeleteXmlNode(string fileName, string xPath)
        {
            bool success = true;
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(fileName);
                XmlNodeList nodeList = document.SelectNodes(xPath);
                if (nodeList != null && nodeList.Count > 0)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        //删除节点
                        node.ParentNode.RemoveChild(node);
                    }

                }
                document.Save(fileName);
                success = true;
            }
            catch (XmlException ex)
            {
                success = false;
                throw;
            }
            return success;
        }

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="fileName">XML文件的完全限定路径(包含路径)</param>
        /// <param name="xPath">查询该属性节点的XPath路径</param>
        /// <param name="name">属性名称</param>
        /// <returns>成功返回True,失败返回Fasle</returns>
        public static bool DeleteAttribute(string fileName, string xPath, string attributeName)
        {
            bool success = true;
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(fileName);
                XmlNodeList nodeList = document.SelectNodes(xPath);
                if (nodeList != null && nodeList.Count > 0)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        if (node.Attributes != null && node.Attributes.Count > 0 && node.Attributes[attributeName] != null)
                        {
                            //删除该属性
                            node.Attributes.Remove(node.Attributes[attributeName]);
                        }
                    }

                }
                document.Save(fileName);
                success = true;
            }
            catch (XmlException ex)
            {
                success = false;
                throw;
            }
            return success;
        }
        #endregion        

        #region Convert
        public static string ModelToXML(object model)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlElement ModelNode = xmldoc.CreateElement("Model");
            xmldoc.AppendChild(ModelNode);

            if (model != null)
            {
                foreach (PropertyInfo property in model.GetType().GetProperties())
                {
                    XmlElement attribute = xmldoc.CreateElement(property.Name);
                    if (property.GetValue(model, null) != null)
                        attribute.InnerText = property.GetValue(model, null).ToString();
                    else
                        attribute.InnerText = "[Null]";
                    ModelNode.AppendChild(attribute);
                }
            }

            return xmldoc.OuterXml;
        }

        /// <summary>    
        /// XML转化为Model的方法    
        /// </summary>    
        /// <param name="xml">要转化的XML</param>    
        /// <param name="SampleModel">Model的实体示例，New一个出来即可</param>    
        /// <returns></returns>    
        public static object XMLToModel(string xml, object SampleModel)
        {
            if (string.IsNullOrEmpty(xml))
                return SampleModel;
            else
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml);

                XmlNodeList attributes = xmldoc.SelectSingleNode("Model").ChildNodes;
                foreach (XmlNode node in attributes)
                {
                    foreach (PropertyInfo property in SampleModel.GetType().GetProperties())
                    {
                        if (node.Name == property.Name)
                        {
                            if (node.InnerText != "[Null]")
                            {
                                if (property.PropertyType == typeof(System.Guid))
                                    property.SetValue(SampleModel, new Guid(node.InnerText), null);
                                else
                                    property.SetValue(SampleModel, Convert.ChangeType(node.InnerText, property.PropertyType), null);
                            }
                            else
                                property.SetValue(SampleModel, null, null);
                        }
                    }
                }
                return SampleModel;
            }
        }
        #endregion

    }
}
