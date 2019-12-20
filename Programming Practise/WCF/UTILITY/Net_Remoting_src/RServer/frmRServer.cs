using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections.Generic;
using System.IO;

using TDSRenderEngineInterface;
using System.Globalization;
using System.Data.SqlClient;
using RServer;
using System.Threading;
using System.IO.Compression;
//using System.Threading.Tasks;
//using ICSharpCode.SharpZipLib.Zip;

namespace RemotableObjects
{
    public class frmRServer : System.Windows.Forms.Form, IObserver
    {
        private MyRemotableObject remotableObject;
        private System.ComponentModel.Container components = null;

        public frmRServer()
        {
            this.Name = "frmRServer";
            this.Text = "RemoteServer";
            remotableObject = new MyRemotableObject();

            //************************************* TCP *************************************//
            // using TCP protocol
            TcpChannel channel = new TcpChannel(8080);
            ChannelServices.RegisterChannel(channel);
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyRemotableObject),",WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyRemotableObject), "HelloWorld", WellKnownObjectMode.Singleton);
            //************************************* TCP *************************************//
            RemotableObjects.Cache.Attach(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                if (components != null)
                    components.Dispose();
            base.Dispose(disposing);
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new frmRServer());
        }

        #region IObserver Members

        #endregion

        #region Drape

        public static int fabSize { get; set; }

