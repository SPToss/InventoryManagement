using Newtonsoft.Json;
using QRCoder;
using RestApi.Client.Dto.Response.Product;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace InventoryManagement.ViewController
{
    public class QRViewWindowModel
    {
        public ProductDto Product { get; set; }
        public BitmapImage QRImage { get; set; }

        public void CreateQRImage()
        {
            var json = JsonConvert.SerializeObject(Product);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            var qrData = qrGenerator.CreateQrCode(json, QRCodeGenerator.ECCLevel.L);

            QRCode qrCode = new QRCode(qrData);
            


            using (MemoryStream memory = new MemoryStream())
            {
                var bitmap = qrCode.GetGraphic(16);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawRectangle(new Pen(Brushes.White, 25), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                }
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                QRImage = bitmapimage;
            }
        }
    }
}