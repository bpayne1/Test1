using System;
using System.Runtime.InteropServices;

namespace PIAPI_GetArcValuesx
{
	/// <summary>
	/// Summary description for PIAPI32.
	/// </summary>

	public class PIAPI32
	{
		//------------------------------- piar_summary definitions
		public const int ARCTOTAL = 0;
		public const int ARCMINIMUM = 1;
		public const int ARCMAXIMUM = 2;
		public const int ARCSTDEV = 3;
		public const int ARCRANGE = 4;
		public const int ARCAVERAGE = 5;
		public const int ARCMEAN = 6;

		//------------------------------- piar_value definitions
		public const int ARCVALUEBEFORE = 1;
		public const int ARCVALUEAFTER = 2;
		public const int ARCVALUEINTERP = 3;
		public const int ARCVALUECODE = 4;

		//------------------------------- piel_evntactn definitions
		public const int ELEQSEARCH = 1;
		public const int ELGESEARCH = 2;
		public const int ELLESEARCH = 3;
		public const int ELGTSEARCH = 4;
		public const int ELLTSEARCH = 5;
		public const int ELEDIT = 6;
		public const int ELDELETE = 7;

		//------------------------------- pilg_putoutput definitions
		public const int MSGLOG = 1;
		public const int STDOUTPUT = 2;

		//------------------------------- pipt_updates definitions
		public const int NOTAGS = 0;
		public const int POINTCREATE = 1;
		public const int POINTEDIT = 2;
		public const int POINTDELETE = 3;

		//------------------------------- piut_login definitions
		public const int PILOGINOK = 1;
		public const int PIREADACCESS = 2;
		public const int PIWRITEACCESS = 4;
		public const int PILOGINREAD = 8;
		public const int PILOGINWRITE = 16;
		public const int PILOGINPIUSER = 256;
		public const int PILOGINVMS = 512;
		public const int PILOGINUNIX = 1024;
		public const int PINO = 0;
		public const int PIREAD = 1;
		public const int PIREADWRITE = 2;
		//-------------------------------- pilg definitions
		public const int GETFIRST = 0;
		public const int GETNEXT = 1;
		public const int GETSAME = 2;
		public const int PI_NOMOREVALUES = 100;
		public const int PI_M_AFLAG = 1;
		public const int PI_M_QFLAG = 2;
		public const int PI_M_SFLAG = 4;
		public const int MAX_POINT_NUM_LEN = 16;
		public const int MAX_NODENAME_LEN = 30;
		public const int MAX_TAGNAME_LEN = 256;
		public const int MAX_USERNAME_LEN = 30;
		public const int PILOGIN_SERVER_TYPE_PI = 1000;
		//-------------------------------- extended API definitions
		public const int ARCflag_time = 4;
		public const int ARCFLAG_EVEN = 8;
		public const int ARCflag_filter = 16;
		public const int ARCflag_mark = 32;
		public const int ARCFLAG_COMP = 64;

		public const int PI_Type_null = 0;
		public const int PI_Type_bool = 1;
		public const int PI_Type_uint8 = 2;
		public const int PI_Type_int8 = 3;
		public const int PI_Type_char = 4;
		public const int PI_Type_uint16 = 5;
		public const int PI_Type_int16 = 6;
		public const int PI_Type_uint32 = 7;
		public const int PI_Type_int32 = 8;
		public const int PI_Type_uint64 = 9;
		public const int PI_Type_int64 = 10;
		public const int PI_Type_float16 = 11;
		public const int PI_Type_float32 = 12;
		public const int PI_Type_float64 = 13;
		public const int PI_Type_PI2 = 14;
		public const int PI_Type_digital = 101;
		public const int PI_Type_blob = 102;
		public const int PI_Type_PIstring = 105;
		public const int PI_Type_bad = 255;

		// piar_putarcvaluesx defines
		public const int ARCNOREPLACE = 3;   // add unless event(s) exist at same time (PI 2.x)
		public const int ARCAPPEND = 4;      // add event regardless of existing events
		public const int ARCREPLACE = 5;     //  add event, replace if event at same time
		public const int ARCREPLACEX = 6;    //  replace existing event (fail if no event at time)
		public const int ARCDELETE = 7;      //  remove existing event
		public const int ARCAPPENDX = 8;     //  add event regardless of existing events, no compression

