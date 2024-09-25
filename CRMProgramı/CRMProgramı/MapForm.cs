using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMProgramı
{
    public partial class MapForm : MetroFramework.Forms.MetroForm
    {
        private GMapControl map;
        private GMapOverlay markersOverlay;
        private RichTextBox richTextBox1;
        private string apiKey = "AIzaSyCgu1S2qM0pN5o7xpOr5q36YWBxUy4smZA"; // Buraya geçerli bir API anahtarı ekleyin

        public string SelectedLocation { get; private set; }

        public MapForm(RichTextBox rtb)
        {
            InitializeComponent();
            richTextBox1 = rtb;
            map = new GMapControl();
            markersOverlay = new GMapOverlay("markers");
            map.Overlays.Add(markersOverlay);
            map.Dock = DockStyle.Fill;
            map.MouseDoubleClick += Map_MouseDoubleClick;
            this.Controls.Add(map);
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(41.0082, 28.9784); // Harita başlangıç noktası ayarlama İstanbul, Türkiye
            map.MaxZoom = 18;
            map.Zoom = 10;
            map.MouseWheelZoomEnabled = true;
            map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
        }

        private async void Map_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var point = map.FromLocalToLatLng(e.X, e.Y);
            var addresses = await GetAddress(point);

            if (addresses != null && addresses.Count > 0)
            {
                var addressMessage = $"Seçilen konum:\n{addresses[0]}\nBu konumu onaylıyor musunuz?";
                var result = MessageBox.Show(addressMessage, "Konum Onayı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    markersOverlay.Markers.Clear();
                    var marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                    markersOverlay.Markers.Add(marker);
                    SelectedLocation = addresses[0];
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    richTextBox1.Clear();
                    string joinedAddresses = string.Join("\n----------------------\n", addresses);
                    richTextBox1.AppendText("Adres:\n" + joinedAddresses);
                }
                else
                {
                    richTextBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Adres bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<string>> GetAddress(PointLatLng point)
        {
            string lat = point.Lat.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string lng = point.Lng.ToString(System.Globalization.CultureInfo.InvariantCulture);

            string url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={lat},{lng}&key={apiKey}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    richTextBox1.AppendText($"API Response: {responseBody}\n");

                    var json = JObject.Parse(responseBody);
                    var status = json["status"]?.ToString();

                    richTextBox1.AppendText($"API Response Status: {status}\n");

                    if (status == "OK")
                    {
                        var results = json["results"];
                        if (results != null && results.HasValues)
                        {
                            List<string> addresses = new List<string>();
                            foreach (var result in results)
                            {
                                var address = result["formatted_address"]?.ToString();
                                if (address != null)
                                {
                                    addresses.Add(address);
                                }
                            }
                            return addresses;
                        }
                    }
                    else
                    {
                        var errorMessage = json["error_message"]?.ToString();
                        richTextBox1.AppendText($"Error: {errorMessage}\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"API isteği sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }
    }
}
