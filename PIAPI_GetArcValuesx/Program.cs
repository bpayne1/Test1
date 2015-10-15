using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PIAPI_GetArcValuesx
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Test piar_getarcvaluesx");
            double myFloatVal = 0;
            int iStat = 0;
            short Flags = 0;
            PIAPI32.PITimeStamp time0;
            PIAPI32.PITimeStamp time1;
            int FuncCode = 0;
            int TimeStamp = 0;
            int intholder = 0;

            time0.Month = 0;
            time0.Day = 0;
            time0.Hour = 0;
            time0.Minute = 0;
            time0.Second = 0;
            time0.tzinfo = 0;
            time0.Year = 0;


            time1.Month = 0;
            time1.Day = 0;
            time1.Hour = 0;
            time1.Minute = 0;
            time1.Second = 0;
            time1.tzinfo = 0;
            time1.Year = 0;
            int ptnum = 3;
            //int pi2time = 0;
            int ptcount = 0;

            int retVal = PIAPI32.piut_setservernode("bpaynee6410");

            //we construct the timestamp
            long Suberr = PIAPI32.pitm_parsetime(@"08-Mar-15 01:00:00", 0, ref TimeStamp);
            //long Suberr = PIAPI32.pitm_parsetime(@"03/08/15 01:00:00", 0, ref pi2time);
            try
            {
                Suberr = PIAPI32.pitm_setpitime(ref time0, TimeStamp, 0.0);
                Suberr = PIAPI32.pitm_parsetime(@"08-Mar-15 04:00:00", 0, ref TimeStamp);
                Suberr = PIAPI32.pitm_setpitime(ref time1, TimeStamp, 0.0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
            }

            retVal = PIAPI32.piar_getarcvaluesx(ref ptnum, PIAPI32.ARCFLAG_COMP, ref ptcount, ref myFloatVal, ref intholder, null,  ref intholder, ref iStat, ref Flags, ref time0, ref time1, PIAPI32.GETFIRST);

            Console.WriteLine("Finished " + myFloatVal + " " );
            Console.ReadLine();

        }
    }
}
