using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrappingTestLoadBalancer.DrappingServiceRoutine;
using System.IO;
using System.Threading;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Configuration;
using System.Web.Configuration;
using System.ServiceModel.Configuration;  

namespace DrappingTestLoadBalancer
{
    class Program
    {
        public static int CountOfDrappedImage = 0;
       
        public static SortedDictionary<string, bool> drappingimagestatus;
        public List<EndpointAddress> EndpointAddresses = new List<EndpointAddress>();
        public static List<string> ip = new List<string>();
        public static int id = 0;

        //public static AutoResetEvent mr1 = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Program p = new Program();
            List<string> pendingdrapimage;
            p.EndpointAddresses.Add(new EndpointAddress("http://localhost:50304/DrappingServiceRoutine.svc"));

             //p.EndpointAddresses.Add(new EndpointAddress("http://172.16.10.80/DrappingServiceRoutine/DrappingServiceRoutine.svc"));
             // p.EndpointAddresses.Add(new EndpointAddress("http://172.16.10.120/DrappingServiceRoutine/DrappingServiceRoutine.svc"));
             // p.EndpointAddresses.Add(new EndpointAddress("http://172.16.10.106/DrappingServiceRoutine/DrappingServiceRoutine.svc"));


            try
            {
                do
                {
                    Binding binding = CreateDefaultBinding();


                    pendingdrapimage = new List<string>();
                    foreach (string s in Directory.GetFiles(@"D:\images", "*.png").Select(Path.GetFileName))
                        pendingdrapimage.Add(s);
                    IsFileExistRequestDto isfileexistrequestdto = new IsFileExistRequestDto();
                    isfileexistrequestdto.ImageName = pendingdrapimage.ToArray();
                    EndpointAddress ep = new EndpointAddress("http://localhost:50304/DrappingServiceRoutine.svc");
                    DrappingServiceRoutine.DrappingServiceRoutineClient proxy = new DrappingServiceRoutine.DrappingServiceRoutineClient(binding, ep);
                    isfileexistrequestdto.DestinationPath = @"\\172.16.1.48\d\DrappingImages\";
                    IsFileExistResponseDto isfileexistresponcedto = proxy.IsFileExist(isfileexistrequestdto);
                    if (isfileexistresponcedto.IsError == true)
                        throw new Exception(isfileexistresponcedto.ErrorMessage);
                    drappingimagestatus = new SortedDictionary<string, bool>();
                    foreach (var img in isfileexistresponcedto.ImageNameToBeDrapped)
                    {
                        drappingimagestatus.Add(img, false);
                    }
                    proxy.Close();
                    Console.WriteLine("child thread starting =>");
                    CountOfDrappedImage = 0;
                    if (drappingimagestatus.Count != 0)
                    {
                        foreach (EndpointAddress ep1 in p.EndpointAddresses)
                        {
                            if (id < drappingimagestatus.Count)
                            {
                                Thread t = new Thread(new ParameterizedThreadStart(p.LoadAssignment));
                                t.Name = id.ToString();
                                t.Start(ep1);
                                id++;
                            }
                        }
                    }
                    Thread.CurrentThread.Join();
                } while (pendingdrapimage.Count <= CountOfDrappedImage);
                
                Console.WriteLine("All images has been successfully written <=");

                Console.WriteLine("Main Thread Terminating <=");
                Console.ReadKey();

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                Console.WriteLine("MainThread Terminating");
                Console.ReadKey();
            }
            return;
        }
       
        public void LoadAssignment(object EndpointAddresses)
        {
            while (drappingimagestatus.Count > CountOfDrappedImage)
            {
                Binding binding = CreateDefaultBinding();
                try
                {
                    int retryCount = 0;
                    CountOfDrappedImage++;
                    int c = CountOfDrappedImage - 1; ;
                    // var keyname = drappingimagestatus;
                    // drappingimagestatus.Where(s => s.Key== )).Select(s2 => s2.Value)= true;

                    Binding bs = new BasicHttpBinding();
                    DrappingServiceRoutine.DrappingServiceRoutineClient proxy = new DrappingServiceRoutine.DrappingServiceRoutineClient(binding, (EndpointAddress)EndpointAddresses);
                    Program p = new Program();

                    while (CountOfDrappedImage <= drappingimagestatus.Count)
                    {
                    RetryProc:
                        var currentThread = Thread.CurrentThread.Name;
                        DrapImageRequestDto drapimagerequestdto = new DrapImageRequestDto();
                        drapimagerequestdto.SourcePath = @"\\172.16.1.48\d\DrappingImages\" + drappingimagestatus.Keys.ElementAt(c);
                        string fetchAddress = @"D:\images\" + drappingimagestatus.Keys.ElementAt(c);

                        drapimagerequestdto.DrappedImageByte = System.IO.File.ReadAllBytes(fetchAddress);
                        if (drappingimagestatus.Keys.ElementAt(c) == null)
                            return;
                        string var = drappingimagestatus.Where(s1 => s1.Value == false).Select(s => s.Key).FirstOrDefault();
                        Console.WriteLine("{0}====={1}======= {2}", drappingimagestatus.Keys.ElementAt(c), (EndpointAddress)EndpointAddresses, c);

                        DrapImageResponseDto result = proxy.DrapImage(drapimagerequestdto);
                        if (currentThread == "0")
                        {
                           // Thread.Sleep(1000);
                        }
                        if (currentThread == "1")
                        {
                            //Thread.Sleep(1000);
                        }
                        if (currentThread == "2")
                        {
                           // Thread.Sleep(1000);
                        }
                        lock (this)
                        {
                            CountOfDrappedImage++;
                        }
                        if (result.IsSuccess == false)
                        {
                            retryCount++;
                            goto RetryProc;
                        }
                        c = CountOfDrappedImage - 1;
                    }

                    proxy.Close();
                }
                catch (Exception E)
                {
                    Console.WriteLine("{0}====={1}======= {2}", (EndpointAddress)EndpointAddresses, CountOfDrappedImage - 1,E);
                }
            }
            return;
        }
        public static System.ServiceModel.Channels.Binding CreateDefaultBinding()
        {
            System.ServiceModel.Channels.CustomBinding binding = new System.ServiceModel.Channels.CustomBinding();
            binding.Elements.Add(new System.ServiceModel.Channels.TextMessageEncodingBindingElement(System.ServiceModel.Channels.MessageVersion.Soap11, System.Text.Encoding.UTF8));
            System.ServiceModel.Channels.HttpTransportBindingElement http = new System.ServiceModel.Channels.HttpTransportBindingElement();
            http.MaxBufferPoolSize = 2147483647;
            http.MaxBufferSize = 2147483647;
            http.MaxReceivedMessageSize = 2147483647;
            http.TransferMode = System.ServiceModel.TransferMode.Buffered;
            binding.Elements.Add(http);
            return binding;
        }
    }
}