		//---------------------------- Structure declarations
		public struct QERROR 
		{
			public int Point;
			public int piapierror;
		};

		public const int MAXPI3PUTSNAP = 255; // For queue call return values.

		public struct QERRORS
		{
			public int syserror;
			public int numpterrs;
			public QERROR[] qerr;  //TODO: Find out if "QERROR[] qerr" is right, it supposed to be dimensioned to the size of MAXPI3PUTSNAP
		}

		public struct PI_EXCEPT
		{
			float NewVal;
			int newstat;
			int newTime;
			float oldVal;
			int oldstat;
			int oldTime;
			float prevVal;
			int prevstat;
			int prevTime;
			float ExcDevEng;
			int ExcMin;
			int ExcMax;
		}

		public struct PI_VAL
		{
			int bSize;
			int iStat;
			int Flags;
		}

		public struct TagList
		{
			string server;  //TODO: What do since C# can't specify a sizeof the string?  It should be MAX_NODENAME_LEN
			int NodeID;
			string TagName; //same as server
			int Point;
			int reserved;
		}
        public struct PITimeStamp
		{
			public int Month;		// 1-12
            public int Year;		// four digit
            public int Day;			// 1-31
            public int Hour;		// 0-23
            public int Minute;		// 0-59
            public int tzinfo;
            public double Second; // 0-59.99999999.... 
		}
		
		//PI batch function declarations -- New with PI-API v1.1.0
		[DllImport("piapi32.dll")] public static extern int piba_getunit(string unit, int slen, int index,	ref int number);
		[DllImport("piapi32.dll")] public static extern int piba_getaliaswunit(string unit, string balias, int slen, int index, ref int number);
		[DllImport("piapi32.dll")] public static extern int piba_getunitswalias(string balias, string unit, int slen, int index, ref int number);
		[DllImport("piapi32.dll")] public static extern int piba_findaliaspoint(string unit, string balias, int ptno, string TagName, int slen);
		[DllImport("piapi32.dll")] public static extern int piba_search(string batchid, int blen, string unit, int ulen, string product, ref int plen, ref int stime, ref int etime, int sf, int timeout);

		//PI Login Services function declarations -- new with PI-API v1.1.0
		[DllImport("pilog32.dll")] public static extern int pilg_addnewserver(string ServerName, int servertype, string username, int portnum);
		[DllImport("pilog32.dll")] public static extern int pilg_connectdlg(int hwndparent);
		[DllImport("pilog32.dll")] public static extern int pilg_disconnect();
		[DllImport("pilog32.dll")] public static extern int pilg_disconnectnode(string ServerName);