        //SemaphoreSlim maxThread = new SemaphoreSlim(3);
        public void ContentDrape(List<ContentDrapInput> _drapinput)
        {
            try
            {
                Thread subMain = new Thread(() => { _ContentDrape(_drapinput); });
                subMain.Start();

                //subMain.Join();    
                // File.AppendAllText("D:/test.txt","Hi ");
                //ThreadPool.SetMaxThreads(3, 3);
                //maxThread.Wait();
                //Task.Factory.StartNew(() =>
                //{
                //    _ContentDrape(_drapinput);
                //}
                //, TaskCreationOptions.LongRunning)
                //.ContinueWith((task) => maxThread.Release());

                //fabSize = 100;
                //foreach (var drapinput in _drapinput)
                //{
                //    DrappedFabricFilter drappedFabricFilter = drapinput.DrappedFabricFilter;
                //    byte[] drapeImage = drapinput.DrapeImage;
                //    string imageWritePath = drapinput.ImageWritePath;
                //    EditableDatabaseDetail databasedetails = drapinput.Databasedetails;
                //    Color clr;
                //    DrapeDetail details;
                //    // Default Drape Color White is selected
                //    if (drappedFabricFilter != null && (drappedFabricFilter.FabricSwatchId != 0 || drappedFabricFilter.DrapeColor != null))
                //    {
                //        var imageDrapper = new ImageDrapper();
                //        var uImage = GetUnCompressedDataPath(drapeImage);
                //        GC.Collect();
                //        GC.WaitForPendingFinalizers();
                //        GC.Collect();
                //        imageDrapper = new ImageDrapper();

                //        byte[] mainImage = null;
                //        try
                //        {
                //            details = new DrapeDetail();
                //            var m_strImageName = string.Empty;

                //            if (drappedFabricFilter.FabricSwatchId != 0)
                //                m_strImageName = drappedFabricFilter.FabricSwatchId + ".png";
                //            else
                //                m_strImageName = "WhiteDrapped" + ".png";

                //            mainImage = GetImageData_New(databasedetails, new FabricSwatchFilter
                //            {
                //                FabricSwatchId = drappedFabricFilter.FabricSwatchId,
                //                ImageType = ImageEnum.None
                //            });

                //            details.m_bHorFlip = details.m_bVertFlip = details.m_nXWrap = details.m_nYWrap = 0;
                //            details.m_nRotateAgle = 0;
                //            details.m_nFabSize = fabSize;

                //            clr = HexToRgb(drappedFabricFilter.DrapeColor, false);
                //            details.m_color = new byte[3];
                //            details.m_color[0] = clr.R;
                //            details.m_color[1] = clr.G;
                //            details.m_color[2] = clr.B;
                //            if (drappedFabricFilter.DrapeColor != "FFFFFF")
                //                m_strImageName = drappedFabricFilter.ProductConfigurationId + drappedFabricFilter.DrapeColor + ".png";
                //            details.m_strImageName = m_strImageName;
                //            details.m_strImagePath = imageWritePath;
                //            details.m_nGrpIndex = 0;

                //            if (null != mainImage)
                //                details.m_imagebuf = mainImage;

                //            drapeImage = null;
                //            drapeImage = ConvertImageToByteData(uImage);
                //            var list = new List<DrapeDetail>() { details };
                //            if (!Directory.Exists(imageWritePath))
                //                Directory.CreateDirectory(imageWritePath);

                //            var rr = imageDrapper.Drape(drapeImage, list.ToArray(), true, false, false);
                //            if (File.Exists(uImage))
                //                File.Delete(uImage);

                //            drapeImage = null;
                //            if (drappedFabricFilter.FabricSwatchId != 0)
                //            {
                //                if (!Directory.Exists(imageWritePath))
                //                    Directory.CreateDirectory(imageWritePath);
                //            }
                //            else if (drappedFabricFilter != null && drappedFabricFilter.FabricSwatchId == 0 &&
                //                     drappedFabricFilter.DrapeColor == "FFFFFF")
                //            {
                //                if (rr == 1)
                //                { }
                //            }
                //            else
                //                imageWritePath = imageWritePath + m_strImageName;

                //            imageDrapper.Dispose();
                //            if (imageDrapper != null)
                //                GC.SuppressFinalize(imageDrapper);
                //        }
                //        catch (Exception e)
                //        {
                //            Console.WriteLine(e.ToString());
                //        }
                //    }
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void TempDrap(string filename, string imageWritePath)
        {
            try
            {
               // string imageWritePath = @"D:\TailorI.Admin_RAYMONDRETAILER\TestDrape\";
                string FabricSwatchId = Path.GetFileNameWithoutExtension(filename);
                            
                if (File.Exists(imageWritePath + FabricSwatchId + ".png"))
                    return;

                ImageDrapper imageDrapper = new ImageDrapper();
                Color clr;
                DrapeDetail details = new DrapeDetail();

                string m_strImageName = string.Empty;
                if (FabricSwatchId != "0")
                    m_strImageName = FabricSwatchId + ".png";
                else
                    m_strImageName = "WhiteDrapped" + ".png";
                byte[] mainImage = ConvertImageToByteData(@"D:\TailorI.Admin_RAYMONDRETAILER\FabricSwatches\72046025204\FabricImage\3953074169.png");
              
                details.m_bHorFlip = details.m_bVertFlip = details.m_nXWrap = details.m_nYWrap = 0;
                details.m_nRotateAgle = 0;
                details.m_nFabSize = 100;

                clr = HexToRgb("FFFFFF", false);
                details.m_color = new byte[3];
                details.m_color[0] = clr.R;
                details.m_color[1] = clr.G;
                details.m_color[2] = clr.B;
                details.m_strImageName = m_strImageName;
                details.m_strImagePath = imageWritePath;

                if (null != mainImage)
                    details.m_imagebuf = mainImage;

                byte[] drapeImage = ConvertImageToByteData(filename);
                var _list = new List<DrapeDetail>
                {
                    details
                };
                if (!Directory.Exists(imageWritePath))
                    Directory.CreateDirectory(imageWritePath);
                int _rr = imageDrapper.Drape(drapeImage, _list.ToArray(), true, false, false);
                //Console.WriteLine(_rr);
                drapeImage = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();                
            }
            catch (Exception e)
            {
                CLog.LogMessage(e.ToString());                 
            }
        }

        public void _ContentDrape(List<ContentDrapInput> _drapinput)
        {
            try
            {
                fabSize = 100;
                foreach (var drapinput in _drapinput)
                {
                    //string filename = drapinput.DrapeFileName;
                    DrappedFabricFilter drappedFabricFilter = drapinput.DrappedFabricFilter;
                    byte[] drapeImage = drapinput.DrapeImage;
                    string imageWritePath = drapinput.ImageWritePath;
                    EditableDatabaseDetail databasedetails = drapinput.Databasedetails;
                    Color clr;
                    DrapeDetail details;
                    // Default Drape Color White is selected
                    if (drappedFabricFilter != null && (drappedFabricFilter.FabricSwatchId != 0 || drappedFabricFilter.DrapeColor != null))
                    {
                        var imageDrapper = new ImageDrapper();
                        //var uImage = GetUnCompressedDataPath(drapeImage);
                        //var _filename = UnZip(filename);

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                        imageDrapper = new ImageDrapper();

                        byte[] mainImage = null;
                        try
                        {
                            details = new DrapeDetail();
                            var m_strImageName = string.Empty;

                            if (drappedFabricFilter.FabricSwatchId != 0)
                                m_strImageName = drappedFabricFilter.FabricSwatchId + ".png";
                            else
                                m_strImageName = "WhiteDrapped" + ".png";

                            mainImage = GetImageData_New(databasedetails, new FabricSwatchFilter
                            {
                                FabricSwatchId = drappedFabricFilter.FabricSwatchId,
                                ImageType = ImageEnum.None
                            });

                            details.m_bHorFlip = details.m_bVertFlip = details.m_nXWrap = details.m_nYWrap = 0;
                            details.m_nRotateAgle = 0;
                            details.m_nFabSize = fabSize;

                            clr = HexToRgb(drappedFabricFilter.DrapeColor, false);
                            details.m_color = new byte[3];
                            details.m_color[0] = clr.R;
                            details.m_color[1] = clr.G;
                            details.m_color[2] = clr.B;
                            if (drappedFabricFilter.DrapeColor != "FFFFFF")
                                m_strImageName = drappedFabricFilter.ProductConfigurationId + drappedFabricFilter.DrapeColor + ".png";
                            details.m_strImageName = m_strImageName;
                            details.m_strImagePath = imageWritePath;
                            details.m_nGrpIndex = 0;

                            if (null != mainImage)
                                details.m_imagebuf = mainImage;

                            //drapeImage = null;
                            //drapeImage = ConvertImageToByteData(uImage);
                            var list = new List<DrapeDetail>() { details };
                            if (!Directory.Exists(imageWritePath))
                                Directory.CreateDirectory(imageWritePath);

                            var rr = imageDrapper.Drape(drapeImage, list.ToArray(), true, false, false);
                            //  var rr = imageDrapper.Drape(_filename, list.ToArray(), true, false, false);
                            //if (File.Exists(_filename))
                            //   File.Delete(_filename);

                            //drapeImage = null;
                            //if (drappedFabricFilter.FabricSwatchId != 0)
                            //{
                            //    //if (!Directory.Exists(imageWritePath))
                            //    //    Directory.CreateDirectory(imageWritePath);
                            //}
                            ////else if (drappedFabricFilter != null && drappedFabricFilter.FabricSwatchId == 0 &&
                            ////         drappedFabricFilter.DrapeColor == "FFFFFF")
                            ////{
                            ////    //if (rr == 1)
                            ////    //{ }
                            ////}
                            //else
                            //    imageWritePath = imageWritePath + m_strImageName;

                            imageDrapper.Dispose();
                            if (imageDrapper != null)
                                GC.SuppressFinalize(imageDrapper);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static string UnZip(string filename)
        {
            try
            {
                var filePath = Path.GetTempPath();
                using (ZipArchive archive = ZipFile.Open(filename, ZipArchiveMode.Read))
                {
                    string fileName = Path.GetFileName(filename).ToLower();
                    string _fileName = fileName.Replace(".3dc", ".3dp");
                    filePath += _fileName;
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        entry.ExtractToFile(filePath);
                    }
                }
                return filePath;
            }
            catch (Exception e)
            { return null; }
        }

        /// <summary> Method for getting BestfitImage </summary>
        /// <param name="databasedetails">the database details</param>
        /// <param name="fabricSwatchFilter">The fabric swatch filter.</param>
        /// <returns>byte[]</returns>
        /// <remarks></remarks>
        public static byte[] GetImageData_New(EditableDatabaseDetail databasedetails, FabricSwatchFilter fabricSwatchFilter)
        {
            try
            {
                if (databasedetails != null)
                {
                    var fabricSwatchData = new FabricSwatch();
                    string query = " Select * From FabricSwatches Where FabricSwatchId = " + fabricSwatchFilter.FabricSwatchId;
                    var fabricswatchesds = GetDataSet(query, "FabricSwatches", databasedetails);

                    foreach (DataRow row in fabricswatchesds.Tables[0].Rows)
                    {
                        fabricSwatchData.FabricSwatchId = row["FabricSwatchId"] == DBNull.Value ? 0 : Convert.ToInt64(row["FabricSwatchId"].ToString());
                        fabricSwatchData.FabricLibraryId = row["FabricLibraryId"] == DBNull.Value ? 0 : Convert.ToInt64(row["FabricLibraryId"].ToString());
                        fabricSwatchData.FabricSwatchName = row["FabricSwatchName"] == DBNull.Value ? null : Convert.ToString(row["FabricSwatchName"].ToString());
                    }

                    if (null == fabricSwatchData)
                        return null;
                    var path = databasedetails.DriveLetter + ":\\" + databasedetails.ClientName + "\\FabricSwatches\\" + fabricSwatchData.FabricLibraryId;

                    switch (fabricSwatchFilter.ImageType)
                    {
                        case ImageEnum.BestFit:
                            if (File.Exists(path + "\\BestfitImage\\" + fabricSwatchData.FabricSwatchId + ".png"))
                                return ConvertImageToByteData(path + "\\BestfitImage\\" + fabricSwatchData.FabricSwatchId + ".png");
                            break;
                        case ImageEnum.Thumb:
                            if (File.Exists(path + "\\ThumbImage\\" + fabricSwatchData.FabricSwatchId + ".png"))
                                return ConvertImageToByteData(path + "\\ThumbImage\\" + fabricSwatchData.FabricSwatchId + ".png");
                            break;
                        case ImageEnum.None:
                            if (File.Exists(path + "\\FabricImage\\" + fabricSwatchData.FabricSwatchId + ".png"))
                                return ConvertImageToByteData(path + "\\FabricImage\\" + fabricSwatchData.FabricSwatchId + ".png");
                            break;
                        default:
                            return null;
                    }
                    return null;
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary> Gets the data set. </summary>
        /// <param name="strQuery">The STR query.</param>
        /// <param name="strTableName">Name of the STR table.</param> 
        /// <returns></returns>
        public static DataSet GetDataSet(string strQuery, string strTableName, EditableDatabaseDetail databasedetails)
        {
            string connectionstring = SetConnectionString(databasedetails);
            var data = new SqlData(connectionstring);
            var ds = new DataSet();
            try
            {
                data.Command.CommandTimeout = 0;
                data.Command.CommandType = CommandType.Text;
                data.Command.CommandText = strQuery;
                data.Fill(ref ds, strTableName);
                return ds;
            }
            catch (Exception ex)
            {
                CLog.LogMessage(ex.ToString());
            }
            finally
            {
                data.CloseConnection();
            }
            return null;
        }

        /// <summary> Method for setting connection string </summary>
        /// <param name="productObjectContext">ProductEntities object</param>
        /// <param name="databaseDetail">DatabaseDetail</param>
        public static string SetConnectionString(EditableDatabaseDetail databaseDetail)
        {
            if (null == databaseDetail) return null;
            if (string.IsNullOrEmpty(databaseDetail.WorkStationId))
                databaseDetail.WorkStationId = databaseDetail.DataSourceName;
            if (databaseDetail.ClientName != null && databaseDetail.DataSourceName != null && databaseDetail.UserId != null && databaseDetail.Password != null)
                return GetConnectionString(databaseDetail.WorkStationId,
                    databaseDetail.UserId,
                    databaseDetail.Password,
                    databaseDetail.DataSourceName,
                    databaseDetail.ClientName);
            else
                return null;
        }

        /// <summary> Method for getting connection string. </summary>
        /// <returns>Connection string</returns>
        /// <param name="workStationId">serverName</param>
        /// <param name="userId">userId</param>
        /// <param name="password">password</param>
        /// <param name="dataSourceName">dataSourceName</param>
        /// <param name="initialCatalog">initialCatalog</param>
        /// <returns>Connection String </returns>
        public static string GetConnectionString(string workStationId = "172.16.10.127", string userId = "sa", string password = "server@2010", string dataSourceName = "172.16.10.127", string initialCatalog = "TailorI.Authentication")
        {
            return Convert.ToString(new SqlConnectionStringBuilder
            {
                WorkstationID = workStationId,
                PersistSecurityInfo = true,
                IntegratedSecurity = false,
                MultipleActiveResultSets = true,
                UserID = userId,
                Password = password,
                DataSource = dataSourceName,
                InitialCatalog = initialCatalog,
                ConnectTimeout = 6000,
            });
        }

        /// <summary> Get Image Data and convert it into byte. </summary>
        /// <param name="sourceFileName"> File located path.</param>
        /// <returns>collection of byte.</returns>
        public static byte[] ConvertImageToByteData(string sourceFileName)
        {
            try
            {
                BinaryReader binaryReader = null;
                if (!File.Exists(sourceFileName))
                    return null;

                try
                {
                    binaryReader = new BinaryReader(new FileStream(sourceFileName, FileMode.Open, FileAccess.Read));
                    return binaryReader.ReadBytes(ConvertToInt32(binaryReader.BaseStream.Length));
                }
                finally
                {
                    if (null != binaryReader) binaryReader.Close();
                }
            }
            catch (Exception ex)
            {
                CLog.LogMessage(ex.ToString());
                return null;
            }
        }

        /// <summary>  Converts to <see cref="System.Int32"/> type. </summary>
        /// <param name="parameter">Parameter to convert.</param>
        /// <returns>string</returns>
        public static int ConvertToInt32(object parameter)
        {
            var returnvalue = Int32.MinValue;

            // If exception (Input string was not in a correct format) 
            // is raised then default return value is returned.
            try
            {
                if (null != parameter)
                    returnvalue = Convert.ToInt32(parameter, CultureInfo.InvariantCulture);
            }
            catch
            {
                return returnvalue;
            }

            return returnvalue;
        }

        /// <summary> Hexes to RGB. </summary>
        /// <param name="hexData">The hex data.</param>
        /// <param name="isZero">if set to <c>true</c> [is zero].</param>
        /// <returns>Color</returns>
        private static Color HexToRgb(string hexData, bool isZero)
        {
            if (hexData.Length != 6)
                return Color.Black;

            int r;
            int g;
            int b;

            var rText = hexData.Substring(0, 2);
            var gText = hexData.Substring(2, 2);
            var bText = hexData.Substring(4, 2);

            try
            {
                r = int.Parse(rText, NumberStyles.HexNumber);
                g = int.Parse(gText, NumberStyles.HexNumber);
                b = int.Parse(bText, NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                r = 0;
                g = 0;
                b = 0;
            }
            return Color.FromArgb(isZero ? 0 : 255, r, g, b);
        }

        /// <summary> Method for uncompressing image data.  </summary>
        /// <param name="value">bytes to uncompress.</param>
        /// <returns>original bytes.</returns>
        public static string GetUnCompressedDataPath(byte[] value)
        {
            var filePath = Path.GetTempPath() + Guid.NewGuid() + ".3dp";
            try
            {
                //if (value != null)
                //    using (var zipInputStream = new ZipInputStream(new MemoryStream(value)))
                //    {
                //        while ((zipInputStream.GetNextEntry()) != null)
                //        {
                //            using (var zippedInMemoryStream = new MemoryStream())
                //            {
                //                var data = new byte[2048];
                //                while (true)
                //                {
                //                    var size = zipInputStream.Read(data, 0, data.Length);
                //                    if (size <= 0)
                //                        break;

                //                    zippedInMemoryStream.Write(data, 0, size);
                //                }
                //                zippedInMemoryStream.Close();

                //                File.WriteAllBytes(filePath, zippedInMemoryStream.ToArray());
                //                zippedInMemoryStream.Dispose();
                //                if (zippedInMemoryStream != null)
                //                    GC.SuppressFinalize(zippedInMemoryStream);

                //                return filePath;
                //            }
                //        }
                //    }
                return filePath;
            }
            catch (Exception)
            {
                ConvertByteDataToImage(filePath, value);
                return filePath;
            }
        }

        /// <summary>Method for converting byte data to image </summary>
        /// <param name="targetFileName"> the target file name</param>
        /// <param name="value">the value</param>
        public static string ConvertByteDataToImage(string targetFileName, byte[] value)
        {
            if (value == null) return string.Empty;
            // ReSharper disable EmptyGeneralCatchClause
            try
            {
                if (File.Exists(targetFileName))
                    File.Delete(targetFileName);

                using (var fileStream = new FileStream(targetFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (var binaryWirter = new BinaryWriter(fileStream))
                    {
                        binaryWirter.Write(value);
                        binaryWirter.Close();
                    }
                }
                return targetFileName;
            }
            catch (Exception) { return string.Empty; }
        }

        #endregion Drape

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmRServer
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "frmRServer";
            this.Load += new System.EventHandler(this.frmRServer_Load);
            this.ResumeLayout(false);

        }

        private void frmRServer_Load(object sender, EventArgs e)
        {

        }
    }

    #region class
    public enum ImageEnum
    {
        Thumb = 0,
        BestFit = 1,
        Full = 2,
        Specific = 3,
        Small = 4,
        Large = 5,
        None = 6,
    }

    public class FabricSwatchFilter
    {
        public int End { get; set; }
        public long FabricLibraryId { get; set; }
        public long FabricSwatchId { get; set; }
        public ImageEnum ImageType { get; set; }
        public int Start { get; set; }
    }

    public class FabricSwatch
    {
        public byte[] BestfitImage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Designername { get; set; }
        public byte[] FabricImage { get; set; }
        public long FabricLibraryId { get; set; }
        public long FabricSwatchId { get; set; }
        public string FabricSwatchName { get; set; }
        public List<long> FabricSwatchProductConfigurationsId { get; set; }
        public string HexValue { get; set; }
        public bool IsCachingDone { get; set; }
        public bool? IsFabricSwatchNameDisplay { get; set; }
        public bool? IsPriceDisplay { get; set; }
        public bool IsUnAvailable { get; set; }
        public double? Price { get; set; }
        public byte[] ThumbImage { get; set; }
    }

    /// <summary>  Enum For Image table. </summary>
    public enum ImageEnumDto
    {
        /// <summary>
        /// Enum for Thumb
        /// </summary>
        Thumb,

        /// <summary>
        /// Enum for Best Fit
        /// </summary>
        BestFit,

        /// <summary>
        /// Enum for Full
        /// </summary>
        Full,

        /// <summary>
        /// Enum for Specific
        /// </summary>
        Specific,

        /// <summary>
        /// Small
        /// </summary>
        Small,

        /// <summary>
        /// Large
        /// </summary>
        Large,

        /// <summary>
        /// None
        /// </summary>
        None
    }

    /// <summary>The purpose of the <see cref="ImageSizeEnumDto"/> class is...</summary>  
    public enum ImageSizeEnumDto
    {
        /// <summary>
        /// Enum for HundredPercent
        /// </summary>
        _100 = 0,

        /// <summary>
        /// Enum for SeventyFivePercent
        /// </summary>
        _75 = 1,

        /// <summary>
        /// Enum for FiftyPercent
        /// </summary>
        _50 = 2,

        /// <summary>
        /// Enum for TwentyFivePercent
        /// </summary>
        _25 = 3
    }

    #endregion class
}
