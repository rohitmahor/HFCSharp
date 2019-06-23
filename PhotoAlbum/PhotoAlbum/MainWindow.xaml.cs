using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace PhotoAlbum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
          
        public MainWindow()
        {
            InitializeComponent();

            //Load XML Document
            XmlDocument xImages = new XmlDocument();
            xImages.Load("C:\\Users\\Rohit.COMPRO\\Desktop\\HFCSharp\\PhotoAlbum\\PhotoAlbum\\Content\\DataSource.xml");
            
            //Load images Listview
            LoadListItems(ref xImages);

            //Lambda function for passing xImage in parameter
            add.Click += (sender, e) => Add_Click_Action(sender, e, ref xImages);
            DeleteButton.Click += (sender1, e1) => DeleteButton_Click_modified(sender1, e1, ref xImages);
        }

        private void LoadListItems(ref XmlDocument xImages)
        {
            //XmlNodeList xImageList = xImages.GetElementsByTagName("Image");
            XmlNodeList xImageList = xImages.ChildNodes.Item(1).ChildNodes;

            List<Images> imageList = new List<Images>();
            if(xImageList.Count > 0)
            {
                foreach (XmlNode img in xImageList)
                {
                    imageList.Add(new Images()
                    {
                        path = img["Path"].InnerText,
                        name = img["Name"].InnerText,
                        width = img["Width"].InnerText,
                        height = img["Height"].InnerText
                    });
                }

                ThumbnailList.ItemsSource = imageList;
                ThumbnailList.SelectedIndex = 0;

                var idx = 0;
                currentImage.Source = new BitmapImage(new Uri(imageList[idx].path, UriKind.RelativeOrAbsolute));

            }
            else
            {
                currentImage.Source = null;
                ThumbnailList.ItemsSource = null;                
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e) { return; }

        private void Add_Click_Action(object sender, RoutedEventArgs e, ref XmlDocument xImages)
        {
            OpenFileDialog opend1 = new OpenFileDialog();
            opend1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            opend1.Multiselect = true;

            //Open dialogBox
            if (opend1.ShowDialog() == true)
            {
                XmlNode root = xImages.DocumentElement;

                for(int i = 0; i < opend1.FileNames.Count(); i++)
                {
                    string imgPath = opend1.FileNames[i].ToString();
                    string imgName = "";
                    for (int j = imgPath.Length - 1; j >= 0; j--)
                    {
                        if (imgPath[j] == '\\')
                        {
                            break;
                        }
                        imgName = imgPath[j] + imgName;
                    }

                    Console.WriteLine("Add Image: " + imgName);

                    //ref image node 
                    var refImageNode = xImages.ChildNodes.Item(1).ChildNodes.Item(ThumbnailList.SelectedIndex);

                    //XmlDocument doc = new XmlDocument();
                    XmlNode node = xImages.CreateNode(XmlNodeType.Element, "Image", null);

                    //create Path node
                    XmlNode nodePath = xImages.CreateElement("Path");
                    //add value for it
                    nodePath.InnerText = imgPath;

                    //create Width node
                    XmlNode nodeWidth = xImages.CreateElement("Width");
                    //add value for it
                    nodeWidth.InnerText = 100.ToString();

                    //create height node
                    XmlNode nodeHeight = xImages.CreateElement("Height");
                    //add value for it
                    nodeHeight.InnerText = 100.ToString();

                    //create Name node
                    XmlNode nodeName = xImages.CreateElement("Name");
                    //add value for it
                    nodeName.InnerText = imgName;

                    //append childs node in Image node
                    node.AppendChild(nodePath);
                    node.AppendChild(nodeWidth);
                    node.AppendChild(nodeHeight);
                    node.AppendChild(nodeName);

                    //xImages.DocumentElement.AppendChild(node);
                    xImages.DocumentElement.InsertAfter(node, refImageNode);
                }

                xImages.Save("C:\\Users\\Rohit.COMPRO\\Desktop\\HFCSharp\\PhotoAlbum\\PhotoAlbum\\Content\\DataSource.xml");

                var idx = ThumbnailList.SelectedIndex;

                //Load Images in Listview
                LoadListItems(ref xImages);

                ThumbnailList.SelectedIndex = idx + opend1.FileNames.Count();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            return;    
        }

        private void DeleteButton_Click_modified(object sender, EventArgs e, ref XmlDocument xImages)
        {
            List<int> selectedItemIndexes = new List<int>();
            int cnt = 0;
            int idx = ThumbnailList.SelectedIndex;
            foreach (object o in ThumbnailList.SelectedItems)
            {
                //var imageNode = xImages.ChildNodes.Item(1).ChildNodes.Item(ThumbnailList.SelectedIndex);
                var imageNode = xImages.ChildNodes.Item(1).ChildNodes.Item(ThumbnailList.Items.IndexOf(o) - cnt);

                if(imageNode != null)
                    xImages.ChildNodes.Item(1).RemoveChild(imageNode);

                cnt++;

            }

            xImages.Save("C:\\Users\\Rohit.COMPRO\\Desktop\\HFCSharp\\PhotoAlbum\\PhotoAlbum\\Content\\DataSource.xml");

            LoadListItems(ref xImages);

            ThumbnailList.SelectedIndex = (idx) % Math.Max(ThumbnailList.Items.Count,1);
            return;
        }


        private void ThumbnailList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var img = ((sender as ListView).SelectedItem as Images);
            if(img != null)
                currentImage.Source = new BitmapImage(new Uri(img.path, UriKind.RelativeOrAbsolute));
            return;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            
            ThumbnailList.SelectedIndex = ThumbnailList.SelectedIndex + 1;
            return;
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            ThumbnailList.SelectedIndex = Math.Max(ThumbnailList.SelectedIndex - 1, 0);
            return;
        }

        private void DisableButton(Button btn, bool flag)
        {

        }
    }

    internal class Images
    {
        public string path { get; set; }

        public string name { get; set; }

        public string width { get; set; }

        public string height { get; set; }

    }
}
