using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace POSM
{
    class CallbackThreads
    {


        public static void TimerCallbackThreading() { 
        
                 TimerCallback timerDelegate = new TimerCallback(Db_Backup);
                 Timer PumpTimer = new Timer(timerDelegate, null, 900000, 900000);


                 TimerCallback timerDelegate1 = new TimerCallback(checkHotKeyPromotion);
                 Timer checkHotKey = new Timer(timerDelegate1, null, 900000, 900000);

                 TimerCallback timerDelegate2 = new TimerCallback(device_config_check);
                 Timer device_config = new Timer(timerDelegate2, null, 3600000, 3600000);

        
        }

        private static void device_config_check(object state)
        {
            string query="select SiteKey,APP,filepath,Updatepending from ConfigurationTables where SiteKey=XXX and APP='XXXX'";

            //check new device config file  from cloud

            //first hit configuration table and get device config xml file accoring site key and app name

            //store xml file from destination folder

            // restart the app
        }

        private static void checkHotKeyPromotion(object state)
        {
            //check new hot keys promotion from cloud

            //first hit configuration table and get hot key xml file accoring site key

            //store xml file from destination folder


            //restart the app
        }




        private static void Db_Backup(object state)
        {
                string source = Macros.DESTI_PATH+Macros.DB_FILE;
                string destination = Macros.DESTI_PATH + Macros.DB_BCK_FILE;

                CopyPaste( source, destination);
            
            //Backup Script

               //
        }

        public static void CopyPaste(string source, string destination) {

            try
            {
                

                File.Copy( source,  destination);
            }
            catch (Exception ex)
            {

                Debug.WriteLine("can't copy file");
            }
        
        }

    }
}
