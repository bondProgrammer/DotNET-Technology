using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Collections.Generic;

namespace RemotableObjects
{
      
    public class MyRemotableObject : MarshalByRefObject
    {        
        public List<ContentDrapInput> contentdrapinput { get; set; }

        public MyRemotableObject()
        {             
        }
        public void SetMessage(List<ContentDrapInput> message)
        {
            Cache.GetInstance().MessageString = message;
        }
    }
}
