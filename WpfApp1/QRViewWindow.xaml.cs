using InventoryManagement.ViewController;
using Microsoft.Win32;
using RestApi.Client.Dto.Response.Product;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for QRViewWindow.xaml
    /// </summary>
    public partial class QRViewWindow : Window
    {
        private QRViewWindowModel _model;
        public QRViewWindow(ProductDto product)
        {
            _model = new QRViewWindowModel();
            _model.Product = product;

            InitializeComponent();
            SetImage();
        }

        private void SetImage()
        {
            _model.CreateQRImage();

            QRImage.Source = _model.QRImage;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "QR Image";
            dialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            if (dialog.ShowDialog() == true)
            {
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(_model.QRImage));
                using (var stream = dialog.OpenFile())
                {
                    encoder.Save(stream);
                }
            }
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            var vis = new DrawingVisual();
            using (var dc = vis.RenderOpen())
            {
                dc.DrawImage(_model.QRImage, new Rect { Width = _model.QRImage.Width / 5, Height = _model.QRImage.Height / 5 });
            }

            var pdialog = new PrintDialog();
            if (pdialog.ShowDialog() == true)
            {
                pdialog.PrintVisual(vis, "QR Image");
            }
        }
    }
}
