using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Xml.Linq;

namespace XmlAssignment
{
    public partial class LearnXPath : Form
    {
        /// <summary>
        /// XmlDocument object to load the xml
        /// </summary>
        XmlDocument xDoc = new XmlDocument();

        public LearnXPath()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of Browse XML button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open XML Document";
            openFileDialog1.Filter = "XML File |*.xml";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txtXmlPath.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the click event of Show XML button
        /// and displays the xml to the user on the Win form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_showXML_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtXmlPath.Text))
            {
                try
                { 
                    xDoc.Load(txtXmlPath.Text);
                    webBrowser1.Url = new Uri(xDoc.BaseURI);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + " Please validate the selected file!", "Warning!",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);                    
                }
                try
                {
                    XmlElement root = xDoc.DocumentElement;
                    cmb_xpaths.Text = "--Select xPath--";
                    if (root.HasAttributes)
                    {
                        for (int i = 0; i < root.Attributes.Count; i++)
                        {
                            cmb_xpaths.Items.Add("/" + root.Name + "[@" + root.Attributes[i].Name + "='" + root.Attributes[i].Value + "']");
                        }
                    }
                    cmb_xpaths.Items.Add("/" + root.Name);
                    var childElements = root.ChildNodes;
                    foreach (XmlNode childNode in childElements)
                    {
                        if (((XmlElement)childNode).HasAttributes)
                        {
                            for (int i = 0; i < ((XmlElement)childNode).Attributes.Count; i++)
                                cmb_xpaths.Items.Add("/" + root.Name + "/" + childNode.Name + "[@" + childNode.Attributes[i].Name + "='" + ((XmlElement)childNode).Attributes[i].Value + "']");
                        }
                        if(childNode.HasChildNodes)
                        {
                            for (int i = 0; i < childNode.ChildNodes.Count; i++)
                                cmb_xpaths.Items.Add("/" + root.Name + "/" + childNode.Name + "/" + childNode.ChildNodes[i].Name);
                        }
                    }
                    var allElements = xDoc.SelectNodes("//*");
                    foreach (XmlNode Node in allElements)
                    {
                        string xPath = GetXPath(Node);
                        cmb_xpaths.Items.Add(xPath);
                    }

                    List<object> list = new List<object>();
                    foreach (object obj in cmb_xpaths.Items)
                    {
                        if (!list.Contains(obj))
                        {
                            list.Add(obj);
                        }
                    }
                    cmb_xpaths.Items.Clear();
                    cmb_xpaths.Items.AddRange(list.ToArray());
                    txt_xPath.ReadOnly = false;
                }
                catch(NullReferenceException ex)
                {
                }
            }
            else
            {
                txtXmlPath.Text = "Please select a file!";
            }
            
        }

        /// <summary>
        /// handles the event for change in value of the dropdownlist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_xpaths_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {             
                    XmlNodeList resultList = xDoc.SelectNodes(cmb_xpaths.Text);
                    string nodeList = string.Empty;
                    foreach (XmlNode xNode in resultList)
                    {
                        string temp = FormatXmlString(xNode.OuterXml.Trim());
                        temp = temp.Substring(temp.IndexOf('>') + 1);
                        nodeList += temp;
                    }
                    txt_selectedNode.Text = nodeList.Trim();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An unexpected error occured while querying the xml!" + ex.Message);
            }

        }

        /// <summary>
        /// Formats the xml in a user friendly way.
        /// </summary>
        /// <param name="xml">xml in string format</param>
        /// <returns></returns>
        static public string FormatXmlString(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineChars = Environment.NewLine,
                NewLineHandling = NewLineHandling.Replace,
            };

            using (var ms = new MemoryStream())
            using (var writer = XmlWriter.Create(ms, settings))
            {
                doc.Save(writer);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// returns the xPath for the node selected by the user
        /// </summary>
        /// <param name="node">Node to be displayed</param>
        /// <returns>xPath</returns>
        private string GetXPath(XmlNode node)
        {
            string temp = null;
            XmlNode sibling = default(XmlNode);
            int previousSiblings = 1;
            if (node.Name == "#document")
                return "";

            sibling = node.PreviousSibling;
            while (sibling != null)
            {
                if (sibling.Name == node.Name)
                {
                    previousSiblings += 1;
                }
                sibling = sibling.PreviousSibling;
            }

            temp = node.Name + (previousSiblings > 0 || node.NextSibling != null ? "[" + previousSiblings.ToString() + "]" : "").ToString();

            if (node.ParentNode != null)
            {
                return GetXPath(node.ParentNode) + "/" + temp;
            }

            return temp;
        }

        /// <summary>
        /// Handles the click event for button to show the results 
        /// of xPath user entered in the textbox provided.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_showResult_Click(object sender, EventArgs e)
        {
            try
            {
                XmlNodeList resultList = xDoc.SelectNodes(txt_xPath.Text);
                string nodeList = string.Empty;
                foreach (XmlNode xNode in resultList)
                {
                    string temp = FormatXmlString(xNode.OuterXml.Trim());
                    temp = temp.Substring(temp.IndexOf('>') + 1);
                    nodeList += temp;
                }
                txt_selectedNode.Text = nodeList.Trim();
                if(string.IsNullOrWhiteSpace(txt_selectedNode.Text))
                {
                    txt_selectedNode.Text = "Please Select a valid query or learn from the Combobox above!";
                }
            }
            catch (Exception ex)
            {
                txt_selectedNode.Text = "Please enter valid node!";
            }

        }

        //private static string GetXPathToNode(XmlNode node)
        //{
        //    if (node.NodeType == XmlNodeType.Attribute)
        //    {
        //        // attributes have an OwnerElement, not a ParentNode; also they have
        //        // to be matched by name, not found by position
        //        return String.Format(
        //            "{0}/@{1}",
        //            GetXPathToNode(((XmlAttribute)node).OwnerElement),
        //            node.Name
        //            );
        //    }
        //    if (node.ParentNode == null)
        //    {
        //        // the only node with no parent is the root node, which has no path
        //        return "";
        //    }
        //    //get the index
        //    int iIndex = 1;
        //    XmlNode xnIndex = node;
        //    while (xnIndex.PreviousSibling != null) { iIndex++; xnIndex = xnIndex.PreviousSibling; }
        //    // the path to a node is the path to its parent, plus "/node()[n]", where 
        //    // n is its position among its siblings.
        //    return String.Format(
        //        "{0}/node()[{1}]",
        //        GetXPathToNode(node.ParentNode),
        //        iIndex
        //        );
        //}


    }
}
