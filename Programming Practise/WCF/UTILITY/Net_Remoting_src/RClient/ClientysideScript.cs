using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;

using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using RemotableObjects;
using System.Threading;


namespace RClient
{
    public class ClientysideScript : System.Windows.Forms.Form
    {
        private static MyRemotableObject remoteObject;
        private System.ComponentModel.Container components = null;

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
            ////************************************* TCP *************************************//
            //// using TCP protocol
            //// running both client and server on same machines
            //TcpChannel chan = new TcpChannel();
            //ChannelServices.RegisterChannel(chan);
            //// Create an instance of the remote object
            //remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.11:8080/HelloWorld");
            //// if remote object is on another machine the name of the machine should be used instead of localhost.
            ////************************************* TCP *************************************//
            Drape();
        }

        static List<ContentDrapInput> _contentDrapInput = new List<ContentDrapInput>();

        private static void Drape()
        {
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan);

            string[] collection = Directory.GetFiles(@"D:\RMI\3dc-NEW\");
            int i = 11;
            int j = 101;
            foreach (var item in collection)
            {
                if (i == 16)
                    i = 11;

                //Thread thread = new Thread(() => { _Drapenew(i,j, item); });
                //thread.Start();
                //thread.Join();

                DrappedFabricFilter drappedFabricFilter = new RemotableObjects.DrappedFabricFilter();
                drappedFabricFilter.FabricSwatchId = i;
                byte[] drapeImage = ConvertImageToByteData(item);
                _contentDrapInput.Add(new ContentDrapInput
                {
                    DrappedFabricFilter = drappedFabricFilter,
                    DrapeFileName = item,
                    DrapeImage = drapeImage,
                    ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.RaymondPA\",
                });
                //remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10." + i + ":8080/HelloWorld");
                //remoteObject.SetMessage(_contentDrapInput);
                //_contentDrapInput = new List<ContentDrapInput>();

                remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.127:8080/HelloWorld");
                remoteObject.SetMessage(_contentDrapInput);
                i++;
                j++;
                _contentDrapInput = new List<ContentDrapInput>();
            }
        }

        private static void _Drapenew(int i,int j, string item)
        {
            DrappedFabricFilter drappedFabricFilter = new RemotableObjects.DrappedFabricFilter();
            drappedFabricFilter.FabricSwatchId = j;
            byte[] drapeImage = ConvertImageToByteData(item);
            _contentDrapInput.Add(new ContentDrapInput
            {
                DrappedFabricFilter = drappedFabricFilter,
                DrapeFileName = item,
                DrapeImage = drapeImage,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.RaymondPA\",
            });
            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10." + i + ":8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
        }


        private static void _Drape()
        {
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan);

            byte[] _drapeImage2 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\2.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage2,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\2\",
            });

            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();

            byte[] _drapeImage1 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\1.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage1,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\1\",
            });

            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();

            byte[] _drapeImage3 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\3.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage3,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\3\",
            });


            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();


            byte[] _drapeImage4 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\4.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage4,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\4\",
            });
            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();

            byte[] _drapeImage5 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\5.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage5,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\5\",
            });
            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();

            byte[] _drapeImage6 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\6.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage6,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\6\",
            });
            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();

            byte[] _drapeImage7 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\7.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage7,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\7\",
            });
            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();

            byte[] _drapeImage8 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\8.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage8,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\8\",
            });
            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();

            byte[] _drapeImage9 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\9.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage9,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\9\",
            });
            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();

            byte[] _drapeImage11 = ConvertImageToByteData(@"C:\Users\Abhijit Nagale\Desktop\png\11.3dc");
            _contentDrapInput.Add(new ContentDrapInput
            {
                Databasedetails = new EditableDatabaseDetail
                {
                    ClientName = "TailorI.Admin_TAILORIDEMOLONG",
                    DataSourceName = "172.16.10.160",
                    DriveLetter = "D",
                    Password = "server@2010",
                    UserId = "sa",
                    UserName = "tailoridemolong1",
                    WorkStationId = "172.16.10.160",
                },
                DrapeImage = _drapeImage11,
                DrappedFabricFilter = new DrappedFabricFilter
                {
                    DrapeColor = "FFFFFF",
                    FabricSwatchId = 0,
                    LinkImageProductConfigurationId = null,
                    MainLinkImageProductConfigurationId = null,
                    ProductAlignmentId = 505105693055,
                    ProductConfigurationId = 17847729504,
                },
                ImageSizeEnum = ImageSizeEnumDto._100,
                ImageWritePath = @"\\172.16.10.10\DrappingImages\DrappingImages\TailorI.Admin_TAILORIDEMOLONG\11\",
            });
            remoteObject = (MyRemotableObject)Activator.GetObject(typeof(MyRemotableObject), "tcp://172.16.10.12:8080/HelloWorld");
            remoteObject.SetMessage(_contentDrapInput);
            _contentDrapInput = new List<ContentDrapInput>();

            remoteObject.SetMessage(_contentDrapInput);
        }

        /// <summary> Get Image Data and convert it into byte. </summary>
        /// <param name="sourceFileName"> File located path.</param>
        /// <returns>collection of byte.</returns>
        public static byte[] ConvertImageToByteData(string sourceFileName)
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
    }
}