		[DllImport("pilog32.dll")] public static extern int pilg_getconnectedserver(string servernamebuf, ref int bufsize, ref int NodeID, ref int port, int seq);
		[DllImport("pilog32.dll")] public static extern int pilg_getdefserverinfo(string servernamebuf, ref int bufsize, ref int NodeID, ref int port);
		[DllImport("pilog32.dll")] public static extern int pilg_getnodeid(string servernamebuf, ref int NodeID);
//		[DllImport("pilog32.dll")] public static extern int pilg_getselectedtag(TagList* taglst, ref int seq);
		[DllImport("pilog32.dll")] public static extern int pilg_getservername(int NodeID, string servernamebuf, ref int bufsize);
		[DllImport("pilog32.dll")] public static extern int pilg_login(int hwndparent, string username, string ServerName, string password, ref int valid);
//		[DllImport("pilog32.dll")] public static extern int pilg_pointattdlg(int hwndparent, TagList* taglst);
		[DllImport("pilog32.dll")] public static extern int pilg_registerapp(string dllname);
		// The function below requires allocating a linked list which is not supported in VB '
		//[DllImport("pilog32.dll")] public static extern int pilg_registerhelp  (ByVal helpfile$, linklist&);
		[DllImport("pilog32.dll")] public static extern int pilg_setservernode(string ServerName);
		[DllImport("pilog32.dll")] public static extern int pilg_tagsearchdlg(int hwndparent);
		[DllImport("pilog32.dll")] public static extern int pilg_unregisterapp();

		

////Function declarations
//[DllImport("piapi32.dll"] public static extern int piar_calculation Lib "piapi32.dll" (ByRef Count As Integer, ByRef times As Integer, ByRef rvals As Single, ByRef istats As Integer, ByVal Expr As String);
//[DllImport("piapi32.dll"] public static extern int piar_compvalues Lib "piapi32.dll" (ByVal pt As Integer, ByRef Count As Integer, ByRef times As Integer, ByRef rvals As Single, ByRef istats As Integer, ByVal rev As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_compvaluesfil Lib "piapi32.dll" (ByVal pt As Integer, ByRef Count As Integer, ByRef times As Integer, ByRef rvals As Single, ByRef istats As Integer, ByVal Expr As String, ByVal rev As Integer, ByVal fil As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_deletevalue Lib "piapi32.dll" (ByVal pt As Integer, ByVal timedate As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_interpvalues Lib "piapi32.dll" (ByVal pt As Integer, ByRef Count As Integer, ByRef times As Integer, ByRef rvals As Single, ByRef istats As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_interpvaluesfil Lib "piapi32.dll" (ByVal pt As Integer, ByRef Count As Integer, ByRef times As Integer, ByRef rvals As Single, ByRef istats As Integer, ByVal Expr As String);
//[DllImport("piapi32.dll"] public static extern int piar_panvalues Lib "piapi32.dll" (ByVal pt As Integer, ByRef Count As Integer, ByRef timedate As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_plotvalues Lib "piapi32.dll" (ByVal pt As Integer, ByVal intervals As Integer, ByRef Count As Integer, ByRef times As Integer, ByRef rvals As Single, ByRef istats As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_putvalue Lib "piapi32.dll" (ByVal pt As Integer, ByVal rval As Single, ByVal iStat As Integer, ByVal timedate As Integer, ByVal wait As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_replacevalue Lib "piapi32.dll" (ByVal pt As Integer, ByVal timedate As Integer, ByVal rval As Single, ByVal iStat As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_summary Lib "piapi32.dll" (ByVal pt As Integer, ByRef time1 As Integer, ByRef time2 As Integer, ByRef rval As Single, ByRef pctgood As Single, ByVal code As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_timedvalues Lib "piapi32.dll" (ByVal pt As Integer, ByRef Count As Integer, ByRef times As Integer, ByRef rvals As Single, ByRef istats As Integer, ByVal prev As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_timedvaluesfil Lib "piapi32.dll" (ByVal pt As Integer, ByRef Count As Integer, ByRef times As Integer, ByRef rvals As Single, ByRef istats As Integer, ByVal Expr As String);
//[DllImport("piapi32.dll"] public static extern int piar_timefilter Lib "piapi32.dll" (ByVal StartTime As Integer, ByVal EndTime As Integer, ByVal Expr As String, ByRef tottime As Integer, ByRef passtime As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_value Lib "piapi32.dll" (ByVal pt As Integer, ByRef timedate As Integer, ByVal Mode As Integer, ByRef rval As Single, ByRef iStat As Integer);
//[DllImport("piapi32.dll"] public static extern int piel_addevnt Lib "piapi32.dll" (ByRef PItime As Integer, ByRef number As Integer, ByVal group As Integer, ByVal etype As Integer, ByVal Msg As String, ByVal timeout As Integer);
//[DllImport("piapi32.dll"] public static extern int piel_evntactn Lib "piapi32.dll" (ByRef PItime As Integer, ByRef number As Integer, ByRef group As Integer, ByRef etype As Integer, ByVal slen As Integer, ByVal Msg As String, ByVal action As Integer, ByVal timeout As Integer);
//[DllImport("piapi32.dll"] public static extern int pilg_checklogfile Lib "piapi32.dll" (ByVal action As Integer, ByVal LogFile As String);
//[DllImport("piapi32.dll"] public static extern int pilg_formputlog Lib "piapi32.dll" (ByVal Msg As String, ByVal IdString As String);
//[DllImport("piapi32.dll"] public static extern int pilg_puthomelog Lib "piapi32.dll" (ByVal Msg As String);
[DllImport("piapi32.dll")] public static extern int pilg_putlog (string Msg);
[DllImport("piapi32.dll")] public static extern int pilg_putoutput (string Msg , int flags);
//[DllImport("piapi32.dll"] public static extern int pipt_compspecs Lib "piapi32.dll" (ByVal pt As Integer, ByRef compdev As Integer, ByRef compmin As Integer, ByRef compmax As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_compspecseng Lib "piapi32.dll" (ByVal pt As Integer, ByRef compdeveng As Single, ByRef compmin As Integer, ByRef compmax As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_dates Lib "piapi32.dll" (ByVal pt As Integer, ByRef creationdate As Integer, ByVal creator As String, ByVal crlen As Integer, ByRef changedate As Integer, ByVal changer As String, ByVal chlen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_descriptor Lib "piapi32.dll" (ByVal pt As Integer, ByVal desc As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_digcode Lib "piapi32.dll" (ByRef digcode As Integer, ByVal digstring As String);
//[DllImport("piapi32.dll"] public static extern int pipt_digcodefortag Lib "piapi32.dll" (ByVal pt As Integer, ByRef digcode As Integer, ByVal digstring As String);
//[DllImport("piapi32.dll"] public static extern int pipt_digpointers Lib "piapi32.dll" (ByVal pt As Integer, ByRef digcode As Integer, ByRef dignumb As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_digstate Lib "piapi32.dll" (ByVal digcode As Integer, ByVal digstate As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_displaydigits Lib "piapi32.dll" (ByVal pt As Integer, ByRef displaydigits As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_engunitstring Lib "piapi32.dll" (ByVal pt As Integer, ByVal engunitstring As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_engunstring Lib "piapi32.dll" (ByVal engunitcode As Integer, ByVal engunitstring As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_excspecseng Lib "piapi32.dll" (ByVal pt As Integer, ByRef ExcDevEng As Single, ByRef ExcMin As Integer, ByRef ExcMax As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_exdesc Lib "piapi32.dll" (ByVal pt As Integer, ByVal exdesc As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_findpoint Lib "piapi32.dll" (ByVal TagName As String, ByRef pt As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_inprocbits Lib "piapi32.dll" (ByVal pt As Integer, ByRef larchiving As Integer, ByRef lcompressing As Integer, ByRef filtercode As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_instrumenttag Lib "piapi32.dll" (ByVal pt As Integer, ByVal instrumenttag As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_location Lib "piapi32.dll" (ByVal pt As Integer, ByRef location As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_nextptwsource Lib "piapi32.dll" (ByVal source As Short, ByRef pt As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_pointid Lib "piapi32.dll" (ByVal pt As Integer, ByRef ipt As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_pointsource Lib "piapi32.dll" (ByVal pt As Integer, ByVal source As String);
//[DllImport("piapi32.dll"] public static extern int pipt_pointtype Lib "piapi32.dll" (ByVal pt As Integer, ByVal PtType As String);
//[DllImport("piapi32.dll"] public static extern int pipt_ptexist Lib "piapi32.dll" (ByVal pt As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_recordtype Lib "piapi32.dll" (ByVal pt As Integer, ByRef steps As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_rescode Lib "piapi32.dll" (ByVal pt As Integer, ByRef rescode As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_scale Lib "piapi32.dll" (ByVal pt As Integer, ByRef zero As Single, ByRef span As Single);
//[DllImport("piapi32.dll"] public static extern int pipt_scan Lib "piapi32.dll" (ByVal pt As Integer, ByRef lscan As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_signupforupdates Lib "piapi32.dll" ();
//[DllImport("piapi32.dll"] public static extern int pipt_sourcept Lib "piapi32.dll" (ByVal pt As Integer, ByRef sourcept As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_squareroot Lib "piapi32.dll" (ByVal pt As Integer, ByRef squareroot As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_tag Lib "piapi32.dll" (ByVal pt As Integer, ByVal tag As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_taglong Lib "piapi32.dll" (ByVal pt As Integer, ByVal tag As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_tagpreferred Lib "piapi32.dll" (ByVal pt As Integer, ByVal tag As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_totalspecs Lib "piapi32.dll" (ByVal pt As Integer, ByRef totalcode As Integer, ByRef convers As Single);
//[DllImport("piapi32.dll"] public static extern int pipt_typicalvalue Lib "piapi32.dll" (ByVal pt As Integer, ByRef typicalvalue As Single);
//[DllImport("piapi32.dll"] public static extern int pipt_updates Lib "piapi32.dll" (ByRef pt As Integer, ByVal TagName As String, ByVal slen As Integer, ByRef Mode As Integer);
//[DllImport("piapi32.dll"] public static extern int pipt_userattribs Lib "piapi32.dll" (ByVal pt As Integer, ByRef userint1 As Integer, ByRef userint2 As Integer, ByRef userreal1 As Single, ByRef userreal2 As Single);
//[DllImport("piapi32.dll"] public static extern int pipt_wildcardsearch Lib "piapi32.dll" (ByVal tagmask As String, ByVal direction As Integer, ByRef found As Integer, ByVal TagName As String, ByVal slen As Integer, ByRef pt As Integer, ByRef numfound As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_evmdisestablish Lib "piapi32.dll" (ByRef Count As Integer, ByRef pts As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_evmestablish Lib "piapi32.dll" (ByRef Count As Integer, ByRef pts As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_evmexceptions Lib "piapi32.dll" (ByRef Count As Integer, ByRef pt As Integer, ByRef rval As Single, ByRef iStat As Integer, ByRef timedate As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_getsnapshot Lib "piapi32.dll" (ByVal pt As Integer, ByRef rval As Single, ByRef iStat As Integer, ByRef timedate As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_getsnapshots Lib "piapi32.dll" (ByRef pt As Integer, ByRef rval As Single, ByRef iStat As Integer, ByRef timedate As Integer, ByRef piapierror As Integer, ByVal Count As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_putsnapshot Lib "piapi32.dll" (ByVal pt As Integer, ByVal rval As Single, ByVal iStat As Integer, ByVal timedate As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_putsnapshots Lib "piapi32.dll" (ByRef pt As Integer, ByRef rval As Single, ByRef iStat As Integer, ByRef timedate As Integer, ByRef piapierror As Integer, ByVal Count As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_sendexcepstruc Lib "piapi32.dll" (ByVal pt As Integer, ByVal PtType As Short, ByRef except As PI_EXCEPT, ByRef Count As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_sendexceptions Lib "piapi32.dll" (ByVal pt As Integer, ByVal PtType As Short, ByRef oldVal As Single, ByRef oldstat As Short, ByRef oldTime As Integer, ByRef prevVal As Single, ByRef prevstat As Short, ByRef prevTime As Integer, ByVal NewVal As Single, ByVal newstat As Short, ByVal newTime As Integer, ByVal ExcDevEng As Single, ByVal ExcMin As Short, ByVal ExcMax As Short, ByRef Count As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_sendexcepstrucq Lib "piapi32.dll" (ByVal pt As Integer, ByVal PtType As Short, ByRef except As PI_EXCEPT, ByRef Count As Integer, ByVal Queueing As Short, ByRef numbptErrs As Integer, ByRef qErrs As QERROR);
//'----- these functions have return types incompatible with Visual Basic
//'[DllImport("piapi32.dll"] public static extern int pisn_sendexceptionq Lib "piapi32.dll" (ByVal pt&, ByVal pttype%, oldval!, oldstat%, oldtime&, prevval!, prevstat%, prevtime&, ByVal newval!, ByVal newstat%, ByVal newtime&, ByVal excdeveng!, ByVal excmin%, ByVal excmax%, count&) As QERRORS
//'[DllImport("piapi32.dll"] public static extern int pisn_putsnapshotq Lib "piapi32.dll" (ByVal pt&, ByVal rval!, ByVal istat&, ByVal timedate&) As QERRORS
//'[DllImport("piapi32.dll"] public static extern int pisn_flushputsnapq Lib "piapi32.dll" () As QERRORS
//[DllImport("piapi32.dll"] public static extern int pitm_delay Lib "piapi32.dll" (ByVal mseconds As Integer);
//[DllImport("piapi32.dll"] public static extern int pitm_fastservertime Lib "piapi32.dll" ();
//Declare Sub pitm_formtime Lib "piapi32.dll" (ByVal timedate As Integer, ByVal timestring As String, ByVal slen As Integer)
//Declare Sub pitm_intsec Lib "piapi32.dll" (ByRef timedate As Integer, ByRef timearray As Integer)
		[DllImport("piapi32.dll")] public static extern int pitm_parsetime(string timestr, int reltime, ref int timedate);
//Declare Sub pitm_secint Lib "piapi32.dll" (ByVal timedate As Integer, ByRef timearray As Integer)
//[DllImport("piapi32.dll"] public static extern int pitm_servertime Lib "piapi32.dll" (ByRef servertime As Integer);
//[DllImport("piapi32.dll"] public static extern int pitm_syncwithservertime Lib "piapi32.dll" ();
//[DllImport("piapi32.dll"] public static extern int pitm_systime Lib "piapi32.dll" ();
//[DllImport("piapi32.dll"] public static extern int piut_connect Lib "piapi32.dll" (ByVal ProcName As String);
//[DllImport("piapi32.dll"] public static extern int piut_disconnect Lib "piapi32.dll" ();
//[DllImport("piapi32.dll"] public static extern int piut_disconnectnode Lib "piapi32.dll" (ByVal SrvName As String);
//[DllImport("piapi32.dll"] public static extern int piut_fastserverversion Lib "piapi32.dll" (ByRef MinorVer As Integer, ByVal buildid As String, ByVal BuildLen As Integer);
//[DllImport("piapi32.dll"] public static extern int piut_getapiversion Lib "piapi32.dll" (ByVal version As String, ByVal slen As Integer);
//[DllImport("piapi32.dll"] public static extern int piut_getloginuser Lib "piapi32.dll" () As String
//Declare Sub piut_getprotocolvers Lib "piapi32.dll" (ByVal Vers As String, ByVal slen As Integer)
//[DllImport("piapi32.dll"] public static extern int piut_getserverversion Lib "piapi32.dll" (ByRef NodeID As Integer, ByVal ServerName As String, ByVal servernamelen As Integer, ByVal version As String, ByVal versionlen As Integer, ByVal buildid As String, ByVal buildidlen As Integer);
//Declare Sub piut_inceventcounter Lib "piapi32.dll" (ByVal counter As Integer, ByVal Count As Integer)
//[DllImport("piapi32.dll"] public static extern int piut_ishome Lib "piapi32.dll" ();
//[DllImport("piapi32.dll"] public static extern int piut_login Lib "piapi32.dll" (ByVal username As String, ByVal password As String, ByRef valid As Integer);
//[DllImport("piapi32.dll"] public static extern int piut_netinfo Lib "piapi32.dll" (ByVal namestr As String, ByVal NameLen As Integer, ByVal addressstr As String, ByVal addresslen As Integer, ByVal typestr As String, ByVal typelen As Integer);
//[DllImport("piapi32.dll"] public static extern int piut_netnodeinfo Lib "piapi32.dll" (ByVal namestr As String, ByVal NameLen As Integer, ByVal addressstr As String, ByVal addresslen As Integer, ByRef connected As Integer);
//[DllImport("piapi32.dll"] public static extern int piut_netserverinfo Lib "piapi32.dll" (ByVal namestr As String, ByVal NameLen As Integer, ByVal addressstr As String, ByVal addresslen As Integer, ByRef connected As Integer);
//[DllImport("piapi32.dll"] public static extern int piut_setdefaultservernode Lib "piapi32.dll" (ByVal ServerName As String);
//Declare Sub piut_setprocname Lib "piapi32.dll" (ByVal ProcName As String)
[DllImport("piapi32.dll")] public static extern int piut_setservernode (string ServerName );
//Declare Sub piut_zeroeventcounter Lib "piapi32.dll" (ByVal counter As Integer)
//
[DllImport("piapi32.dll")] public static extern int piar_getarcvaluesx (ref int PtNum, int arcMode, ref int Count, ref Double drVal, ref int iVal, string bVal, ref int bSize, ref int iStat, ref short Flags,  ref PITimeStamp time0, ref PITimeStamp time1, int FuncCode);
//[DllImport("piapi32.dll"] public static extern int piar_getarcvaluesfilterx Lib "piapi32.dll" (ByVal PtNum As Integer, ByVal Mode As Integer, ByRef Count As Integer, ByRef drVal As Double, ByRef iVal As Integer, ByVal bVal As StringBuilder, ByRef bSize As Integer, ByRef iStat As Integer, ByRef Flags As Short, ByRef time0 As PITimeStamp, ByRef time1 As PITimeStamp, ByVal Expr As String, ByVal FuncCode As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_getarcvaluex Lib "piapi32.dll" (ByVal PtNum As Integer, ByVal arcMode As Integer, ByRef drVal As Double, ByRef iVal As Integer, ByVal bVal As StringBuilder, ByRef bSize As Integer, ByRef iStat As Integer, ByRef Flags As Short, ByRef time0 As PITimeStamp);
//[DllImport("piapi32.dll"] public static extern int piar_putarcvaluesx Lib "piapi32.dll" (ByVal Count As Integer, ByVal Mode As Integer, ByRef PtNum As Integer, ByRef drVal As Double, ByRef iVal As Integer, ByVal bVal As String, ByRef bSize As Integer, ByRef iStat As Integer, ByRef Flags As Short, ByRef time0 As PITimeStamp, ByRef Errors As Integer);
//[DllImport("piapi32.dll"] public static extern int piar_putarcvaluex Lib "piapi32.dll" (ByVal PtNum As Integer, ByVal Mode As Integer, ByRef drVal As Double, ByRef iVal As Integer, ByVal bVal As String, ByRef bSize As Integer, ByRef iStat As Integer, ByRef Flags As Short, ByRef time0 As PITimeStamp);
//[DllImport("piapi32.dll"] public static extern int pipt_pointtypex Lib "piapi32.dll" (ByVal PtNum As Integer, ByRef typeX As Integer);
//'[DllImport("piapi32.dll"] public static extern int pisn_evmexceptionsx Lib "piapi32.dll" (ByVal Count&, PTnum&, event As PI_EVENT, ByVal FuncCode&);
//[DllImport("piapi32.dll"] public static extern int pisn_evmexceptx Lib "piapi32.dll" (ByRef Count As Integer, ByRef PtNum As Integer, ByRef typeX As Integer, ByRef Value As Object, ByRef iStat As Integer, ByRef Flags As Short, ByRef Timeval As PITimeStamp, ByVal FuncCode As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_flushputsnapqx Lib "piapi32.dll" (ByRef numbptErrs As Integer, ByRef qErrs As QERROR);
//[DllImport("piapi32.dll"] public static extern int pisn_getsnapshotsx Lib "piapi32.dll" (ByRef PtNum As Integer, ByRef cntptnum As Integer, ByRef drVal As Double, ByRef iVal As Integer, ByVal bVal As StringBuilder, ByRef bSize As Integer, ByRef iStat As Integer, ByRef Flags As Short, ByRef time0 As PITimeStamp, ByRef lerror As Integer, ByVal FuncCode As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_getsnapshotx Lib "piapi32.dll" (ByVal PtNum As Integer, ByRef drVal As Double, ByRef iVal As Integer, ByVal bVal As StringBuilder, ByRef bSize As Integer, ByRef iStat As Integer, ByRef Flags As Short, ByRef time0 As PITimeStamp);
//[DllImport("piapi32.dll"] public static extern int pisn_putsnapshotqx Lib "piapi32.dll" (ByVal PtNum As Integer, ByRef drVal As Double, ByRef iVal As Integer, ByVal bVal As String, ByRef bSize As Integer, ByRef iStat As Integer, ByRef Flags As Short, ByRef TimeStamp As PITimeStamp, ByVal Queueing As Integer, ByRef numbptErrs As Integer, ByRef qErrs As QERROR);
//'pisn_putsnapshotsx takes a pointer to an array of string pointers which can't be generated in VB
//[DllImport("piapi32.dll"] public static extern int pisn_putsnapshotsx Lib "piapi32.dll" (ByVal Count As Integer, ByRef PtNum As Integer, ByRef drVal As Double, ByRef iVal As Integer, ByVal bVal As String, ByRef bSize As Integer, ByRef iStat As Integer, ByRef Flags As Short, ByRef time0 As Date, ByRef Errors As Integer);
//[DllImport("piapi32.dll"] public static extern int pisn_putsnapshotx Lib "piapi32.dll" (ByVal PtNum As Integer, ByRef drVal As Double, ByRef iVal As Integer, ByVal bVal As String, ByRef bSize As Integer, ByRef iStat As Integer, ByRef Flags As Short, ByRef time0 As Date);
//'[DllImport("piapi32.dll"] public static extern int pisn_sendexceptionqx Lib "piapi32.dll" (ByVal pt&, ByVal typeX&, oldValue As PI_EVENT, prevvalue As PI_EVENT, newvalue As PI_EVENT, ByVal ExcDevEng#, ByVal ExcMin#, ByVal ExcMax#, Count&, ByVal Queueing&, numbptErrs&, qErrs As QERROR);
//'[DllImport("piapi32.dll"] public static extern int pisn_sendexceptionsx Lib "piapi32.dll" (ByVal num_pts&, ptnum&, typeX&, except As PI_EXCEPTSTRU, Errors&, Count&);
//[DllImport("piapi32.dll"] public static extern int pisn_sendexceptqx Lib "piapi32.dll" (ByVal pt As Integer, ByVal typeX As Integer, ByRef oldVal As Object, ByRef oldistat As Integer, ByRef oldFlags As Short, ByRef oldTime As PITimeStamp, ByRef prevVal As Object, ByRef previstat As Integer, ByRef prevFlags As Short, ByRef prevTime As PITimeStamp, ByRef Value As Object, ByRef iStat As Integer, ByRef Flags As Short, ByRef newTime As PITimeStamp, ByVal ExcDevEng As Double, ByVal ExcMin As Double, ByVal ExcMax As Double, ByRef Count As Integer, ByVal Queueing As Integer, ByRef numbptErrs As Integer, ByRef qErrs As QERROR);
//[DllImport("piapi32.dll"] public static extern int pitm_getpitime Lib "piapi32.dll" (ByRef time0 As PITimeStamp, ByRef frac As Double);
//[DllImport("piapi32.dll"] public static extern int pitm_isdst Lib "piapi32.dll" (ByRef time0 As PITimeStamp);
//Declare Sub pitm_setcurtime Lib "piapi32.dll" (ByRef time0 As PITimeStamp, ByVal incl_subsec As Short)
//Declare Sub pitm_setdst Lib "piapi32.dll" (ByRef time0 As PITimeStamp, ByVal tm_isdst As Integer)
[DllImport("piapi32.dll")] public static extern int pitm_setpitime (ref PITimeStamp time0, int PItime, double frac);
//[DllImport("piapi32.dll"] public static extern int pitm_settime Lib "piapi32.dll" (ByRef time0 As PITimeStamp, ByVal xyear As Integer, ByVal xmonth As Integer, ByVal xday As Integer, ByVal xhour As Integer, ByVal xminute As Integer, ByVal xsecond As Double);
//[DllImport("piapi32.dll"] public static extern int piut_errormsg Lib "piapi32.dll" (ByVal stat As Integer, ByVal Msg As String, ByRef MsgLen As Integer);
//[DllImport("piapi32.dll"] public static extern int piut_setpassword Lib "piapi32.dll" (ByVal username As String, ByVal oldpw As String, ByVal newpw As String);
//[DllImport("piapi32.dll"] public static extern int piut_strerror Lib "piapi32.dll" (ByVal stat As Integer, ByVal Msg As String, ByRef MsgLen As Integer, ByVal SrcStr As String);


		public PIAPI32()
		{			
		}
	}
}