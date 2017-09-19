using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbnApi;

namespace statusreader
{
    class Program
    {
        static void Main(string[] args)
        {
            MbnInterfaceManager mbnInfMgr = new MbnInterfaceManager();
            IMbnInterfaceManager infMgr = (IMbnInterfaceManager)mbnInfMgr;


            MbnConnectionManager mbnConnectionMgr = new MbnConnectionManager();
            IMbnConnectionManager ImbnConnectionMgr = (IMbnConnectionManager)mbnConnectionMgr;


            IMbnConnection[] connections = (IMbnConnection[])ImbnConnectionMgr.GetConnections();
            foreach (IMbnConnection conn in connections)
            {
                IMbnInterface mobileInterface = infMgr.GetInterface(conn.InterfaceID) as IMbnInterface;
                MBN_INTERFACE_CAPS caps = mobileInterface.GetInterfaceCapability();

                MBN_PROVIDER provider = mobileInterface.GetHomeProvider();
                Console.WriteLine("Device Id :" + caps.deviceID);
                Console.WriteLine("DataClass: " + caps.cellularClass);
                Console.WriteLine("Manufacturer: " + caps.manufacturer);
                Console.WriteLine("Model : " + caps.model);
                Console.WriteLine("Firmware Version: " + caps.firmwareInfo);
                Console.WriteLine("Manufacturer:        " + caps.manufacturer);
                Console.WriteLine("Model:               " + caps.model);
                Console.WriteLine("DeviceID:            " + caps.deviceID);
                Console.WriteLine("FirmwareInfo:        " + caps.firmwareInfo);
          
                Console.WriteLine("InterfaceID:         " + mobileInterface.InterfaceID);
                Console.WriteLine("Provider:            " + provider.providerName);
                Console.WriteLine("ProviderID:          " + provider.providerID);
                Console.WriteLine("ProviderState:       " + provider.providerState);


            }
            Console.ReadKey(true);

        }
    }
}
